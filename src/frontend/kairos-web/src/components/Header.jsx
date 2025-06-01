import React, { useState } from 'react';
import { Link } from 'react-router-dom'
import '../styles/Header.css'

export default function Header({ onLogout }) {

    const [menuActive, setMenuActive] = useState(false);
    const toggleMenu = () => {
        setMenuActive(!menuActive);
    };

    return (
    <header>
        <div className='layout-container'>
            <nav className='navbar'>
                <div className="navbar-logo">
                    <Link to="/" className='nav-link'>Kairos</Link>
                </div>

                <ul className={`nav-menu ${menuActive ? 'active' : ''}`}>
                    <li className='nabar-item'>
                        <Link className='nav-link'>Início</Link>
                    </li>
                    <li className='nabar-item drop-hover'>
                        <Link className='nav-link'>Eventos</Link>
                        <div className='drop'>
                            <Link className='nav-link-drop'>Listar Eventos</Link>
                            <Link className='nav-link-drop'>Criar Novo Evento</Link>
                            <Link className='nav-link-drop'>Tipos de Evento</Link>
                            <Link className='nav-link-drop'>Sugestões</Link>
                        </div>
                    </li>
                    <li className='nabar-item'>
                        <Link className='nav-link'>Organização</Link>
                    </li>
                    <li className='nabar-item'>
                        <Link className='nav-link'>Administração</Link>
                    </li>
                    <li className='nabar-item drop-hover'>
                        <Link className='nav-link'>Perfil</Link>
                        <div className='drop'>
                            <Link className='nav-link-drop'>Meu Perfil</Link>
                            <Link className='nav-link-drop'>Editar Conta</Link>
                            <Link className='nav-link-drop'>Alterar Senha</Link>
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