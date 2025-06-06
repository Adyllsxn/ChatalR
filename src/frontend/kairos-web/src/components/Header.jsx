import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import '../styles/Header.css';

export default function Header({ onLogout }) {
    const [menuActive, setMenuActive] = useState(false);
    const [email, setEmail] = useState('');
    const navigate = useNavigate();

    const toggleMenu = () => {
        setMenuActive(!menuActive);
    };

    useEffect(() => {
        const storedEmail = localStorage.getItem('email');
        if (storedEmail) {
        setEmail(storedEmail);
        }
    }, []);

    function handleLogoutClick() {
        onLogout();          // Remove do localStorage e muda o estado
        navigate('/login');  // Redireciona para a página de login
    }

    return (
        <header>
        <div className='layout-container'>
            <div className='username'>
            <p>Bem-vindo: <strong>{email || 'Usuário'}</strong></p>
            </div>
            <nav className='navbar'>
            <div className="navbar-logo">
                <Link to="/" className='nav-link'>Kairos</Link>
            </div>

            <ul className={`nav-menu ${menuActive ? 'active' : ''}`}>
                <li className='nabar-item'>
                <Link to="/" className='nav-link'>Início</Link>
                </li>
                <li className='nabar-item'>
                <Link to="/listarEvento" className='nav-link'>Eventos</Link>
                </li>
                <li className='nabar-item'>
                <Link to="/administrativa" className='nav-link'>Administrativa</Link>
                </li>
                <li className='nabar-item drop-hover'>
                <Link className='nav-link'>Perfil</Link>
                <div className='drop'>
                    <Link to="/verPerfil" className='nav-link-drop'>Ver Perfil</Link>
                    <Link to="/alterarSenha" className='nav-link-drop'>Alterar Senha</Link>
                    <Link className='nav-link-drop' onClick={handleLogoutClick}>Logout</Link>
                </div>
                </li>
            </ul>

            <div className={`menu-toggle ${menuActive ? 'active' : ''}`}
                onClick={toggleMenu}>
                <span className="bar"></span>
                <span className="bar"></span>
                <span className="bar"></span>
            </div>
            </nav>
        </div>
        </header>
    );
}
