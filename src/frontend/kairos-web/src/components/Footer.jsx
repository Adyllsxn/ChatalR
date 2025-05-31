import React from 'react'
import '../styles/Footer.css' 

export default function Footer() {
    return (
        <footer className='site-footer'>
            <div className='layout-container'>
                <div className='footer-top'>
                    <div className="footer-title">
                        <h1>Unidos para servir melhor</h1>
                    </div>
                    <div className='footer-links'>
                        <div className='footer-column'>
                            <h3>Institucional</h3>
                            <ul>
                                <li><a href="#">Sobre Nós</a></li>
                                <li><a href="#">Equipe de Desenvolvimento</a></li>
                                <li><a href="#">Contato</a></li>
                            </ul>
                        </div>
                        <div className='footer-column'>
                            <h3>Redes Socias</h3>
                            <ul>
                                <li><a href="#">Instagram</a></li>
                                <li><a href="#">FaceBook</a></li>
                                <li><a href="#">X</a></li>
                            </ul>
                        </div>
                        <div className='footer-column'>
                            <h3>Ajuda</h3>
                            <ul>
                                <li><a href="#">FAQ</a></li>
                                <li><a href="#">Suporte Técnico</a></li>
                                <li><a href="#">Manual do Usuário</a></li>
                            </ul>
                        </div>
                        <div className='footer-column'>
                            <h3>Igreja Sossego em Cristo</h3>
                            <ul>
                                <li>Endereço: Rua Exemplo, 123 - Sossego</li>
                                <li>Telefone: (+244) 912-034-678</li>
                                <li>Email: contato@sossegoemcristo.org</li>
                            </ul>
                        </div>
                    </div>
                </div>

                <div className="footer-bottom">
                    <p> © 2025 Kairos | Todos os direitos reservados </p>
                    <p><a href="#">Política de Privacidade</a></p>
                </div>
            </div>
        </footer>
    )
}