import videoSrc from '../../core/assets/videos/background.mp4';
import styles from './Home.module.css'

const Home = () => {
    return (
        <>
            <main>
                {/* HERO */}
                <section className={styles.hero}>
                    <div className='heroSection'>
                        <div className={styles.heroBackground}>
                            <video loop autoPlay muted>
                                <source src={videoSrc} type="video/mp4" />
                            </video>
                        </div>
                        <div className='layoutContainer'>
                            <div className={styles.heroContent}>
                                <h1>
                                    Onde experiências inesquecíveis com Deus são organizadas com excelência
                                </h1>
                                <p>
                                    A plataforma Kairos une tecnologia, propósito e fé para transformar a gestão de cultos e eventos.
                                </p>
                                <div>
                                    <a href="#" className={styles.btnDescubra}>Descubra o Kairos</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </main>
        </>
    )
};

export default Home;