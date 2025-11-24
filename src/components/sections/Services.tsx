import { motion } from 'framer-motion';
import { 
  HiHeart, 
  HiBriefcase, 
  HiAcademicCap, 
  HiMusicNote,
  HiCake,
  HiPhotograph
} from 'react-icons/hi';

const Services = () => {
  const services = [
    {
      icon: HiHeart,
      title: 'Casamentos',
      description: 'Celebramos o amor com momentos únicos e personalizados'
    },
    {
      icon: HiBriefcase,
      title: 'Corporativos',
      description: 'Eventos empresariais que impressionam e conectam'
    },
    {
      icon: HiAcademicCap,
      title: 'Formatura',
      description: 'Marcando a conquista com estilo e emoção'
    },
    {
      icon: HiMusicNote,
      title: 'Shows & Festas',
      description: 'Experiências musicais e entretenimento memorável'
    },
    {
      icon: HiCake,
      title: 'Aniversários',
      description: 'Celebrações personalizadas para todas as idades'
    },
    {
      icon: HiPhotograph,
      title: 'Produção Completa',
      description: 'Do conceito à execução, cuidamos de tudo'
    }
  ];

  return (
    <section id="servicos" className="py-20 bg-white">
      <div className="container mx-auto px-6">
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8 }}
          className="text-center mb-16"
        >
          <h2 className="text-4xl md:text-5xl font-bold text-gray-800 mb-4">
            Nossos <span className="text-purple-600">Serviços</span>
          </h2>
          <p className="text-xl text-gray-600 max-w-2xl mx-auto">
            Criamos experiências únicas para cada tipo de celebração
          </p>
        </motion.div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {services.map((service, index) => (
            <motion.div
              key={index}
              initial={{ opacity: 0, y: 30 }}
              whileInView={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6, delay: index * 0.1 }}
              whileHover={{ y: -10, scale: 1.02 }}
              className="bg-gradient-to-br from-white to-gray-50 p-8 rounded-2xl shadow-lg hover:shadow-xl border border-gray-100 transition-all duration-300"
            >
              <service.icon className="w-12 h-12 text-purple-600 mb-4" />
              <h3 className="text-xl font-bold text-gray-800 mb-3">
                {service.title}
              </h3>
              <p className="text-gray-600 leading-relaxed">
                {service.description}
              </p>
            </motion.div>
          ))}
        </div>
      </div>
    </section>
  );
};

export default Services;