import { useEffect } from 'react';
import { motion } from 'framer-motion';
import AOS from 'aos';
import 'aos/dist/aos.css';

import videoSrc from '../../../../core/assets/videos/background.mp4';
import ChurchMap from '../ChurchMap/ChurchMap';
import InspirationalSlider from '../Inspirational/InspirationalSlider';
import styles from './Home.module.css';
import { Link } from 'react-router-dom';

const Home = () => {
  useEffect(() => {
    AOS.init({ duration: 1000 });
  }, []);

  return (
    <main>
      {/* HERO */}
      <section className={styles.hero}>
        <div className="heroSection">
          <div className={styles.heroBackground}>
            <video loop autoPlay muted>
              <source src={videoSrc} type="video/mp4" />
            </video>
          </div>
          <div className="layoutContainer">
            <motion.div
              className={styles.heroContent}
              initial={{ opacity: 0, y: 60 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 1 }}
            >
              <h1>
                Onde experiências inesquecíveis com Deus são organizadas com excelência
              </h1>
              <p>
                A plataforma Kairos une tecnologia, propósito e fé para transformar a gestão de cultos e eventos.
              </p>
              <motion.div
                whileHover={{ scale: 1.05 }}
                whileTap={{ scale: 0.95 }}
              >
                <Link to='/eventoList' className={styles.btnDescubra}>Veja os Eventos</Link>
              </motion.div>
            </motion.div>
          </div>
        </div>
      </section>

      {/* WELCOME */}
      <section className={styles.welcomeSection}>
        <div className="layoutContainer">
          <div className={styles.welcomeContent}>
            <div className={styles.welcomeText} data-aos="fade-up">
              <h1>Bem-vindo ao Kairos</h1>
              <p>
                Aqui você pode consultar facilmente todos os eventos da igreja, desde cultos regulares até encontros especiais, conferências e projetos de ministério.
                Acompanhe suas inscrições, participe ativamente e mantenha-se conectado com a comunidade.
                Também poderá gerenciar seu perfil e receber notificações sobre novidades e mudanças na programação.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* CARDS */}
      <section className={styles.cardsSection}>
        <div className="layoutContainer">
          <div className={styles.cardsGrid}>
            <div className={styles.card} data-aos="zoom-in">
              <h1>Fique por dentro</h1>
              <p>
                Confira toda a programação atualizada dos cultos, encontros e eventos especiais da igreja.
              </p>
            </div>
            <div className={styles.card} data-aos="zoom-in" data-aos-delay="150">
              <h1>Participe facilmente</h1>
              <p>
                Inscreva-se e acompanhe sua participação de forma prática e rápida pelo sistema.
              </p>
            </div>
            <div className={styles.card} data-aos="zoom-in" data-aos-delay="300">
              <h1>Seu espaço pessoal</h1>
              <p>
                Gerencie seus dados, veja suas inscrições e mantenha tudo organizado em um só lugar.
              </p>
            </div>
          </div>
        </div>
      </section>

      {/* MAPA DA IGREJA */}
      <div data-aos="fade-up">
        <ChurchMap />
      </div>

      {/* SLIDE DE FRASES */}
      <motion.div
        initial={{ opacity: 0 }}
        whileInView={{ opacity: 1 }}
        transition={{ duration: 1 }}
      >
        <InspirationalSlider />
      </motion.div>
    </main>
  );
};

export default Home;
