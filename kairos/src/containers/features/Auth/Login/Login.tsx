import { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa';
import api from '../../../../core/service/api';
import './Login.css';

type LoginProps = {
  onLogin: () => void;
};

export default function Login({ onLogin }: LoginProps) {
  const [showPassword, setShowPassword] = useState(false);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);

  async function login(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setLoading(true);

    try {
      const response = await api.post('/v1/Login', { email, password });

      localStorage.setItem('userId', response.data.id.toString());
      localStorage.setItem('email', response.data.email);
      localStorage.setItem('token', response.data.token);
      localStorage.setItem('perfilID', response.data.perfilID.toString());

      onLogin();
    } catch {
      alert('Erro ao fazer login. Verifique os dados e tente novamente.');
    } finally {
      setLoading(false);
    }
  }

  return (
    <main className="loginWrap">
      <div className="loginConteiner">
        <form onSubmit={login}>
          <h1>Kairos</h1>

          <div className="inputField">
            <input
              type="email"
              placeholder="Exemplo@gmail.com"
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <FaUser className="icon" />
          </div>

          <div className="inputField">
            <input
              type={showPassword ? 'text' : 'password'}
              placeholder="Senha"
              required
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <FaLock className="icon" />
          </div>

          <div className="togglePassword">
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
