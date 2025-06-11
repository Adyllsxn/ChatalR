import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { FaCalendarAlt, FaTags, FaUsersCog, FaBlog } from 'react-icons/fa';
import {
    LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer
} from 'recharts';

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

    const data = [
        { name: 'Dom', eventos: 4 },
        { name: 'Seg', eventos: 6 },
        { name: 'Ter', eventos: 2 },
        { name: 'Qua', eventos: 5 },
        { name: 'Qui', eventos: 3 },
        { name: 'Sex', eventos: 7 },
        { name: 'Sab', eventos: 1 },
    ];

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
                            <>
                                <div className='administrativa-cards'>
                                    {acessoEventos && (
                                        <Link to="/gestao-eventos" className='card-link'>
                                            <div className="adm-card eventos">
                                                <FaCalendarAlt size={24} />
                                                <p>Eventos</p>
                                            </div>
                                        </Link>
                                    )}

                                    {acessoTiposEvento && (
                                        <Link to="/tipo-evento" className='card-link'>
                                            <div className="adm-card tipos">
                                                <FaTags size={24} />
                                                <p>Tipos</p>
                                            </div>
                                        </Link>
                                    )}

                                    {acessoUsuarios && (
                                        <Link to="/usuarios" className='card-link'>
                                            <div className="adm-card usuarios">
                                                <FaUsersCog size={24} />
                                                <p>Usuários</p>
                                            </div>
                                        </Link>
                                    )}

                                    <Link to="/blog" className='card-link'>
                                        <div className="adm-card blog">
                                            <FaBlog size={24} />
                                            <p>Blog</p>
                                        </div>
                                    </Link>
                                </div>

                                <div className='grafico-container'>
                                    <h3>Eventos da Semana</h3>
                                    <ResponsiveContainer width="100%" height={250}>
                                        <LineChart data={data}>
                                            <CartesianGrid stroke="#ccc" />
                                            <XAxis dataKey="name" />
                                            <YAxis />
                                            <Tooltip />
                                            <Line type="monotone" dataKey="eventos" stroke="#f57c00" strokeWidth={2} />
                                        </LineChart>
                                    </ResponsiveContainer>
                                </div>
                            </>
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
