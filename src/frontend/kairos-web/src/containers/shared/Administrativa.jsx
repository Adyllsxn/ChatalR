import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import './Administrativa.css';

export default function Administrativa() {
    const [perfilID, setPerfilID] = useState(null);

    useEffect(() => {
        const storedPerfilID = parseInt(localStorage.getItem('perfilID'), 10);
        setPerfilID(storedPerfilID);
    }, []);

    const acessoEventos = perfilID === 1 || perfilID === 2;
    const acessoTiposEvento = perfilID === 1 || perfilID === 2;
    const acessoUsuarios = perfilID === 1;

    return (
        <main>
            <section className='administrativa-section'>
                <div className='layout-container'>
                    <div className='administrativa-content'>
                        <div className='administrativa-context'>
                            <h1>Área Administrativa</h1>
                            <p>
                                Esta área é exclusiva para membros autorizados da equipe administrativa da igreja.
                                Gerencie eventos, aprovações, tipos de evento e permissões de usuários conforme sua função.
                            </p>
                        </div>

                        {(acessoEventos || acessoTiposEvento || acessoUsuarios) ? (
                            <div className='administrativa-grid'>

                                {acessoEventos && (
                                    <Link to="/gestao-eventos" className='card-link'>
                                        <div className="adm-card">
                                            <h2>Gestão de Eventos</h2>
                                            <p>Cadastrar, atualizar, deletar e aprovar eventos.</p>
                                        </div>
                                    </Link>
                                )}

                                {acessoTiposEvento && (
                                    <Link to="/tipos-evento" className='card-link'>
                                        <div className="adm-card">
                                            <h2>Tipos de Evento</h2>
                                            <p>Gerencie os tipos de eventos disponíveis na plataforma.</p>
                                        </div>
                                    </Link>
                                )}

                                {acessoUsuarios && (
                                    <Link to="/usuarios" className='card-link'>
                                        <div className="adm-card">
                                            <h2>Usuários e Perfis</h2>
                                            <p>Cadastrar, alterar, excluir usuários e atribuir perfis.</p>
                                        </div>
                                    </Link>
                                )}
                            </div>
                        ) : (
                            <div className="sem-acesso">
                                <p>Você não possui permissões administrativas para acessar esta área.</p>
                            </div>
                        )}
                    </div>
                </div>
            </section>
        </main>
    );
}
