import { useEffect } from 'react';
import { motion } from 'framer-motion';
import AOS from 'aos';
import 'aos/dist/aos.css';
import { Link } from 'react-router-dom';
import { homeStyles } from './styles';

import videoSrc from '@/assets/videos/background.mp4';

const Home = () => {
  useEffect(() => {
    AOS.init({ 
      duration: 1200,
      once: true,
      offset: 100
    });
  }, []);

  return (
    <main className="overflow-hidden">
      {/* HERO SECTION - MODERNIZADO */}
      <section className={homeStyles.hero}>
        <div className={homeStyles.heroSection}>
          <div className={homeStyles.heroBackground}>
            <video 
              loop 
              autoPlay 
              muted 
              playsInline
              className={homeStyles.heroVideo}
            >
              <source src={videoSrc} type="video/mp4" />
            </video>
            <div className={homeStyles.heroOverlay}></div>
            <div className={homeStyles.heroGradient}></div>
          </div>
          
          <div className={homeStyles.layoutContainer}>
            <motion.div
              className={homeStyles.heroContent}
              initial={{ opacity: 0, y: 80 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 1.2, ease: "easeOut" }}
            >
              <motion.h1 
                className={homeStyles.heroTitle}
                initial={{ opacity: 0, y: 30 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: 0.3, duration: 0.8 }}
              >
                Onde experiências <span className={homeStyles.heroHighlight}>inesquecíveis</span> com Deus são organizadas
              </motion.h1>
              
              <motion.p 
                className={homeStyles.heroSubtitle}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: 0.6, duration: 0.8 }}
              >
                A plataforma Kairos une <strong>tecnologia</strong>, <strong>propósito</strong> e <strong>fé</strong> para transformar a gestão de cultos e eventos em experiências divinas.
              </motion.p>
              
              <motion.div
                className={homeStyles.heroButtonWrapper}
                initial={{ opacity: 0, y: 20 }}
                animate={{ opacity: 1, y: 0 }}
                transition={{ delay: 0.9, duration: 0.8 }}
              >
                <motion.div
                  whileHover={{ scale: 1.05 }}
                  whileTap={{ scale: 0.95 }}
                >
                  <Link to='/eventoList' className={homeStyles.heroButton}>
                    <span>Explorar Eventos</span>
                    <svg className="w-5 h-5 ml-2" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                      <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M13 7l5 5m0 0l-5 5m5-5H6" />
                    </svg>
                  </Link>
                </motion.div>
                
                <motion.div
                  whileHover={{ scale: 1.05 }}
                  whileTap={{ scale: 0.95 }}
                >
                  <Link to='/sobre' className={homeStyles.heroButtonSecondary}>
                    <span>Conheça Mais</span>
                  </Link>
                </motion.div>
              </motion.div>

              {/* Scroll Indicator */}
              <motion.div 
                className={homeStyles.scrollIndicator}
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                transition={{ delay: 1.5 }}
              >
                <div className={homeStyles.scrollArrow}></div>
              </motion.div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* FEATURES SECTION - NOVA */}
      <section className={homeStyles.featuresSection}>
        <div className={homeStyles.layoutContainer}>
          <motion.div 
            className={homeStyles.sectionHeader}
            data-aos="fade-up"
          >
            <h2 className={homeStyles.sectionTitle}>Por que escolher o Kairos?</h2>
            <p className={homeStyles.sectionSubtitle}>
              Uma plataforma desenvolvida para elevar sua experiência espiritual através da tecnologia
            </p>
          </motion.div>

          <div className={homeStyles.featuresGrid}>
            {/* Feature 1 */}
            <motion.div 
              className={homeStyles.featureCard}
              data-aos="fade-up"
              data-aos-delay="100"
              whileHover={{ y: -10, transition: { duration: 0.3 } }}
            >
              <div className={homeStyles.featureIcon}>
                <svg className="w-12 h-12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z" />
                </svg>
              </div>
              <h3 className={homeStyles.featureTitle}>Agenda Inteligente</h3>
              <p className={homeStyles.featureDescription}>
                Acesse todos os eventos da igreja em um só lugar. Cultos, encontros e atividades especiais organizadas de forma clara.
              </p>
            </motion.div>

            {/* Feature 2 */}
            <motion.div 
              className={homeStyles.featureCard}
              data-aos="fade-up"
              data-aos-delay="200"
              whileHover={{ y: -10, transition: { duration: 0.3 } }}
            >
              <div className={homeStyles.featureIcon}>
                <svg className="w-12 h-12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
                </svg>
              </div>
              <h3 className={homeStyles.featureTitle}>Perfil Personalizado</h3>
              <p className={homeStyles.featureDescription}>
                Gerencie suas inscrições, preferências e mantenha-se conectado com a comunidade de forma personalizada.
              </p>
            </motion.div>

            {/* Feature 3 */}
            <motion.div 
              className={homeStyles.featureCard}
              data-aos="fade-up"
              data-aos-delay="300"
              whileHover={{ y: -10, transition: { duration: 0.3 } }}
            >
              <div className={homeStyles.featureIcon}>
                <svg className="w-12 h-12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={1.5} d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9" />
                </svg>
              </div>
              <h3 className={homeStyles.featureTitle}>Notificações em Tempo Real</h3>
              <p className={homeStyles.featureDescription}>
                Receba alertas sobre novos eventos, mudanças na programação e lembretes importantes diretamente no seu dispositivo.
              </p>
            </motion.div>
          </div>
        </div>
      </section>

      {/* CTA SECTION - NOVA */}
      <section className={homeStyles.ctaSection}>
        <div className={homeStyles.ctaBackground}></div>
        <div className={homeStyles.layoutContainer}>
          <motion.div 
            className={homeStyles.ctaContent}
            data-aos="zoom-in"
          >
            <h2 className={homeStyles.ctaTitle}>
              Pronto para viver experiências transformadoras?
            </h2>
            <p className={homeStyles.ctaDescription}>
              Junte-se à nossa comunidade e descubra eventos que vão fortalecer sua fé e conectar você com Deus.
            </p>
            <motion.div
              whileHover={{ scale: 1.05 }}
              whileTap={{ scale: 0.95 }}
            >
              <Link to="/cadastro" className={homeStyles.ctaButton}>
                Começar Agora
              </Link>
            </motion.div>
          </motion.div>
        </div>
      </section>

      {/* STATS SECTION - NOVA */}
      <section className={homeStyles.statsSection}>
        <div className={homeStyles.layoutContainer}>
          <div className={homeStyles.statsGrid}>
            <motion.div 
              className={homeStyles.statItem}
              data-aos="fade-up"
              data-aos-delay="100"
            >
              <div className={homeStyles.statNumber}>500+</div>
              <div className={homeStyles.statLabel}>Eventos Realizados</div>
            </motion.div>
            
            <motion.div 
              className={homeStyles.statItem}
              data-aos="fade-up"
              data-aos-delay="200"
            >
              <div className={homeStyles.statNumber}>2K+</div>
              <div className={homeStyles.statLabel}>Membros Ativos</div>
            </motion.div>
            
            <motion.div 
              className={homeStyles.statItem}
              data-aos="fade-up"
              data-aos-delay="300"
            >
              <div className={homeStyles.statNumber}>98%</div>
              <div className={homeStyles.statLabel}>Satisfação</div>
            </motion.div>
            
            <motion.div 
              className={homeStyles.statItem}
              data-aos="fade-up"
              data-aos-delay="400"
            >
              <div className={homeStyles.statNumber}>24/7</div>
              <div className={homeStyles.statLabel}>Disponível</div>
            </motion.div>
          </div>
        </div>
      </section>
    </main>
  );
};

export default Home;