import React, { useState } from 'react';
import { Link } from 'react-router-dom'
import '../styles/Header.css'

export default function Header() {

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
                    <li className='nabar-item'>
                        <Link className='nav-link'>Eventos</Link>
                    </li>
                    <li className='nabar-item'>
                        <Link className='nav-link'>Organização</Link>
                    </li>
                    <li className='nabar-item'>
                        <Link className='nav-link'>Administração</Link>
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