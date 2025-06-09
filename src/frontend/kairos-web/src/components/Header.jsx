import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import './Header.css';

export default function Header({ onLogout }) {
    const [menuActive, setMenuActive] = useState(false);
    const [email, setEmail] = useState('');
    const [perfilID, setPerfilID] = useState(null);
    const navigate = useNavigate();

    const toggleMenu = () => {
        setMenuActive(!menuActive);
    };

    const closeMenu = () => {
        setMenuActive(false);
    };

    useEffect(() => {
        const storedEmail = localStorage.getItem('email');
        const storedPerfilID = parseInt(localStorage.getItem('perfilID'), 10);

        if (storedEmail) setEmail(storedEmail);
        if (!isNaN(storedPerfilID)) setPerfilID(storedPerfilID);
    }, []);

    function handleLogoutClick() {
        onLogout();
        navigate('/login');
        closeMenu(); // Fecha o menu também ao fazer logout
    }

    return (
        <header>
        <div className='layout-container'>
            <div className='username'>
            <p>Bem-vindo: <strong>{email || 'Usuário'}</strong></p>
            </div>
            <nav className='navbar'>
            <div className="navbar-logo">
                <Link to="/" className='nav-link' onClick={closeMenu}>Kairos</Link>
            </div>

            <ul className={`nav-menu ${menuActive ? 'active' : ''}`}>
                <li className='nabar-item'>
                <Link to="/" className='nav-link' onClick={closeMenu}>Início</Link>
                </li>

                <li className='nabar-item'>
                <Link to="/listarEvento" className='nav-link' onClick={closeMenu}>Eventos</Link>
                </li>
                <li className='nabar-item'>
                <Link className='nav-link' onClick={closeMenu}>Blog</Link>
                </li>

                {(perfilID === 1 || perfilID === 2) && (
                <li className='nabar-item'>
                    <Link to="/administrativa" className='nav-link' onClick={closeMenu}>Administrativa</Link>
                </li>
                )}

                <li className='nabar-item drop-hover'>
                <span className='nav-link'>Perfil</span>
                <div className='drop'>
                    <Link to="/verPerfil" className='nav-link-drop' onClick={closeMenu}>Ver Perfil</Link>
                    <span className='nav-link-drop' onClick={handleLogoutClick}>Logout</span>
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
