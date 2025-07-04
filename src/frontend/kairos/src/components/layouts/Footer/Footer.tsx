import { Link } from 'react-router-dom';
import { FaFacebookF, FaArrowUp } from 'react-icons/fa6';
import { motion } from 'framer-motion';
import styles from './Footer.module.css';

export default function Footer() {
    return (
        <>
            <footer className={styles.siteFooter}>
                <div className='layoutContainer'>
                    <div className={styles.footerTop}>
                        <div className={styles.footerTitle}>
                            <h1>Unidos para servir melhor</h1>
                        </div>
                        <div className={styles.footerLinks}>
                            <div className={styles.footerColumn}>
                                <h3>Institucional</h3>
                                <ul>
                                    <li><Link to="/sobreNos" className={styles.navLink}>Sobre Nós</Link></li>
                                    <li><Link to="/ajuda" className={styles.navLink}>Ajuda</Link></li>
                                    <li><Link to="/faq" className={styles.navLink}>FAQ</Link></li>
                                </ul>
                            </div>
                            <div className={styles.footerColumn}>
                                <h3>Igreja Sossego em Cristo</h3>
                                <ul>
                                    <li>Endereço: Rua nº 03, Bairro Sossego, Kilamba</li>
                                    <li>Telefone: (+244) 925 573 990</li>
                                    <li>Email: sossegoemcristo@hotmail.com</li>
                                </ul>
                            </div>
                            <div className={styles.footerColumn}>
                                <h3>Redes Sociais</h3>
                                <div className={styles.socialIcons}>
                                    <a href="https://www.facebook.com/nossosossegoemcristo" target="_blank" rel="noopener noreferrer" aria-label="Facebook">
                                        <FaFacebookF />
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className={styles.footerBottom}>
                        <p>© {new Date().getFullYear()} Kairos | Todos os direitos reservados</p>
                        <p>
                            <Link to="/politicaDePrivacidade" className='navLink'>Política de Privacidade</Link>
                        </p>
                    </div>
                </div>

                {/* Botão com hover animado */}
                <motion.button
                    className={styles.btnTop}
                    whileHover={{ scale: 1.2, rotate: 360 }}
                    whileTap={{ scale: 0.95 }}
                    transition={{ type: 'spring', stiffness: 300 }}
                    onClick={() => window.scrollTo({ top: 0, behavior: 'smooth' })}
                    aria-label="Voltar ao topo"
                >
                    <FaArrowUp />
                </motion.button>
            </footer>
        </>
    );
}
