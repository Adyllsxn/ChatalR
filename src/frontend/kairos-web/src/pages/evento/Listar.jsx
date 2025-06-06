import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import apiservice from '../../service/ApiService';
import '../../styles/evento/Listar.css';
import Alert from '../../components/shared/Alert';

export default function Listar() {
    const [eventos, setEventos] = useState([]);
    const [paginaAtual, setPaginaAtual] = useState(1);
    const [busca, setBusca] = useState('');
    const [alert, setAlert] = useState({ message: '', type: '' });
    const [carregado, setCarregado] = useState(false); // indica se o carregamento terminou
    const eventosPorPagina = 8;

    const token = localStorage.getItem("token");
    const authorization = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const carregarEventos = () => {
        apiservice.get('/v1/EventosAprovados', authorization)
            .then(response => {
                const data = response.data?.data || [];
                setEventos(data);
                setCarregado(true);
                setPaginaAtual(1);
                if (data.length === 0) {
                    setAlert({ message: "Nenhum evento disponível no momento.", type: "info" });
                }
            })
            .catch(error => {
                console.error("Erro ao buscar eventos:", error);
                setAlert({ message: "Não foi possível conectar ao servidor. Verifique sua internet ou tente mais tarde.", type: "error" });
                setCarregado(true);
            });
    };

    useEffect(() => {
        carregarEventos();
    }, []);

    const handleBuscar = async (e) => {
        e.preventDefault();

        if (busca.trim() === '') {
            carregarEventos();
            return;
        }

        try {
            const response = await apiservice.get(`/v1/SearchEvento?Titulo=${encodeURIComponent(busca)}`, authorization);
            const resultados = response.data?.data || [];

            if (resultados.length === 0) {
                setAlert({ message: "Nenhum evento encontrado com esse título.", type: "warning" });
                carregarEventos(); // recarrega os eventos originais
                return;
            }

            setEventos(resultados);
            setPaginaAtual(1);
            setAlert({ message: '', type: '' });
        } catch (error) {
            console.error("Erro ao buscar eventos:", error);
            setAlert({ message: "Erro ao buscar eventos. Tente novamente mais tarde.", type: "error" });
        }
    };

    const indiceInicial = (paginaAtual - 1) * eventosPorPagina;
    const eventosPagina = eventos.slice(indiceInicial, indiceInicial + eventosPorPagina);
    const totalPaginas = Math.ceil(eventos.length / eventosPorPagina);

    const mudarPagina = (novaPagina) => {
        if (novaPagina >= 1 && novaPagina <= totalPaginas) {
            setPaginaAtual(novaPagina);
        }
    };

    return (
        <main>
            {alert.message && (
                <Alert 
                    message={alert.message} 
                    type={alert.type} 
                    onClose={() => setAlert({ message: '', type: '' })}
                />
            )}

            <div className='layout-container'>
                <section className='eventos-section'>
                    <div className='evento-content'>
                        <h1>Lista dos Eventos</h1>
                        <form onSubmit={handleBuscar}>
                            <input
                                type="text"
                                placeholder='Buscar Eventos'
                                value={busca}
                                onChange={(e) => setBusca(e.target.value)}
                            />
                            <button type="submit">Buscar</button>
                        </form>
                    </div>

                    {/* Se já terminou de carregar e não há eventos, mostrar mensagem */}
                    {carregado && eventos.length === 0 && !alert.message && (
                        <div className="mensagem-vazia">
                            <p>🚫 Nenhum evento disponível no momento.</p>
                        </div>
                    )}

                    <div className='evento-cards'>
                        {eventosPagina.map(evento => (
                            <div key={evento.id} className="evento-card-content">
                                <div className='evento-card-img'>
                                    <img
                                        src={`http://localhost:5232/${evento.imagemUrl}`}
                                        alt={evento.titulo}
                                    />
                                </div>
                                <div className='evento-card-inf'>
                                    <h5 title={evento.titulo}>
                                        {evento.titulo.length > 30
                                            ? evento.titulo.slice(0, 30) + '...'
                                            : evento.titulo}
                                    </h5>
                                    <p>
                                        <Link 
                                            to="/detalhesEvento" 
                                            state={{ evento }} 
                                            className='evento-card-inf-link'
                                        >
                                            Ver Detalhes
                                        </Link>
                                    </p>
                                </div>
                            </div>
                        ))}
                    </div>

                    {eventos.length > 0 && (
                        <div className="paginacao">
                            <button disabled={paginaAtual === 1} onClick={() => mudarPagina(paginaAtual - 1)}>Anterior</button>

                            {Array.from({ length: totalPaginas }, (_, i) => (
                                <button
                                    key={i + 1}
                                    onClick={() => mudarPagina(i + 1)}
                                    className={paginaAtual === i + 1 ? 'ativo' : ''}
                                >
                                    {i + 1}
                                </button>
                            ))}

                            <button disabled={paginaAtual === totalPaginas} onClick={() => mudarPagina(paginaAtual + 1)}>Próximo</button>
                        </div>
                    )}
                </section>
            </div>
        </main>
    );
}
