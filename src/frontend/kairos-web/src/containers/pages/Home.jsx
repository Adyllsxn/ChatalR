import React from 'react';
import InspirationalSlider from '../pages/home/InspirationalSlider';
import ChurchMap from '../pages/home/ChurchMap';

import './Home.css';
import videoSrc from '../../assets/videos/background.mp4';


export default function Home() {
    return (
        <main>

            {/* HERO */}
            <section className='hero'>
                <div className='hero-section'>
                    <div id="hero-background">
                        <video loop autoPlay muted>
                            <source src={videoSrc} type="video/mp4" />
                        </video>
                    </div>
                    <div className='layout-container'>
                        <div className='hero-content'>
                            <h1>
                                Onde experiências inesquecíveis com Deus são organizadas com excelência
                            </h1>
                            <p>
                                A plataforma Kairos une tecnologia, propósito e fé para transformar a gestão de cultos e eventos.
                            </p>
                            <div>
                                <a href="#" className='cta-button'>Descubra o Kairos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            {/* WELCOME */}
            <section className='welcome-section'>
                <div className='layout-container'>
                    <div className='welcome-content'>
                        <div className='welcome-text'>
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
            <section className='cards-section'>
                <div className='layout-container'>
                    <div className='cards-grid'>
                        <div className='card'>
                            <h1>Fique por dentro</h1>
                            <p>
                                Confira toda a programação atualizada dos cultos, encontros e eventos especiais da igreja.
                            </p>
                        </div>
                        <div className='card'>
                            <h1>Participe facilmente</h1>
                            <p>
                                Inscreva-se e acompanhe sua participação de forma prática e rápida pelo sistema.
                            </p>
                        </div>
                        <div className='card'>
                            <h1>Seu espaço pessoal</h1>
                            <p>
                                Gerencie seus dados, veja suas inscrições e mantenha tudo organizado em um só lugar.
                            </p>
                        </div>
                    </div>
                </div>
            </section>

            {/* MAPA DA IGREJA */}
            <ChurchMap />
            
            {/* SLIDE DE FRASES */}
            <InspirationalSlider />

        </main>
    )
}
