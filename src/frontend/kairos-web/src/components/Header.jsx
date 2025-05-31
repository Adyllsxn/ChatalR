import React from 'react'
import { Link } from 'react-router-dom'
import '../styles/Header.css' 

export default function Header() {
    return (
    <header>
        <div className='layout-container'>
            <nav className='navbar'>
                <div className="navbar-logo">
                    <Link to="/" className='nav-link'>Kairos</Link>
                </div>

                <ul className='nav-menu'>
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

                <div class="menu-toggle">
                    <span class="bar"></span>
                    <span class="bar"></span>
                    <span class="bar"></span>
                </div>
            </nav>
        </div>
    </header>
    )
}