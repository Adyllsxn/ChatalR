import { motion } from 'framer-motion';
import { useState } from 'react';
import { 
  HiCalendar, 
  HiLocationMarker, 
  HiUsers,
  HiClock,
  HiFilter,
  HiEye,
  HiX
} from 'react-icons/hi';

// Tipos de eventos
type EventType = {
  id: number;
  title: string;
  description: string;
  date: string;
  time: string;
  location: string;
  attendees: string;
  image: string;
  category: string;
  price: string;
  featured: boolean;
};

const Events = () => {
  const [activeFilter, setActiveFilter] = useState('all');
  const [selectedEvent, setSelectedEvent] = useState<EventType | null>(null);

  const events: EventType[] = [
    {
      id: 1,
      title: 'Casamento Verão 2024',
      description: 'Celebração de amor à beira-mar com decoração tropical e música ao vivo. Um evento que uniu tradição e modernidade em um cenário paradisíaco.',
      date: '15 Dez 2024',
      time: '16:00 - 23:00',
      location: 'Praia do Forte, Bahia',
      attendees: '150 convidados',
      image: 'https://images.unsplash.com/photo-1519225421980-715cb0215aed?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'casamento',
      price: 'Premium',
      featured: true
    },
    {
      id: 2,
      title: 'Conferência Tech Innovation',
      description: 'Maior evento de tecnologia do ano com palestrantes internacionais e showcases das últimas inovações do mercado.',
      date: '20 Jan 2025',
      time: '09:00 - 18:00',
      location: 'Centro de Convenções, SP',
      attendees: '500 participantes',
      image: 'https://images.unsplash.com/photo-1540575467063-178a50c2df87?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'corporativo',
      price: 'Profissional',
      featured: true
    },
    {
      id: 3,
      title: 'Festa de 15 Anos Sophia',
      description: 'Celebração mágica com tema conto de fadas, show de luzes sincronizado e coreografias especiais preparadas durante meses.',
      date: '08 Nov 2024',
      time: '19:00 - 02:00',
      location: 'Salão de Festas Elite, RJ',
      attendees: '120 convidados',
      image: 'https://images.unsplash.com/photo-1530103862676-de8c9debad1d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'aniversario',
      price: 'Luxo',
      featured: false
    },
    {
      id: 4,
      title: 'Formatura Medicina 2024',
      description: 'Cerimônia de colação de grau seguida de baile de gala em um dos teatros mais tradicionais do país. Momentos de emoção e celebração.',
      date: '05 Dez 2024',
      time: '18:00 - 23:00',
      location: 'Teatro Municipal, BH',
      attendees: '200 formandos',
      image: 'https://images.unsplash.com/photo-1541336032412-2048a678540d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'formatura',
      price: 'Executivo',
      featured: false
    },
    {
      id: 5,
      title: 'Show Nacional de Rock',
      description: 'Festival com bandas nacionais consagradas e estrutura completa de som e luz de última geração. 8 horas de pura energia.',
      date: '12 Mar 2025',
      time: '14:00 - 22:00',
      location: 'Arena Music Park, PR',
      attendees: '5000 pessoas',
      image: 'https://images.unsplash.com/photo-1459749411175-04bf5292ceea?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'show',
      price: 'Popular',
      featured: true
    },
    {
      id: 6,
      title: 'Lançamento Corporativo',
      description: 'Evento exclusivo para lançamento de novo produto com coquetel gourmet e networking entre executivos do setor.',
      date: '30 Nov 2024',
      time: '19:00 - 22:00',
      location: 'Hotel Premium, SP',
      attendees: '80 executivos',
      image: 'https://images.unsplash.com/photo-1492684223066-81342ee5ff30?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80',
      category: 'corporativo',
      price: 'Business',
      featured: false
    }
  ];

  const categories = [
    { key: 'all', label: 'Todos os Eventos' },
    { key: 'casamento', label: 'Casamentos' },
    { key: 'corporativo', label: 'Corporativos' },
    { key: 'aniversario', label: 'Aniversários' },
    { key: 'formatura', label: 'Formaturas' },
    { key: 'show', label: 'Shows & Festas' }
  ];

  // Fallback image para quando uma imagem não carregar
  const fallbackImage = 'https://images.unsplash.com/photo-1541336032412-2048a678540d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80';

  const handleImageError = (e: React.SyntheticEvent<HTMLImageElement, Event>) => {
    e.currentTarget.src = fallbackImage;
  };

  const filteredEvents = activeFilter === 'all' 
    ? events 
    : events.filter(event => event.category === activeFilter);

  return (
    <section id="eventos" className="py-20 bg-white relative overflow-hidden">
      {/* Background Elements */}
      <div className="absolute top-0 left-0 w-64 h-64 bg-purple-100 rounded-full blur-3xl opacity-30" />
      <div className="absolute bottom-0 right-0 w-96 h-96 bg-blue-100 rounded-full blur-3xl opacity-20" />
      
      <div className="container mx-auto px-6 relative z-10">
        {/* Header Section */}
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8 }}
          className="text-center mb-16"
        >
          <motion.span
            initial={{ opacity: 0 }}
            whileInView={{ opacity: 1 }}
            transition={{ delay: 0.2 }}
            className="text-purple-600 font-semibold text-lg mb-4 block"
          >
            NOSSOS EVENTOS
          </motion.span>
          <h2 className="text-4xl md:text-5xl font-bold text-gray-800 mb-6">
            Portfólio de <span className="text-purple-600">Realizações</span>
          </h2>
          <p className="text-xl text-gray-600 max-w-3xl mx-auto">
            Confira alguns dos eventos incríveis que realizamos e inspire-se 
            para criar a sua celebração perfeita
          </p>
        </motion.div>

        {/* Filter Buttons */}
        <motion.div
          initial={{ opacity: 0, y: 30 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.6, delay: 0.3 }}
          className="flex flex-wrap justify-center gap-4 mb-12"
        >
          {categories.map((category) => (
            <motion.button
              key={category.key}
              onClick={() => setActiveFilter(category.key)}
              whileHover={{ scale: 1.05 }}
              whileTap={{ scale: 0.95 }}
              className={`px-6 py-3 rounded-full font-semibold transition-all duration-300 flex items-center space-x-2 ${
                activeFilter === category.key
                  ? 'bg-gradient-to-r from-purple-600 to-blue-600 text-white shadow-lg'
                  : 'bg-gray-100 text-gray-600 hover:bg-gray-200'
              }`}
            >
              <HiFilter className="w-4 h-4" />
              <span>{category.label}</span>
            </motion.button>
          ))}
        </motion.div>

        {/* Events Grid */}
        <motion.div
          initial={{ opacity: 0 }}
          whileInView={{ opacity: 1 }}
          transition={{ duration: 0.8, delay: 0.5 }}
          className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8"
        >
          {filteredEvents.map((event, index) => (
            <motion.div
              key={event.id}
              initial={{ opacity: 0, y: 30 }}
              whileInView={{ opacity: 1, y: 0 }}
              whileHover={{ y: -10, scale: 1.02 }}
              transition={{ duration: 0.5, delay: index * 0.1 }}
              className="bg-white rounded-2xl shadow-lg hover:shadow-xl border border-gray-100 overflow-hidden group cursor-pointer"
              onClick={() => setSelectedEvent(event)}
            >
              {/* Event Image */}
              <div className="relative h-48 overflow-hidden">
                <img
                  src={event.image}
                  alt={event.title}
                  className="w-full h-full object-cover group-hover:scale-110 transition-transform duration-500"
                  onError={handleImageError}
                  loading="lazy"
                />
                
                {/* Featured Badge */}
                {event.featured && (
                  <motion.div
                    initial={{ scale: 0 }}
                    whileInView={{ scale: 1 }}
                    className="absolute top-4 left-4 bg-gradient-to-r from-yellow-400 to-orange-500 text-white px-3 py-1 rounded-full text-sm font-semibold shadow-lg"
                  >
                    ⭐ Destaque
                  </motion.div>
                )}
                
                {/* Price Badge */}
                <motion.div
                  initial={{ scale: 0 }}
                  whileInView={{ scale: 1 }}
                  transition={{ delay: 0.2 }}
                  className="absolute top-4 right-4 bg-white/90 backdrop-blur-sm text-gray-800 px-3 py-1 rounded-full text-sm font-semibold shadow-sm"
                >
                  {event.price}
                </motion.div>
                
                {/* Overlay */}
                <div className="absolute inset-0 bg-black/0 group-hover:bg-black/20 transition-all duration-300 flex items-center justify-center">
                  <motion.div
                    initial={{ opacity: 0, scale: 0 }}
                    whileHover={{ opacity: 1, scale: 1 }}
                    className="bg-white/90 backdrop-blur-sm p-3 rounded-full shadow-lg"
                  >
                    <HiEye className="w-6 h-6 text-purple-600" />
                  </motion.div>
                </div>
              </div>

              {/* Event Content */}
              <div className="p-6">
                <h3 className="text-xl font-bold text-gray-800 mb-3 group-hover:text-purple-600 transition-colors duration-300">
                  {event.title}
                </h3>
                <p className="text-gray-600 text-sm mb-4 line-clamp-2 leading-relaxed">
                  {event.description}
                </p>

                {/* Event Details */}
                <div className="space-y-2">
                  <div className="flex items-center space-x-3 text-sm text-gray-500">
                    <HiCalendar className="w-4 h-4 text-purple-500 flex-shrink-0" />
                    <span>{event.date}</span>
                  </div>
                  <div className="flex items-center space-x-3 text-sm text-gray-500">
                    <HiClock className="w-4 h-4 text-blue-500 flex-shrink-0" />
                    <span>{event.time}</span>
                  </div>
                  <div className="flex items-center space-x-3 text-sm text-gray-500">
                    <HiLocationMarker className="w-4 h-4 text-red-500 flex-shrink-0" />
                    <span className="flex-1 line-clamp-1">{event.location}</span>
                  </div>
                  <div className="flex items-center space-x-3 text-sm text-gray-500">
                    <HiUsers className="w-4 h-4 text-green-500 flex-shrink-0" />
                    <span>{event.attendees}</span>
                  </div>
                </div>
              </div>
            </motion.div>
          ))}
        </motion.div>

        {/* CTA Section */}
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8, delay: 0.7 }}
          className="text-center mt-16"
        >
          <div className="bg-gradient-to-r from-purple-50 to-blue-50 rounded-3xl p-12 border border-purple-100">
            <h3 className="text-3xl font-bold text-gray-800 mb-4">
              Pronto para criar seu evento dos sonhos?
            </h3>
            <p className="text-gray-600 text-lg mb-8 max-w-2xl mx-auto">
              Entre em contato conosco e vamos juntos transformar sua ideia 
              em uma experiência inesquecível
            </p>
            <motion.button
              whileHover={{ scale: 1.05 }}
              whileTap={{ scale: 0.95 }}
              className="bg-gradient-to-r from-purple-600 to-blue-600 text-white px-8 py-4 rounded-full font-semibold hover:shadow-lg transition-all duration-300"
            >
              Solicitar Orçamento
            </motion.button>
          </div>
        </motion.div>
      </div>

      {/* Event Modal */}
      {selectedEvent && (
        <motion.div
          initial={{ opacity: 0 }}
          animate={{ opacity: 1 }}
          exit={{ opacity: 0 }}
          className="fixed inset-0 bg-black/50 flex items-center justify-center z-50 p-4"
          onClick={() => setSelectedEvent(null)}
        >
          <motion.div
            initial={{ scale: 0.8, opacity: 0 }}
            animate={{ scale: 1, opacity: 1 }}
            exit={{ scale: 0.8, opacity: 0 }}
            transition={{ type: "spring", damping: 25 }}
            className="bg-white rounded-3xl max-w-4xl w-full max-h-[90vh] overflow-hidden shadow-2xl"
            onClick={(e) => e.stopPropagation()}
          >
            {/* Modal Header with Image */}
            <div className="relative h-64 md:h-80">
              <img
                src={selectedEvent.image}
                alt={selectedEvent.title}
                className="w-full h-full object-cover"
                onError={handleImageError}
              />
              <button
                onClick={() => setSelectedEvent(null)}
                className="absolute top-4 right-4 bg-white/90 backdrop-blur-sm p-2 rounded-full hover:bg-white transition-colors shadow-lg"
              >
                <HiX className="w-5 h-5 text-gray-600" />
              </button>
              
              {/* Overlay Info */}
              <div className="absolute bottom-0 left-0 right-0 bg-gradient-to-t from-black/60 to-transparent p-6">
                <h3 className="text-2xl md:text-3xl font-bold text-white mb-2">
                  {selectedEvent.title}
                </h3>
                <div className="flex flex-wrap gap-4 text-white/90">
                  {selectedEvent.featured && (
                    <span className="bg-yellow-500 text-white px-3 py-1 rounded-full text-sm font-semibold">
                      Evento em Destaque
                    </span>
                  )}
                  <span className="bg-white/20 backdrop-blur-sm px-3 py-1 rounded-full text-sm">
                    {selectedEvent.price}
                  </span>
                </div>
              </div>
            </div>

            {/* Modal Content */}
            <div className="p-6 md:p-8">
              <p className="text-gray-600 text-lg mb-6 leading-relaxed">
                {selectedEvent.description}
              </p>

              {/* Event Details Grid */}
              <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-6">
                <div className="space-y-4">
                  <div className="flex items-center space-x-3">
                    <HiCalendar className="w-5 h-5 text-purple-600 flex-shrink-0" />
                    <div>
                      <div className="text-sm text-gray-500">Data</div>
                      <div className="font-semibold text-gray-800">{selectedEvent.date}</div>
                    </div>
                  </div>
                  <div className="flex items-center space-x-3">
                    <HiClock className="w-5 h-5 text-blue-600 flex-shrink-0" />
                    <div>
                      <div className="text-sm text-gray-500">Horário</div>
                      <div className="font-semibold text-gray-800">{selectedEvent.time}</div>
                    </div>
                  </div>
                </div>
                <div className="space-y-4">
                  <div className="flex items-center space-x-3">
                    <HiLocationMarker className="w-5 h-5 text-red-600 flex-shrink-0" />
                    <div>
                      <div className="text-sm text-gray-500">Localização</div>
                      <div className="font-semibold text-gray-800">{selectedEvent.location}</div>
                    </div>
                  </div>
                  <div className="flex items-center space-x-3">
                    <HiUsers className="w-5 h-5 text-green-600 flex-shrink-0" />
                    <div>
                      <div className="text-sm text-gray-500">Participantes</div>
                      <div className="font-semibold text-gray-800">{selectedEvent.attendees}</div>
                    </div>
                  </div>
                </div>
              </div>

              {/* CTA Button */}
              <div className="flex justify-center pt-4">
                <motion.button
                  whileHover={{ scale: 1.05 }}
                  whileTap={{ scale: 0.95 }}
                  className="bg-gradient-to-r from-purple-600 to-blue-600 text-white px-8 py-3 rounded-full font-semibold hover:shadow-lg transition-all duration-300"
                >
                  Quero um Evento Assim
                </motion.button>
              </div>
            </div>
          </motion.div>
        </motion.div>
      )}
    </section>
  );
};

export default Events;