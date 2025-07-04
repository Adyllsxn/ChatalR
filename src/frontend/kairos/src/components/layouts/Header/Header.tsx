import { Link, useNavigate } from 'react-router-dom';
import styles from './Header.module.css';
import { useState, useEffect } from 'react';

type HeaderProps = {
   onLogout: () => void;
};

const Header = ({ onLogout }: HeaderProps) => {
    const [email, setEmail] = useState('');
    const [perfilID, setPerfilID] = useState<number | null>(null);
    const [menuOpen, setMenuOpen] = useState(false);
    const navigate = useNavigate();

    const toggleMenu = () => {
        setMenuOpen(!menuOpen);
    };
    const closeMenu = () => {
        setMenuOpen(false);
    };

    useEffect(() => {
        const storedEmail = localStorage.getItem('email');
        const perfilIDString = localStorage.getItem('perfilID');
        const storedPerfilID = perfilIDString ? parseInt(perfilIDString, 10) : null;

        if (storedEmail) setEmail(storedEmail);
        if (storedPerfilID !== null && !isNaN(storedPerfilID)) {
            setPerfilID(storedPerfilID);
        }
    }, []);

    function handleLogoutClick() {
        onLogout();
        navigate('/login');
    }

    return (
        <header className={styles.header}>
            <div className="layoutContainer">
                <div className={styles.userName}>
                    <p>Bem-vindo: <strong>{email || 'Usuário'}</strong></p>
                </div>

                <nav className={styles.navBar}>
                    <div className={styles.navBarLogo}>
                        <Link to="/" className={styles.navLink}>Kairos</Link>
                    </div>

                    <ul className={`${styles.navMenu} ${menuOpen ? styles.active : ''}`}>
                        <li className={styles.navBarItem}>
                            <Link to="/" className={styles.navLink} onClick={closeMenu}>Início</Link>
                        </li>
                        <li className={styles.navBarItem}>
                            <Link to="/eventoList" className={styles.navLink} onClick={closeMenu}>Eventos</Link>
                        </li>
                        <li className={styles.navBarItem}>
                            <Link to="/eventoList" className={styles.navLink} onClick={closeMenu}>Blog</Link>
                        </li>
                        {(perfilID === 1 || perfilID === 2) && (
                        <li className={styles.navBarItem}>
                            <Link to="/administrativa" className={styles.navLink} onClick={closeMenu}>Administrativa</Link>
                        </li>
                        )}
                        <li className={`${styles.navBarItem} ${styles.dropHover}`}>
                            <span className={styles.navLink}>Perfil</span>
                            <div className={styles.dropBox}>
                                <div className={styles.drop}>
                                    <div className={styles.dropItem}>
                                        <Link to="/usuarioView" className={styles.navLinkDrop} onClick={closeMenu}>Ver Perfil</Link>
                                        <span className={`${styles.navLinkDrop} ${styles.dropLogout}`} onClick={handleLogoutClick}>Logout</span>
                                    </div>
                                </div>
                            </div>
                        </li>
                    </ul>

                    <div className={`${styles.menuToggle} ${menuOpen ? styles.active : ''}`} onClick={toggleMenu}>
                        <span className={styles.bar}></span>
                        <span className={styles.bar}></span>
                        <span className={styles.bar}></span>
                    </div>
                </nav>
            </div>
        </header>
    );
};

export default Header;
