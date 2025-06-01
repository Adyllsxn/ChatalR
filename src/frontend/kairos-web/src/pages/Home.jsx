import React from 'react'
import '../styles/Home.css'
import videoSrc from '..//assets/videos/background.mp4';

export default function Home() {
    return (
        <main>

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

            <section className='welcome-section'>
                <div className='layout-container'>
                    <div className='welcome-content'>
                        <div className='welcome-text'>
                            <h1>Seja bem-vindo a Igreja Sossego em Cristo!</h1>
                            <p>
                                Participar de uma comunidade é um dos melhores caminhos para encorajar o crescimento espiritual. Através dos Grupos da cidade, faixas etárias, discipulado e ministérios, você terá a oportunidade de se conectar e crescer em seu relacionamento com Cristo. Vem com a gente!
                            </p>
                        </div>
                        <div className='welcome-buttons'>
                            <a href="#">Programação</a>
                            <a href="#">Programação</a>
                            <a href="#">Programação</a>
                        </div>
                    </div>
                </div>
            </section>

            <section className='cards-section'>
                <div className='layout-container'>
                    <div className='cards-grid'>
                        <div className='card'>
                            <h1> Para Empresas</h1>
                            <p>
                                Por apenas R$ 9,90/ mês por colaborador, tenha acesso a todos os conteúdos do nosso catálogo no Intersaberes Play. Monte o curso que mais se adequa à sua realidade em quase 60 áreas. 
                            </p>
                        </div>
                        <div className='card'>
                            <h1> Para Empresas</h1>
                            <p>
                                Por apenas R$ 9,90/ mês por colaborador, tenha acesso a todos os conteúdos do nosso catálogo no Intersaberes Play. Monte o curso que mais se adequa à sua realidade em quase 60 áreas. 
                            </p>
                        </div>
                        <div className='card'>
                            <h1> Para Empresas</h1>
                            <p>
                                Por apenas R$ 9,90/ mês por colaborador, tenha acesso a todos os conteúdos do nosso catálogo no Intersaberes Play. Monte o curso que mais se adequa à sua realidade em quase 60 áreas. 
                            </p>
                        </div>
                    </div>
                </div>
            </section>

        </main>
    )
}