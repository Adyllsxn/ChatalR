import { useState, useEffect, useCallback, useMemo } from 'react';
import { Link } from 'react-router-dom';
import apiservice from '../../../../core/service/api';
import './EventoList.css';

interface Evento {
  id: number;
  titulo: string;
  imagemUrl: string;
}

export default function Listar() {
  const [eventos, setEventos] = useState<Evento[]>([]);
  const [paginaAtual, setPaginaAtual] = useState<number>(1);
  const [busca, setBusca] = useState<string>('');
  const [carregado, setCarregado] = useState<boolean>(false);

  const eventosPorPagina = 6;

  // 🔐 Memoize o authorization para evitar recriação desnecessária
  const authorization = useMemo(() => ({
    headers: {
      Authorization: `Bearer ${localStorage.getItem('token') || ''}`,
    },
  }), []);

  const carregarEventos = useCallback(() => {
    apiservice
      .get('/v1/GetAprovadosEvento', authorization)
      .then((response) => {
        const data: Evento[] = response.data?.data || [];
        setEventos(data);
        setCarregado(true);
        setPaginaAtual(1);

        if (data.length === 0) {
          alert('Nenhum evento disponível no momento.');
        }
      })
      .catch((error) => {
        console.error('Erro ao buscar eventos:', error);
        alert('Não foi possível conectar ao servidor. Verifique sua internet ou tente mais tarde.');
        setCarregado(true);
      });
  }, [authorization]);

  useEffect(() => {
    carregarEventos();
  }, [carregarEventos]);

  const handleBuscar = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    if (busca.trim() === '') {
      carregarEventos();
      return;
    }

    try {
      const response = await apiservice.get(
        `/v1/SearchEvento?Titulo=${encodeURIComponent(busca.trim())}`,
        authorization
      );
      const resultados: Evento[] = response.data?.data || [];

      if (resultados.length === 0) {
        alert('Nenhum evento encontrado com esse título.');
        return;
      }

      setEventos(resultados);
      setPaginaAtual(1);
    } catch (error) {
      console.error('Erro ao buscar eventos:', error);
      alert('Erro ao buscar eventos. Tente novamente mais tarde.');
    }
  };

  const indiceInicial = (paginaAtual - 1) * eventosPorPagina;
  const eventosPagina = eventos.slice(indiceInicial, indiceInicial + eventosPorPagina);
  const totalPaginas = Math.ceil(eventos.length / eventosPorPagina);

  const mudarPagina = (novaPagina: number) => {
    if (novaPagina >= 1 && novaPagina <= totalPaginas) {
      setPaginaAtual(novaPagina);
    }
  };
  
  return (
    <main>
      <div className="layoutContainer">
        <section className="eventos-section">
          <h1>Lista dos Eventos</h1>
          <div className="evento-content">
            <form onSubmit={handleBuscar}>
              <input
                type="text"
                placeholder="Buscar Eventos"
                value={busca}
                onChange={(e) => setBusca(e.target.value)}
              />
              <button type="submit">Buscar</button>
            </form>
          </div>

          {carregado && eventos.length === 0 && (
            <div className="mensagem-vazia">
              <p>🚫 Nenhum evento disponível no momento.</p>
            </div>
          )}

          <div className="evento-cards">
            {eventosPagina.map((evento: Evento) => (
              <div key={evento.id} className="evento-card-content">
                <div className="evento-card-img">
                  <img
                    src={`http://localhost:5232/${evento.imagemUrl}`}
                    alt={evento.titulo}
                  />
                </div>
                <div className="evento-card-inf">
                  <h5 title={evento.titulo}>
                    {evento.titulo.length > 30
                      ? evento.titulo.slice(0, 30) + '...'
                      : evento.titulo}
                  </h5>
                  <p>
                    <Link
                      to="/eventoDetails"
                      state={{ evento }}
                      className="evento-card-inf-link"
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
              <button disabled={paginaAtual === 1} onClick={() => mudarPagina(paginaAtual - 1)}>
                Anterior
              </button>

              {Array.from({ length: totalPaginas }, (_, i) => (
                <button
                  key={i + 1}
                  onClick={() => mudarPagina(i + 1)}
                  className={paginaAtual === i + 1 ? 'ativo' : ''}
                >
                  {i + 1}
                </button>
              ))}

              <button
                disabled={paginaAtual === totalPaginas}
                onClick={() => mudarPagina(paginaAtual + 1)}
              >
                Próximo
              </button>
            </div>
          )}
        </section>
      </div>
    </main>
  );
}
