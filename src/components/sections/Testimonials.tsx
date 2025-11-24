import { motion } from 'framer-motion';
import { useState, useRef, useEffect } from 'react';
import { 
  HiStar, 
  HiChevronLeft, 
  HiChevronRight,
  HiPlay,
  HiPause
} from 'react-icons/hi';

type Testimonial = {
  id: number;
  name: string;
  role: string;
  company: string;
  event: string;
  rating: number;
  text: string;
  image: string;
  video?: string;
};

const Testimonials = () => {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [isPlaying, setIsPlaying] = useState(true);
  const autoPlayRef = useRef<number | null>(null);

  const testimonials: Testimonial[] = [
    {
      id: 1,
      name: 'Ana Silva',
      role: 'Noiva',
      company: 'Casamento Verão',
      event: 'Casamento à Beira-Mar',
      rating: 5,
      text: 'A Kairos transformou nosso sonho em realidade! Cada detalhe foi perfeito, desde a decoração até a organização do cerimonial. Nossos convidados ainda comentam sobre como foi o casamento mais lindo que já participaram.',
      image: 'https://images.unsplash.com/photo-1494790108755-2616b612b786?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 2,
      name: 'Carlos Mendes',
      role: 'CEO',
      company: 'Tech Solutions',
      event: 'Conferência Anual',
      rating: 5,
      text: 'Profissionalismo impressionante! A equipe da Kairos cuidou de cada aspecto do nosso evento corporativo. O resultado superou todas as expectativas e recebemos elogios de todos os participantes.',
      image: 'https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 3,
      name: 'Marina Oliveira',
      role: 'Mãe da Aniversariante',
      company: 'Festa de 15 Anos',
      event: 'Baile de Debutante',
      rating: 5,
      text: 'Foi mágico! Minha filha ficou encantada com cada detalhe. A equipe foi super atenciosa e tudo saiu exatamente como planejamos. Recomendo a Kairos para quem busca excelência e criatividade.',
      image: 'https://images.unsplash.com/photo-1438761681033-6461ffad8d80?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 4,
      name: 'Roberto Santos',
      role: 'Diretor de Marketing',
      company: 'Global Corp',
      event: 'Lançamento de Produto',
      rating: 5,
      text: 'Trabalhamos com a Kairos em múltiplos eventos e sempre superam nossas expectativas. A capacidade de inovação e atenção aos detalhes faz toda a diferença. Parceiros de confiança!',
      image: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 5,
      name: 'Juliana Costa',
      role: 'Coordenadora',
      company: 'Universidade Federal',
      event: 'Cerimônia de Formatura',
      rating: 5,
      text: 'Organizamos a formatura de 200 alunos e a Kairos foi fundamental para o sucesso do evento. Tudo ocorreu perfeitamente, desde a cerimônia até a festa. Profissionais incríveis!',
      image: 'https://images.unsplash.com/photo-1544725176-7c40e5a71c5e?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    },
    {
      id: 6,
      name: 'Fernando Lima',
      role: 'Produtor Musical',
      company: 'SoundWave Events',
      event: 'Festival de Verão',
      rating: 5,
      text: 'A parceria com a Kairos no nosso festival foi excepcional. A logística complexa foi administrada com maestria, e o público amou a experiência. Já estamos planejando a próxima edição!',
      image: 'https://images.unsplash.com/photo-1519345182560-3f2917c472ef?ixlib=rb-4.0.3&auto=format&fit=crop&w=500&q=80'
    }
  ];

  // Auto-play functionality
  const startAutoPlay = () => {
    if (autoPlayRef.current) clearInterval(autoPlayRef.current);
    
    autoPlayRef.current = window.setInterval(() => {
      setCurrentIndex((prev) => (prev + 1) % testimonials.length);
    }, 5000);
  };

  const stopAutoPlay = () => {
    if (autoPlayRef.current) {
      clearInterval(autoPlayRef.current);
      autoPlayRef.current = null;
    }
  };

  // Navigation functions
  const nextTestimonial = () => {
    setCurrentIndex((prev) => (prev + 1) % testimonials.length);
  };

  const prevTestimonial = () => {
    setCurrentIndex((prev) => (prev - 1 + testimonials.length) % testimonials.length);
  };

  const goToTestimonial = (index: number) => {
    setCurrentIndex(index);
  };

  // Toggle auto-play
  const toggleAutoPlay = () => {
    setIsPlaying(!isPlaying);
    if (!isPlaying) {
      startAutoPlay();
    } else {
      stopAutoPlay();
    }
  };

  // Effect for auto-play
  useEffect(() => {
    if (isPlaying) {
      startAutoPlay();
    }
    return () => stopAutoPlay();
  }, [isPlaying]);

  const currentTestimonial = testimonials[currentIndex];

  return (
    <section id="depoimentos" className="py-20 bg-gradient-to-br from-gray-50 to-purple-50 relative overflow-hidden">
      {/* Background Elements */}
      <div className="absolute top-10 right-10 w-64 h-64 bg-purple-100 rounded-full blur-3xl opacity-30" />
      <div className="absolute bottom-10 left-10 w-96 h-96 bg-blue-100 rounded-full blur-3xl opacity-20" />
      
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
            DEPOIMENTOS
          </motion.span>
          <h2 className="text-4xl md:text-5xl font-bold text-gray-800 mb-6">
            O que nossos <span className="text-purple-600">clientes</span> dizem
          </h2>
          <p className="text-xl text-gray-600 max-w-3xl mx-auto">
            A satisfação dos nossos clientes é nossa maior recompensa. 
            Confira as experiências de quem já realizou seus sonhos conosco.
          </p>
        </motion.div>

        {/* Main Testimonial Card */}
        <div className="max-w-6xl mx-auto">
          <motion.div
            key={currentIndex}
            initial={{ opacity: 0, x: 100 }}
            animate={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.5 }}
            className="bg-white rounded-3xl shadow-xl border border-gray-100 overflow-hidden"
          >
            <div className="grid grid-cols-1 lg:grid-cols-2">
              {/* Testimonial Content */}
              <div className="p-8 lg:p-12 flex flex-col justify-center">
                {/* Quote Icon - usando um SVG customizado */}
                <div className="w-12 h-12 text-purple-200 mb-6">
                  <svg fill="currentColor" viewBox="0 0 24 24">
                    <path d="M4.583 17.321C3.553 16.227 3 15 3 13.011c0-3.5 2.457-6.637 6.03-8.188l.893 1.378c-3.335 1.804-3.987 4.145-4.247 5.621.537-.278 1.24-.375 1.929-.311 1.804.167 3.226 1.648 3.226 3.489a3.5 3.5 0 01-3.5 3.5c-1.073 0-2.099-.49-2.748-1.179zm10 0C13.553 16.227 13 15 13 13.011c0-3.5 2.457-6.637 6.03-8.188l.893 1.378c-3.335 1.804-3.987 4.145-4.247 5.621.537-.278 1.24-.375 1.929-.311 1.804.167 3.226 1.648 3.226 3.489a3.5 3.5 0 01-3.5 3.5c-1.073 0-2.099-.49-2.748-1.179z"/>
                  </svg>
                </div>
                
                {/* Rating Stars */}
                <div className="flex mb-6">
                  {[...Array(5)].map((_, i) => (
                    <HiStar
                      key={i}
                      className={`w-6 h-6 ${
                        i < currentTestimonial.rating
                          ? 'text-yellow-400 fill-current'
                          : 'text-gray-300'
                      }`}
                    />
                  ))}
                </div>

                {/* Testimonial Text */}
                <blockquote className="text-2xl lg:text-3xl font-light text-gray-800 mb-8 leading-relaxed">
                  "{currentTestimonial.text}"
                </blockquote>

                {/* Client Info */}
                <div className="mt-auto">
                  <div className="flex items-center space-x-4">
                    <img
                      src={currentTestimonial.image}
                      alt={currentTestimonial.name}
                      className="w-16 h-16 rounded-full object-cover border-4 border-purple-100"
                    />
                    <div>
                      <h4 className="text-xl font-bold text-gray-800">
                        {currentTestimonial.name}
                      </h4>
                      <p className="text-purple-600 font-semibold">
                        {currentTestimonial.role}
                      </p>
                      <p className="text-gray-600 text-sm">
                        {currentTestimonial.event}
                      </p>
                    </div>
                  </div>
                </div>
              </div>

              {/* Client Photo */}
              <div className="relative h-80 lg:h-auto">
                <img
                  src={currentTestimonial.image}
                  alt={currentTestimonial.name}
                  className="w-full h-full object-cover"
                />
                {/* Gradient Overlay */}
                <div className="absolute inset-0 bg-gradient-to-t from-black/20 to-transparent" />
              </div>
            </div>
          </motion.div>

          {/* Controls */}
          <div className="flex items-center justify-center space-x-6 mt-8">
            {/* Previous Button */}
            <motion.button
              onClick={prevTestimonial}
              whileHover={{ scale: 1.1 }}
              whileTap={{ scale: 0.9 }}
              className="w-12 h-12 bg-white rounded-full shadow-lg flex items-center justify-center text-gray-600 hover:text-purple-600 transition-colors"
            >
              <HiChevronLeft className="w-6 h-6" />
            </motion.button>

            {/* Play/Pause Button */}
            <motion.button
              onClick={toggleAutoPlay}
              whileHover={{ scale: 1.1 }}
              whileTap={{ scale: 0.9 }}
              className="w-12 h-12 bg-gradient-to-r from-purple-600 to-blue-600 rounded-full shadow-lg flex items-center justify-center text-white"
            >
              {isPlaying ? <HiPause className="w-5 h-5" /> : <HiPlay className="w-5 h-5" />}
            </motion.button>

            {/* Next Button */}
            <motion.button
              onClick={nextTestimonial}
              whileHover={{ scale: 1.1 }}
              whileTap={{ scale: 0.9 }}
              className="w-12 h-12 bg-white rounded-full shadow-lg flex items-center justify-center text-gray-600 hover:text-purple-600 transition-colors"
            >
              <HiChevronRight className="w-6 h-6" />
            </motion.button>
          </div>

          {/* Dots Indicator */}
          <div className="flex justify-center space-x-3 mt-8">
            {testimonials.map((_, index) => (
              <button
                key={index}
                onClick={() => goToTestimonial(index)}
                className={`w-3 h-3 rounded-full transition-all duration-300 ${
                  index === currentIndex
                    ? 'bg-purple-600 w-8'
                    : 'bg-gray-300 hover:bg-gray-400'
                }`}
              />
            ))}
          </div>

          {/* Stats Section */}
          <motion.div
            initial={{ opacity: 0, y: 50 }}
            whileInView={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.8, delay: 0.4 }}
            className="grid grid-cols-2 lg:grid-cols-4 gap-8 mt-16"
          >
            {[
              { number: '500+', label: 'Eventos Realizados' },
              { number: '50K+', label: 'Participantes Felizes' },
              { number: '98%', label: 'Taxa de Satisfação' },
              { number: '10+', label: 'Prêmios Recebidos' }
            ].map((stat, index) => (
              <motion.div
                key={stat.label}
                initial={{ opacity: 0, scale: 0.8 }}
                whileInView={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
                className="text-center"
              >
                <div className="text-3xl lg:text-4xl font-bold text-purple-600 mb-2">
                  {stat.number}
                </div>
                <div className="text-gray-600 font-medium">
                  {stat.label}
                </div>
              </motion.div>
            ))}
          </motion.div>
        </div>
      </div>
    </section>
  );
};

export default Testimonials;