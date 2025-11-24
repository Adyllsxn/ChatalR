import { motion } from 'framer-motion';
import { 
  HiMail, 
  HiPhone, 
  HiLocationMarker, 
  HiClock,
  HiHeart
} from 'react-icons/hi';
import { 
  FaFacebookF, 
  FaInstagram, 
  FaTwitter,
  FaLinkedinIn 
} from 'react-icons/fa';

const Footer = () => {
  const currentYear = new Date().getFullYear();

  const footerSections = [
    {
      title: 'Nossos Serviços',
      links: [
        'Planejamento de Casamentos',
        'Eventos Corporativos',
        'Festas de Aniversário',
        'Cerimônias de Formatura',
        'Shows e Festivais',
        'Produção Completa'
      ]
    },
    {
      title: 'Links Rápidos',
      links: [
        'Sobre Nós',
        'Portfólio',
        'Depoimentos',
        'Blog',
        'Contato',
        'Orçamento'
      ]
    },
    {
      title: 'Suporte',
      links: [
        'FAQ',
        'Termos de Serviço',
        'Política de Privacidade',
        'Trabalhe Conosco',
        'Central de Ajuda',
        'Status do Evento'
      ]
    }
  ];

  const contactInfo = [
    {
      icon: HiPhone,
      text: '+55 (11) 99999-9999',
      href: 'tel:+5511999999999'
    },
    {
      icon: HiMail,
      text: 'contato@kairosevents.com',
      href: 'mailto:contato@kairosevents.com'
    },
    {
      icon: HiLocationMarker,
      text: 'São Paulo, SP - Brasil',
      href: '#'
    },
    {
      icon: HiClock,
      text: 'Seg - Sex: 9h às 18h',
      href: '#'
    }
  ];

  const socialLinks = [
    { icon: FaInstagram, href: '#', label: 'Instagram' },
    { icon: FaFacebookF, href: '#', label: 'Facebook' },
    { icon: FaTwitter, href: '#', label: 'Twitter' },
    { icon: FaLinkedinIn, href: '#', label: 'LinkedIn' }
  ];

  return (
    <footer className="bg-gradient-to-br from-gray-900 to-purple-900 text-white">
      {/* Main Footer Content */}
      <div className="container mx-auto px-6 py-16">
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-6 gap-8">
          {/* Brand Section */}
          <motion.div
            initial={{ opacity: 0, y: 30 }}
            whileInView={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.6 }}
            className="lg:col-span-2"
          >
            <motion.h3
              whileHover={{ scale: 1.05 }}
              className="text-3xl font-bold bg-gradient-to-r from-purple-400 to-blue-400 bg-clip-text text-transparent mb-4"
            >
              Kairos Events
            </motion.h3>
            <p className="text-gray-300 mb-6 leading-relaxed">
              Criando momentos inesquecíveis há mais de 10 anos. Do planejamento 
              à execução, transformamos suas ideias em experiências memoráveis 
              que marcam o tempo perfeito - o seu Kairos.
            </p>
            
            {/* Contact Info */}
            <div className="space-y-3">
              {contactInfo.map((item) => (
                <motion.a
                  key={item.text}
                  href={item.href}
                  whileHover={{ x: 5, color: '#c084fc' }}
                  className="flex items-center space-x-3 text-gray-300 hover:text-purple-300 transition-colors duration-300"
                >
                  <item.icon className="w-5 h-5 flex-shrink-0" />
                  <span className="text-sm">{item.text}</span>
                </motion.a>
              ))}
            </div>

            {/* Social Links */}
            <motion.div
              initial={{ opacity: 0 }}
              whileInView={{ opacity: 1 }}
              transition={{ delay: 0.3 }}
              className="flex space-x-4 mt-6"
            >
              {socialLinks.map((social) => (
                <motion.a
                  key={social.label}
                  href={social.href}
                  whileHover={{ 
                    scale: 1.2, 
                    y: -2,
                    backgroundColor: '#c084fc'
                  }}
                  whileTap={{ scale: 0.9 }}
                  className="bg-gray-700 text-gray-300 hover:text-white p-2 rounded-full transition-all duration-300"
                  aria-label={social.label}
                >
                  <social.icon className="w-4 h-4" />
                </motion.a>
              ))}
            </motion.div>
          </motion.div>

          {/* Links Sections */}
          {footerSections.map((section) => (
            <motion.div
              key={section.title}
              initial={{ opacity: 0, y: 30 }}
              whileInView={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6 }}
              className="lg:col-span-1"
            >
              <h4 className="text-lg font-semibold mb-6 text-white">
                {section.title}
              </h4>
              <ul className="space-y-3">
                {section.links.map((link) => (
                  <motion.li key={link}>
                    <motion.a
                      href="#"
                      whileHover={{ x: 5, color: '#c084fc' }}
                      transition={{ duration: 0.2 }}
                      className="text-gray-300 hover:text-purple-300 text-sm transition-colors duration-300 block"
                    >
                      {link}
                    </motion.a>
                  </motion.li>
                ))}
              </ul>
            </motion.div>
          ))}
        </div>

        {/* Newsletter Section */}
        <motion.div
          initial={{ opacity: 0, y: 30 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.6, delay: 0.4 }}
          className="mt-12 pt-8 border-t border-gray-700"
        >
          <div className="flex flex-col lg:flex-row items-center justify-between gap-6">
            <div className="flex-1">
              <h4 className="text-xl font-semibold mb-2">
                Fique por dentro das novidades
              </h4>
              <p className="text-gray-300">
                Receba dicas e inspirações para seu próximo evento
              </p>
            </div>
            
            <motion.div
              whileHover={{ scale: 1.02 }}
              className="flex flex-col sm:flex-row gap-3 w-full lg:w-auto"
            >
              <input
                type="email"
                placeholder="Seu melhor e-mail"
                className="px-4 py-3 rounded-lg bg-gray-800 border border-gray-700 text-white placeholder-gray-400 focus:outline-none focus:border-purple-500 focus:ring-1 focus:ring-purple-500 flex-1 min-w-0"
              />
              <motion.button
                whileHover={{ scale: 1.05 }}
                whileTap={{ scale: 0.95 }}
                className="bg-gradient-to-r from-purple-600 to-blue-600 px-6 py-3 rounded-lg font-semibold hover:shadow-lg transition-all duration-300 whitespace-nowrap"
              >
                Inscrever
              </motion.button>
            </motion.div>
          </div>
        </motion.div>
      </div>

      {/* Bottom Footer */}
      <div className="border-t border-gray-800">
        <div className="container mx-auto px-6 py-6">
          <div className="flex flex-col md:flex-row items-center justify-between gap-4">
            {/* Copyright */}
            <motion.div
              initial={{ opacity: 0 }}
              whileInView={{ opacity: 1 }}
              className="flex items-center space-x-2 text-gray-400 text-sm"
            >
              <span>© {currentYear} Kairos Events. Todos os direitos reservados.</span>
              <HiHeart className="w-4 h-4 text-red-500" />
            </motion.div>

            {/* Additional Links */}
            <motion.div
              initial={{ opacity: 0 }}
              whileInView={{ opacity: 1 }}
              className="flex space-x-6 text-sm text-gray-400"
            >
              <motion.a
                href="#"
                whileHover={{ color: '#c084fc' }}
                className="hover:text-purple-400 transition-colors duration-300"
              >
                Privacidade
              </motion.a>
              <motion.a
                href="#"
                whileHover={{ color: '#c084fc' }}
                className="hover:text-purple-400 transition-colors duration-300"
              >
                Termos
              </motion.a>
              <motion.a
                href="#"
                whileHover={{ color: '#c084fc' }}
                className="hover:text-purple-400 transition-colors duration-300"
              >
                Cookies
              </motion.a>
            </motion.div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;