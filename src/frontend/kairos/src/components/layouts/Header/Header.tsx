import { Link } from 'react-router-dom';
import styles from './Header.module.css';

const Header = () => {
    return(
        <>
            <header className={styles.header}>
                <div className='layoutContainer'>

                    <div className={styles.userName}>
                        <p>Bem-vindo: <strong>Usuário</strong></p>
                    </div>

                    <nav className={styles.navBar}>
                        
                        <div className={styles.navBarLogo}>
                            <Link to="/" className={styles.navLink}>Kairos</Link>
                        </div>
        
                        <ul className={styles.navMenu}>
                            
                            <li className={styles.navBarItem}>
                                <Link to="/" className={styles.navLink}>Início</Link>
                            </li>
            
                            <li className={styles.navBarItem}>
                                <Link to="/listarEvento" className={styles.navLink}>Eventos</Link>
                            </li>
            
                            <li className={styles.navBarItem}>
                                <Link to="/listarEvento" className={styles.navLink}>Blog</Link>
                            </li>
            
                            <li className={styles.navBarItem}>
                                <Link to="/administrativa" className={styles.navLink}>Administrativa</Link>
                            </li>
            
                            <li className={`${styles.navBarItem} ${styles.dropHover}`}>
                                <span className={styles.navLink}>Perfil</span>
                                <div className={styles.drop}>
                                    <Link to="/verPerfil" className={styles.navLinkDrop}>Ver Perfil</Link>
                                    <span className={styles.navLinkDrop}>Logout</span>
                                </div>
                            </li>

                        </ul>
        
                    <div className={styles.menuToggle}>
                        <span className={styles.bar}></span>
                        <span className={styles.bar}></span>
                        <span className={styles.bar}></span>
                    </div>
                    </nav>
                </div>
            </header>
        </>
    )
}

export default Header