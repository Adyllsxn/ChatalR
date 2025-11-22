import { footerStyles } from './styles';

function Footer() {
    return (
        <footer className={footerStyles.footer}>
            {/* Background decorativo */}
            <div className={footerStyles.background}></div>
            <div className={footerStyles.ornament}></div>
            <div className={footerStyles.ornament2}></div>
            
            <div className={footerStyles.container}>
                <div className={footerStyles.grid}>
                    {/* Logo e Social */}
                    <div className={footerStyles.logoSection}>
                        <h3 className={footerStyles.logo}>KAIROS</h3>
                        <p className={footerStyles.tagline}>
                            Transformando momentos em experiências inesquecíveis. 
                            Sua jornada começa aqui.
                        </p>
                        <div className={footerStyles.socialLinks}>
                            <a href="#" className={footerStyles.socialIcon} aria-label="Instagram">
                                <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M12 2.163c3.204 0 3.584.012 4.85.07 3.252.148 4.771 1.691 4.919 4.919.058 1.265.069 1.645.069 4.849 0 3.205-.012 3.584-.069 4.849-.149 3.225-1.664 4.771-4.919 4.919-1.266.058-1.644.07-4.85.07-3.204 0-3.584-.012-4.849-.07-3.26-.149-4.771-1.699-4.919-4.92-.058-1.265-.07-1.644-.07-4.849 0-3.204.013-3.583.07-4.849.149-3.227 1.664-4.771 4.919-4.919 1.266-.057 1.645-.069 4.849-.069zm0-2.163c-3.259 0-3.667.014-4.947.072-4.358.2-6.78 2.618-6.98 6.98-.059 1.281-.073 1.689-.073 4.948 0 3.259.014 3.668.072 4.948.2 4.358 2.618 6.78 6.98 6.98 1.281.058 1.689.072 4.948.072 3.259 0 3.668-.014 4.948-.072 4.354-.2 6.782-2.618 6.979-6.98.059-1.28.073-1.689.073-4.948 0-3.259-.014-3.667-.072-4.947-.196-4.354-2.617-6.78-6.979-6.98-1.281-.059-1.69-.073-4.949-.073zm0 5.838c-3.403 0-6.162 2.759-6.162 6.162s2.759 6.163 6.162 6.163 6.162-2.759 6.162-6.163c0-3.403-2.759-6.162-6.162-6.162zm0 10.162c-2.209 0-4-1.79-4-4 0-2.209 1.791-4 4-4s4 1.791 4 4c0 2.21-1.791 4-4 4zm6.406-11.845c-.796 0-1.441.645-1.441 1.44s.645 1.44 1.441 1.44c.795 0 1.439-.645 1.439-1.44s-.644-1.44-1.439-1.44z"/>
                                </svg>
                            </a>
                            <a href="#" className={footerStyles.socialIcon} aria-label="Twitter">
                                <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M23.953 4.57a10 10 0 01-2.825.775 4.958 4.958 0 002.163-2.723c-.951.555-2.005.959-3.127 1.184a4.92 4.92 0 00-8.384 4.482C7.69 8.095 4.067 6.13 1.64 3.162a4.822 4.822 0 00-.666 2.475c0 1.71.87 3.213 2.188 4.096a4.904 4.904 0 01-2.228-.616v.06a4.923 4.923 0 003.946 4.827 4.996 4.996 0 01-2.212.085 4.936 4.936 0 004.604 3.417 9.867 9.867 0 01-6.102 2.105c-.39 0-.779-.023-1.17-.067a13.995 13.995 0 007.557 2.209c9.053 0 13.998-7.496 13.998-13.985 0-.21 0-.42-.015-.63A9.935 9.935 0 0024 4.59z"/>
                                </svg>
                            </a>
                            <a href="#" className={footerStyles.socialIcon} aria-label="LinkedIn">
                                <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M20.447 20.452h-3.554v-5.569c0-1.328-.027-3.037-1.852-3.037-1.853 0-2.136 1.445-2.136 2.939v5.667H9.351V9h3.414v1.561h.046c.477-.9 1.637-1.85 3.37-1.85 3.601 0 4.267 2.37 4.267 5.455v6.286zM5.337 7.433c-1.144 0-2.063-.926-2.063-2.065 0-1.138.92-2.063 2.063-2.063 1.14 0 2.064.925 2.064 2.063 0 1.139-.925 2.065-2.064 2.065zm1.782 13.019H3.555V9h3.564v11.452zM22.225 0H1.771C.792 0 0 .774 0 1.729v20.542C0 23.227.792 24 1.771 24h20.451C23.2 24 24 23.227 24 22.271V1.729C24 .774 23.2 0 22.222 0h.003z"/>
                                </svg>
                            </a>
                            <a href="#" className={footerStyles.socialIcon} aria-label="YouTube">
                                <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24">
                                    <path d="M23.498 6.186a3.016 3.016 0 0 0-2.122-2.136C19.505 3.545 12 3.545 12 3.545s-7.505 0-9.377.505A3.017 3.017 0 0 0 .502 6.186C0 8.07 0 12 0 12s0 3.93.502 5.814a3.016 3.016 0 0 0 2.122 2.136c1.871.505 9.376.505 9.376.505s7.505 0 9.377-.505a3.015 3.015 0 0 0 2.122-2.136C24 15.93 24 12 24 12s0-3.93-.502-5.814zM9.545 15.568V8.432L15.818 12l-6.273 3.568z"/>
                                </svg>
                            </a>
                        </div>
                    </div>

                    {/* Links Rápidos */}
                    <div className={footerStyles.linksSection}>
                        <h4 className={footerStyles.sectionTitle}>
                            Links Rápidos
                            <span className={footerStyles.sectionTitleUnderline}></span>
                        </h4>
                        <div className={footerStyles.linkList}>
                            <a href="/" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Início
                            </a>
                            <a href="/eventoList" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Eventos
                            </a>
                            <a href="/blogList" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Blog
                            </a>
                            <a href="/sobre" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Sobre Nós
                            </a>
                            <a href="/contato" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Contato
                            </a>
                        </div>
                    </div>

                    {/* Suporte */}
                    <div className={footerStyles.linksSection}>
                        <h4 className={footerStyles.sectionTitle}>
                            Suporte
                            <span className={footerStyles.sectionTitleUnderline}></span>
                        </h4>
                        <div className={footerStyles.linkList}>
                            <a href="/ajuda" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Central de Ajuda
                            </a>
                            <a href="/faq" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                FAQ
                            </a>
                            <a href="/privacidade" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Política de Privacidade
                            </a>
                            <a href="/termos" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Termos de Uso
                            </a>
                            <a href="/cookies" className={footerStyles.link}>
                                <span className={footerStyles.linkIcon}></span>
                                Cookies
                            </a>
                        </div>
                    </div>

                    {/* Newsletter */}
                    <div className={footerStyles.newsletter}>
                        <h4 className={footerStyles.newsletterTitle}>
                            Fique por Dentro
                        </h4>
                        <p className={footerStyles.newsletterText}>
                            Receba as últimas novidades sobre eventos exclusivos e conteúdos especiais.
                        </p>
                        <form className={footerStyles.form}>
                            <input 
                                type="email" 
                                placeholder="Seu melhor e-mail"
                                className={footerStyles.input}
                                required
                            />
                            <button type="submit" className={footerStyles.button}>
                                Inscrever
                            </button>
                        </form>
                    </div>
                </div>

                {/* Bottom */}
                <div className={footerStyles.bottom}>
                    <p className={footerStyles.copyright}>
                        © 2025 Kairos. Todos os direitos reservados.
                    </p>
                    <div className={footerStyles.bottomLinks}>
                        <a href="/privacidade" className={footerStyles.bottomLink}>
                            Privacidade
                        </a>
                        <a href="/termos" className={footerStyles.bottomLink}>
                            Termos
                        </a>
                        <a href="/cookies" className={footerStyles.bottomLink}>
                            Cookies
                        </a>
                        <a href="/sitemap" className={footerStyles.bottomLink}>
                            Mapa do Site
                        </a>
                    </div>
                </div>
            </div>
        </footer>
    );
}

export default Footer;