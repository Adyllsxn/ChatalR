import { motion, AnimatePresence } from 'framer-motion';
import { useState, useEffect } from 'react';
import { 
  HiMenu, 
  HiX, 
  HiPhone,
  HiCalendar,
  HiSparkles
} from 'react-icons/hi';

const Header = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);
  const [isScrolled, setIsScrolled] = useState(false);

  const menuItems = [
    { name: 'Início', href: '#inicio', icon: HiSparkles },
    { name: 'Serviços', href: '#servicos', icon: HiCalendar },
    { name: 'Eventos', href: '#eventos', icon: HiSparkles },
    { name: 'Depoimentos', href: '#depoimentos', icon: HiSparkles },
    { name: 'Contato', href: '#contato', icon: HiPhone }
  ];

  // Efeito de scroll para mudar o header
  useEffect(() => {
    const handleScroll = () => {
      setIsScrolled(window.scrollY > 50);
    };

    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, []);

  // Fechar menu ao clicar em um link
  const handleMenuClick = () => {
    setIsMenuOpen(false);
  };

  return (
    <motion.header 
      initial={{ y: -100 }}
      animate={{ y: 0 }}
      className={`fixed top-0 w-full z-50 transition-all duration-500 ${
        isScrolled 
          ? 'bg-white/95 backdrop-blur-xl shadow-2xl shadow-purple-500/10 border-b border-purple-100/50' 
          : 'bg-white/90 backdrop-blur-md border-b border-gray-200/30'
      }`}
    >
      <nav className="container mx-auto px-4 lg:px-6">
        <div className="flex justify-between items-center py-3 lg:py-4">
          {/* Logo */}
          <motion.div
            whileHover={{ scale: 1.05 }}
            className="flex items-center space-x-3"
          >
            <div className="relative">
              <motion.div
                animate={{ 
                  rotate: [0, 10, -5, 0],
                  scale: [1, 1.1, 1]
                }}
                transition={{ 
                  duration: 3,
                  repeat: Infinity,
                  repeatDelay: 5
                }}
                className="w-10 h-10 bg-gradient-to-br from-purple-600 to-blue-600 rounded-2xl flex items-center justify-center shadow-lg"
              >
                <HiSparkles className="w-5 h-5 text-white" />
              </motion.div>
              <motion.div
                animate={{ 
                  scale: [1, 1.2, 1],
                  opacity: [0.5, 0.8, 0.5]
                }}
                transition={{ 
                  duration: 2,
                  repeat: Infinity 
                }}
                className="absolute -inset-1 bg-gradient-to-br from-purple-400 to-blue-400 rounded-2xl blur-sm -z-10"
              />
            </div>
            <div>
              <motion.span
                className="text-2xl lg:text-3xl font-black bg-gradient-to-r from-purple-600 to-blue-600 bg-clip-text text-transparent"
              >
                Kairos
              </motion.span>
              <div className="text-xs text-gray-500 font-medium -mt-1">
                EVENTOS & CELEBRAÇÕES
              </div>
            </div>
          </motion.div>

          {/* Desktop Menu */}
          <div className="hidden lg:flex items-center space-x-1">
            {menuItems.map((item, index) => (
              <motion.a
                key={item.name}
                href={item.href}
                initial={{ opacity: 0, y: -10 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
                whileHover={{ 
                  y: -2,
                  scale: 1.02,
                  color: '#7c3aed'
                }}
                whileTap={{ scale: 0.95 }}
                className="relative px-6 py-3 text-gray-700 hover:text-purple-600 font-semibold transition-all duration-300 group"
              >
                <span className="relative z-10 flex items-center space-x-2">
                  <item.icon className="w-4 h-4 opacity-60 group-hover:opacity-100" />
                  <span>{item.name}</span>
                </span>
                
                {/* Hover effect */}
                <motion.div
                  initial={{ scale: 0, opacity: 0 }}
                  whileHover={{ scale: 1, opacity: 1 }}
                  className="absolute inset-0 bg-gradient-to-r from-purple-50 to-blue-50 rounded-2xl border border-purple-100 shadow-sm"
                />
                
                {/* Active indicator */}
                <motion.div
                  initial={{ scale: 0 }}
                  whileHover={{ scale: 1 }}
                  className="absolute bottom-1 left-1/2 transform -translate-x-1/2 w-1 h-1 bg-gradient-to-r from-purple-600 to-blue-600 rounded-full"
                />
              </motion.a>
            ))}
            
            {/* CTA Button */}
            <motion.a
              href="#contato"
              initial={{ opacity: 0, scale: 0.8 }}
              animate={{ opacity: 1, scale: 1 }}
              transition={{ duration: 0.5, delay: 0.6 }}
              whileHover={{ 
                scale: 1.05,
                boxShadow: '0 20px 40px rgba(124, 58, 237, 0.3)'
              }}
              whileTap={{ scale: 0.95 }}
              className="ml-4 px-6 py-3 bg-gradient-to-r from-purple-600 to-blue-600 text-white font-semibold rounded-2xl shadow-lg hover:shadow-xl transition-all duration-300 flex items-center space-x-2"
            >
              <HiCalendar className="w-4 h-4" />
              <span>Orçamento</span>
            </motion.a>
          </div>

          {/* Mobile Menu Button */}
          <motion.button
            whileHover={{ scale: 1.1 }}
            whileTap={{ scale: 0.9 }}
            className="lg:hidden w-12 h-12 bg-gradient-to-r from-purple-600 to-blue-600 text-white rounded-2xl flex items-center justify-center shadow-lg relative"
            onClick={() => setIsMenuOpen(!isMenuOpen)}
          >
            <AnimatePresence mode="wait">
              {isMenuOpen ? (
                <motion.div
                  key="close"
                  initial={{ rotate: -90, opacity: 0 }}
                  animate={{ rotate: 0, opacity: 1 }}
                  exit={{ rotate: 90, opacity: 0 }}
                >
                  <HiX className="w-6 h-6" />
                </motion.div>
              ) : (
                <motion.div
                  key="menu"
                  initial={{ rotate: 90, opacity: 0 }}
                  animate={{ rotate: 0, opacity: 1 }}
                  exit={{ rotate: -90, opacity: 0 }}
                >
                  <HiMenu className="w-6 h-6" />
                </motion.div>
              )}
            </AnimatePresence>
            
            {/* Pulsing effect */}
            <motion.div
              animate={{ 
                scale: [1, 1.2, 1],
                opacity: [1, 0.5, 1]
              }}
              transition={{ 
                duration: 2,
                repeat: Infinity 
              }}
              className="absolute -inset-1 bg-gradient-to-r from-purple-600 to-blue-600 rounded-2xl blur-sm -z-10"
            />
          </motion.button>
        </div>

        {/* Mobile Menu */}
        <AnimatePresence>
          {isMenuOpen && (
            <motion.div
              initial={{ opacity: 0, height: 0 }}
              animate={{ opacity: 1, height: 'auto' }}
              exit={{ opacity: 0, height: 0 }}
              transition={{ duration: 0.3 }}
              className="lg:hidden bg-white/95 backdrop-blur-xl rounded-3xl shadow-2xl border border-gray-200/50 overflow-hidden"
            >
              <div className="p-6 space-y-4">
                {menuItems.map((item, index) => (
                  <motion.a
                    key={item.name}
                    href={item.href}
                    initial={{ opacity: 0, x: -20 }}
                    animate={{ opacity: 1, x: 0 }}
                    transition={{ duration: 0.3, delay: index * 0.1 }}
                    whileHover={{ x: 10, backgroundColor: '#faf5ff' }}
                    onClick={handleMenuClick}
                    className="flex items-center space-x-4 p-4 rounded-2xl text-gray-700 hover:text-purple-600 font-semibold transition-all duration-300 group"
                  >
                    <div className="w-10 h-10 bg-gradient-to-br from-purple-100 to-blue-100 rounded-2xl flex items-center justify-center group-hover:from-purple-200 group-hover:to-blue-200 transition-colors">
                      <item.icon className="w-5 h-5 text-purple-600" />
                    </div>
                    <span className="text-lg">{item.name}</span>
                  </motion.a>
                ))}
                
                {/* Mobile CTA */}
                <motion.a
                  href="#contato"
                  initial={{ opacity: 0, y: 20 }}
                  animate={{ opacity: 1, y: 0 }}
                  transition={{ duration: 0.3, delay: 0.5 }}
                  whileHover={{ scale: 1.02 }}
                  whileTap={{ scale: 0.98 }}
                  onClick={handleMenuClick}
                  className="block w-full mt-6 p-4 bg-gradient-to-r from-purple-600 to-blue-600 text-white font-semibold text-center rounded-2xl shadow-lg hover:shadow-xl transition-all duration-300"
                >
                  <div className="flex items-center justify-center space-x-2">
                    <HiCalendar className="w-5 h-5" />
                    <span className="text-lg">Solicitar Orçamento</span>
                  </div>
                </motion.a>

                {/* Contact Info Mobile */}
                <motion.div
                  initial={{ opacity: 0 }}
                  animate={{ opacity: 1 }}
                  transition={{ delay: 0.6 }}
                  className="pt-6 border-t border-gray-200/50"
                >
                  <div className="flex items-center justify-center space-x-4 text-sm text-gray-600">
                    <a href="tel:+5511999999999" className="flex items-center space-x-2 hover:text-purple-600 transition-colors">
                      <HiPhone className="w-4 h-4" />
                      <span>(11) 99999-9999</span>
                    </a>
                  </div>
                </motion.div>
              </div>
            </motion.div>
          )}
        </AnimatePresence>
      </nav>
    </motion.header>
  );
};

export default Header;