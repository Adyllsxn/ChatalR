import { motion } from 'framer-motion';
import { useRef } from 'react';
import { Canvas, useFrame } from '@react-three/fiber';
import { Sphere, MeshDistortMaterial } from '@react-three/drei';
import { 
  HiCheck, 
  HiLightningBolt, 
  HiHeart, 
  HiUsers,
  HiGlobe,
  HiStar,
  HiSparkles
} from 'react-icons/hi';

// Componente 3D animado para o background
const AnimatedSphere = () => {
  const meshRef = useRef<any>(null);

  useFrame((_, delta) => {
    if (meshRef.current) {
      meshRef.current.rotation.x += delta * 0.2;
      meshRef.current.rotation.y += delta * 0.3;
    }
  });

  return (
    <Sphere ref={meshRef} scale={1.5} args={[1, 100, 200]}>
      <MeshDistortMaterial
        color="#7c3aed"
        attach="material"
        distort={0.3}
        speed={2}
        roughness={0.2}
        metalness={0.1}
      />
    </Sphere>
  );
};

const About = () => {
  const features = [
    {
      icon: HiLightningBolt,
      title: 'Soluções Criativas',
      description: 'Ideias inovadoras que transformam eventos comuns em experiências extraordinárias'
    },
    {
      icon: HiHeart,
      title: 'Paixão por Detalhes',
      description: 'Cuidamos de cada mínimo detalhe para garantir perfeição do início ao fim'
    },
    {
      icon: HiUsers,
      title: 'Equipe Especializada',
      description: 'Profissionais experientes dedicados a tornar seu evento único e memorável'
    },
    {
      icon: HiGlobe,
      title: 'Atendimento Global',
      description: 'Realizamos eventos em qualquer lugar do mundo, sempre com excelência'
    }
  ];

  const stats = [
    { number: '10+', label: 'Anos de Experiência' },
    { number: '500+', label: 'Eventos Realizados' },
    { number: '50K+', label: 'Participantes Felizes' },
    { number: '98%', label: 'Índice de Satisfação' }
  ];

  const values = [
    'Planejamento personalizado para cada cliente',
    'Transparência total no orçamento',
    'Parceria com os melhores fornecedores',
    'Sustentabilidade em todos os eventos',
    'Tecnologia de ponta na produção',
    'Suporte 24/7 durante o evento'
  ];

  return (
    <section id="sobre" className="py-20 bg-gradient-to-br from-white to-gray-50 relative overflow-hidden">
      {/* Background Elements */}
      <div className="absolute top-10 right-10 w-72 h-72 bg-purple-100 rounded-full blur-3xl opacity-30" />
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
            SOBRE NÓS
          </motion.span>
          <h2 className="text-4xl md:text-5xl font-bold text-gray-800 mb-6">
            Transformando <span className="text-purple-600">momentos</span> em 
            <span className="text-blue-600"> memórias</span>
          </h2>
          <p className="text-xl text-gray-600 max-w-3xl mx-auto leading-relaxed">
            Na Kairos Events, acreditamos que cada evento é único e merece ser tratado 
            com excelência, criatividade e atenção aos detalhes. Somos apaixonados por 
            criar experiências que ficam para sempre na memória.
          </p>
        </motion.div>

        <div className="grid grid-cols-1 lg:grid-cols-2 gap-16 items-center mb-20">
          {/* Text Content */}
          <motion.div
            initial={{ opacity: 0, x: -50 }}
            whileInView={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.8 }}
            className="space-y-8"
          >
            <div>
              <h3 className="text-3xl font-bold text-gray-800 mb-6">
                Nossa <span className="text-purple-600">Jornada</span>
              </h3>
              <p className="text-gray-600 text-lg leading-relaxed mb-6">
                Há mais de uma década no mercado, a Kairos Events nasceu da paixão 
                por unir pessoas e celebrar momentos especiais. Começamos com pequenos 
                eventos e hoje realizamos produções de grande porte em todo o Brasil.
              </p>
              <p className="text-gray-600 text-lg leading-relaxed">
                Nossa missão é simples: entender sua visão e transformá-la em realidade, 
                superando expectativas e criando experiências verdadeiramente mágicas.
              </p>
            </div>

            {/* Values List */}
            <div className="space-y-4">
              {values.map((value, index) => (
                <motion.div
                  key={value}
                  initial={{ opacity: 0, x: -20 }}
                  whileInView={{ opacity: 1, x: 0 }}
                  transition={{ duration: 0.5, delay: index * 0.1 }}
                  className="flex items-center space-x-4"
                >
                  <div className="flex-shrink-0 w-6 h-6 bg-green-500 rounded-full flex items-center justify-center">
                    <HiCheck className="w-4 h-4 text-white" />
                  </div>
                  <span className="text-gray-700 font-medium">{value}</span>
                </motion.div>
              ))}
            </div>
          </motion.div>

          {/* 3D Visual */}
          <motion.div
            initial={{ opacity: 0, x: 50 }}
            whileInView={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.8, delay: 0.2 }}
            className="h-96 lg:h-[500px] relative"
          >
            <Canvas>
              <ambientLight intensity={0.5} />
              <directionalLight position={[10, 10, 5]} intensity={1} />
              <AnimatedSphere />
            </Canvas>
            
            {/* Floating Elements */}
            <motion.div
              animate={{ 
                y: [0, -20, 0],
                rotate: [0, 5, 0]
              }}
              transition={{ 
                duration: 4,
                repeat: Infinity,
                ease: "easeInOut"
              }}
              className="absolute -top-4 -left-4 bg-white p-4 rounded-2xl shadow-lg border border-gray-100"
            >
              <HiStar className="w-8 h-8 text-yellow-500" />
            </motion.div>
            
            <motion.div
              animate={{ 
                y: [0, 15, 0],
                rotate: [0, -5, 0]
              }}
              transition={{ 
                duration: 3,
                repeat: Infinity,
                ease: "easeInOut",
                delay: 1
              }}
              className="absolute -bottom-4 -right-4 bg-white p-4 rounded-2xl shadow-lg border border-gray-100"
            >
              <HiSparkles className="w-8 h-8 text-purple-500" />
            </motion.div>
          </motion.div>
        </div>

        {/* Features Grid */}
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8, delay: 0.4 }}
          className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8 mb-20"
        >
          {features.map((feature, index) => (
            <motion.div
              key={feature.title}
              initial={{ opacity: 0, y: 30 }}
              whileInView={{ opacity: 1, y: 0 }}
              whileHover={{ y: -10, scale: 1.02 }}
              transition={{ duration: 0.5, delay: index * 0.1 }}
              className="bg-white p-8 rounded-2xl shadow-lg border border-gray-100 hover:shadow-xl transition-all duration-300 group"
            >
              <div className="w-14 h-14 bg-gradient-to-r from-purple-500 to-blue-500 rounded-2xl flex items-center justify-center mb-6 group-hover:scale-110 transition-transform duration-300">
                <feature.icon className="w-7 h-7 text-white" />
              </div>
              <h4 className="text-xl font-bold text-gray-800 mb-4">
                {feature.title}
              </h4>
              <p className="text-gray-600 leading-relaxed">
                {feature.description}
              </p>
            </motion.div>
          ))}
        </motion.div>

        {/* Stats Section */}
        <motion.div
          initial={{ opacity: 0, y: 50 }}
          whileInView={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.8, delay: 0.6 }}
          className="bg-gradient-to-r from-purple-600 to-blue-600 rounded-3xl p-12 text-center text-white"
        >
          <div className="grid grid-cols-2 lg:grid-cols-4 gap-8">
            {stats.map((stat, index) => (
              <motion.div
                key={stat.label}
                initial={{ opacity: 0, scale: 0.5 }}
                whileInView={{ opacity: 1, scale: 1 }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
                className="text-center"
              >
                <div className="text-4xl md:text-5xl font-bold mb-2">
                  {stat.number}
                </div>
                <div className="text-purple-100 font-medium">
                  {stat.label}
                </div>
              </motion.div>
            ))}
          </div>
        </motion.div>
      </div>
    </section>
  );
};

export default About;