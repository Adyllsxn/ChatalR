import React, { useState } from 'react';
import {FaUser, FaLock } from 'react-icons/fa';
import apiservice from '../../service/ApiService';
import '../../styles/public/Login.css'

export default function Login({ onLogin }) {
    const [showPassword, setShowPassword] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    async function login(event){
        event.preventDefault();
        const data = {
            email,password
        };
        try{
            const response = await apiservice.post('/v1/Login', data);
            localStorage.setItem('email', email);
            localStorage.setItem('token', response.data.token);

            onLogin(); 
            
            onLogin();

        }catch(error){
            alert(`Login falhou: ${error}`);
            if (error.response) {
            console.log("Dados da resposta:", error.response.data);
            console.log("Status:", error.response.status);
            console.log("Headers:", error.response.headers);
            } else if (error.request) {
            console.log("Nenhuma resposta recebida:", error.request);
            } else {
            console.log("Erro ao configurar a requisição:", error.message);
            }
        }
    }
    
    return (
        <main className='login-wrap'>
            <div className='login-conteiner'>
                <form onSubmit={login}>
                    <h1>Kairos</h1>

                    <div className='input-field'>
                        <input  type="email" 
                                placeholder='Exemplo@gmail.com'
                                required
                                value={email}
                                onChange={(e) => setEmail(e.target.value)} />
                        <FaUser className='icon'/> 
                    </div>

                    <div className='input-field'>
                        <input  type={showPassword ? 'text' : 'password'}
                                placeholder='Senha'
                                required
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}/>
                        <FaLock className='icon'/>
                    </div>

                    <div className='toggle-password'>
                        <input
                            type="checkbox"
                            id="showPassword"
                            checked={showPassword}
                            onChange={() => setShowPassword(!showPassword)} />
                        <label htmlFor="showPassword">Mostrar a senha</label>
                    </div>


                    <button type="submit">Entrar</button>
                </form>
            </div>
        </main>
    )
}