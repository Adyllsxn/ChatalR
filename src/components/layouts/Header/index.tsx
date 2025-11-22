import { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { motion, AnimatePresence } from 'framer-motion';
import { headerStyles } from './styles';

function Header() {
  const [menuOpen, setMenuOpen] = useState(false);
  const [scrolled, setScrolled] = useState(false);
  const location = useLocation();

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  const closeMenu = () => {
    setMenuOpen(false);
  };

  useEffect(() => {
    const handleScroll = () => {
      const isScrolled = window.scrollY > 50;
      setScrolled(isScrolled);
    };

    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, []);

  // Bloquear scroll quando menu mobile estiver aberto
  useEffect(() => {
    if (menuOpen) {
      document.body.style.overflow = 'hidden';
    } else {
      document.body.style.overflow = 'unset';
    }

    return () => {
      document.body.style.overflow = 'unset';
    };
  }, [menuOpen]);

  return (
    <motion.header 
      className={`${headerStyles.header} ${scrolled ? headerStyles.scrolled : ''}`}
      initial={{ y: -100 }}
      animate={{ y: 0 }}
      transition={{ duration: 0.6, ease: "easeOut" }}
    >
      <div className={headerStyles.container}>
        <nav className={headerStyles.nav}>
          {/* Logo Principal - MESMO ESTILO DO MOBILE */}
          <motion.div 
            className={headerStyles.logoContainer}
            whileHover={{ scale: 1.05 }}
            transition={{ type: "spring", stiffness: 400, damping: 10 }}
          >
            <Link to="/" className={headerStyles.logo}>
              <span className={headerStyles.logoText}>KAIROS</span>
              <div className={headerStyles.logoUnderline}></div>
            </Link>
          </motion.div>

          {/* Desktop Menu */}
          <ul className={headerStyles.desktopMenu}>
            <motion.li whileHover={{ y: -2 }} transition={{ type: "spring", stiffness: 400 }}>
              <Link 
                to="/" 
                className={`${headerStyles.menuItem} ${location.pathname === '/' ? headerStyles.menuItemActive : ''}`}
              >
                <span>Início</span>
                <div className={headerStyles.menuUnderline}></div>
              </Link>
            </motion.li>
            
            <motion.li whileHover={{ y: -2 }} transition={{ type: "spring", stiffness: 400 }}>
              <Link 
                to="/eventoList" 
                className={`${headerStyles.menuItem} ${location.pathname === '/eventoList' ? headerStyles.menuItemActive : ''}`}
              >
                <span>Eventos</span>
                <div className={headerStyles.menuUnderline}></div>
              </Link>
            </motion.li>
            
            <motion.li whileHover={{ y: -2 }} transition={{ type: "spring", stiffness: 400 }}>
              <Link 
                to="/blogList" 
                className={`${headerStyles.menuItem} ${location.pathname === '/blogList' ? headerStyles.menuItemActive : ''}`}
              >
                <span>Blog</span>
                <div className={headerStyles.menuUnderline}></div>
              </Link>
            </motion.li>
            
            <motion.li whileHover={{ scale: 1.05 }} whileTap={{ scale: 0.95 }}>
              <Link to="/login" className={headerStyles.ctaButton}>
                <span>GET IN TOUCH</span>
                <svg className="w-4 h-4 ml-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                </svg>
              </Link>
            </motion.li>
          </ul>

          {/* Mobile Menu Button */}
          <motion.div 
            className={headerStyles.mobileButton}
            onClick={toggleMenu}
            whileTap={{ scale: 0.95 }}
          >
            <div className={headerStyles.hamburger}>
              <span className={`${headerStyles.bar} ${menuOpen ? headerStyles.barOpen(0) : ''}`}></span>
              <span className={`${headerStyles.bar} ${menuOpen ? headerStyles.barOpen(1) : ''}`}></span>
              <span className={`${headerStyles.bar} ${menuOpen ? headerStyles.barOpen(2) : ''}`}></span>
            </div>
          </motion.div>

          {/* Mobile Menu Overlay */}
          <AnimatePresence>
            {menuOpen && (
              <motion.div 
                className={headerStyles.mobileOverlay}
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                exit={{ opacity: 0 }}
                transition={{ duration: 0.3 }}
                onClick={closeMenu}
              >
                <motion.div 
                  className={headerStyles.mobileMenu}
                  initial={{ y: '-100%', opacity: 0 }}
                  animate={{ y: 0, opacity: 1 }}
                  exit={{ y: '-100%', opacity: 0 }}
                  transition={{ 
                    type: "spring", 
                    damping: 30, 
                    stiffness: 300,
                    mass: 0.8
                  }}
                  onClick={(e) => e.stopPropagation()}
                >
                  {/* Header do Mobile Menu - MESMA LOGO DO PRINCIPAL */}
                  <div className={headerStyles.mobileHeader}>
                    <motion.div 
                      className={headerStyles.logoContainer}
                      initial={{ opacity: 0 }}
                      animate={{ opacity: 1 }}
                      transition={{ delay: 0.1 }}
                    >
                      <Link to="/" className={headerStyles.logo} onClick={closeMenu}>
                        <span className={headerStyles.logoText}>KAIROS</span>
                        <div className={headerStyles.logoUnderline}></div>
                      </Link>
                    </motion.div>
                    
                    <motion.button 
                      onClick={closeMenu} 
                      className={headerStyles.closeButton}
                      whileHover={{ scale: 1.1 }}
                      whileTap={{ scale: 0.9 }}
                      initial={{ opacity: 0 }}
                      animate={{ opacity: 1 }}
                      transition={{ delay: 0.1 }}
                    >
                      <svg className="w-8 h-8" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M6 18L18 6M6 6l12 12" />
                      </svg>
                    </motion.button>
                  </div>

                  {/* Conteúdo do Mobile Menu */}
                  <div className={headerStyles.mobileContent}>
                    <motion.div
                      initial={{ x: -20, opacity: 0 }}
                      animate={{ x: 0, opacity: 1 }}
                      transition={{ delay: 0.2 }}
                    >
                      <Link to="/" className={headerStyles.mobileItem} onClick={closeMenu}>
                        <div className={headerStyles.mobileItemContent}>
                          <span className={headerStyles.mobileItemText}>Início</span>
                          <span className={headerStyles.mobileItemSubtitle}>Página principal</span>
                        </div>
                        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                        </svg>
                      </Link>
                    </motion.div>

                    <motion.div
                      initial={{ x: -20, opacity: 0 }}
                      animate={{ x: 0, opacity: 1 }}
                      transition={{ delay: 0.3 }}
                    >
                      <Link to="/eventoList" className={headerStyles.mobileItem} onClick={closeMenu}>
                        <div className={headerStyles.mobileItemContent}>
                          <span className={headerStyles.mobileItemText}>Eventos</span>
                          <span className={headerStyles.mobileItemSubtitle}>Confira a programação</span>
                        </div>
                        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                        </svg>
                      </Link>
                    </motion.div>

                    <motion.div
                      initial={{ x: -20, opacity: 0 }}
                      animate={{ x: 0, opacity: 1 }}
                      transition={{ delay: 0.4 }}
                    >
                      <Link to="/blogList" className={headerStyles.mobileItem} onClick={closeMenu}>
                        <div className={headerStyles.mobileItemContent}>
                          <span className={headerStyles.mobileItemText}>Blog</span>
                          <span className={headerStyles.mobileItemSubtitle}>Artigos e conteúdos</span>
                        </div>
                        <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                        </svg>
                      </Link>
                    </motion.div>

                    <motion.div
                      className={headerStyles.mobileCtaContainer}
                      initial={{ y: 20, opacity: 0 }}
                      animate={{ y: 0, opacity: 1 }}
                      transition={{ delay: 0.5 }}
                    >
                      <Link to="/login" className={headerStyles.mobileCta} onClick={closeMenu}>
                        <span>GET IN TOUCH</span>
                        <svg className="w-5 h-5 ml-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                          <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                        </svg>
                      </Link>
                    </motion.div>
                  </div>
                </motion.div>
              </motion.div>
            )}
          </AnimatePresence>
        </nav>
      </div>
    </motion.header>
  );
}

export default Header;