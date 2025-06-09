import React, { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa';
import apiservice from '../../../service/ApiService';
import './Login.css';
import Alert from '../../shared/Alert';

export default function Login({ onLogin }) {
    const [showPassword, setShowPassword] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [alert, setAlert] = useState({ message: '', type: '' });

    async function login(event) {
        event.preventDefault();
        setLoading(true);
        const data = { email, password };

        try {
        const response = await apiservice.post('/v1/Login', data);
        
        localStorage.setItem('email', response.data.email);
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('perfilID', response.data.perfilID); // <- SALVANDO PERFIL

        onLogin(); // Atualiza estado global
        } catch (error) {
        let message = 'Erro ao fazer login.';
        if (error.response) {
            if (error.response.status === 401) {
            message = 'Email ou senha inválidos.';
            } else if (error.response.status === 404) {
            message = 'Usuário não encontrado.';
            } else {
            message = error.response.data?.message || 'Erro inesperado.';
            }
        } else if (error.request) {
            message = 'Servidor não respondeu. Verifique sua conexão.';
        } else {
            message = error.message;
        }

        setAlert({ message, type: 'error' });
        } finally {
        setLoading(false);
        }
    }

    return (
        <main className='login-wrap'>
        {alert.message && (
            <Alert
            message={alert.message}
            type={alert.type}
            onClose={() => setAlert({ message: '', type: '' })}
            />
        )}

        <div className='login-conteiner'>
            <form onSubmit={login}>
            <h1>Kairos</h1>

            <div className='input-field'>
                <input
                type="email"
                placeholder='Exemplo@gmail.com'
                required
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                />
                <FaUser className='icon' />
            </div>

            <div className='input-field'>
                <input
                type={showPassword ? 'text' : 'password'}
                placeholder='Senha'
                required
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                />
                <FaLock className='icon' />
            </div>

            <div className='toggle-password'>
                <input
                type="checkbox"
                id="showPassword"
                checked={showPassword}
                onChange={() => setShowPassword(!showPassword)}
                />
                <label htmlFor="showPassword">Mostrar a senha</label>
            </div>

            <button type="submit" disabled={loading}>
                {loading ? 'Aguarde...' : 'Entrar'}
            </button>
            </form>
        </div>
        </main>
    );
}
