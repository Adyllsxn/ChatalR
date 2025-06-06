import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import '../styles/Header.css';

export default function Header({ onLogout }) {
    const [menuActive, setMenuActive] = useState(false);
    const [email, setEmail] = useState('');

    const toggleMenu = () => {
        setMenuActive(!menuActive);
    };

    useEffect(() => {
        // Pega o email salvo no localStorage quando o componente montar
        const storedEmail = localStorage.getItem('email');
        if (storedEmail) {
            setEmail(storedEmail);
        }
    }, []);

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
                            <Link className='nav-link-drop' onClick={onLogout}>Logout</Link>
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
    )
}
