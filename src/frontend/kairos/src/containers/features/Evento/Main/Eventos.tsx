import { useEffect, useState } from "react";
import {
  FaPen,
  FaInfo,
  FaThumbsDown,
  FaThumbsUp,
  FaMagnifyingGlass,
  FaPlus,
  FaTrash
} from "react-icons/fa6";
import "./Eventos.css";
import { Link } from "react-router-dom";
import api from "../../../../core/service/api";

// Tipos
interface TipoEvento {
  id: number;
  nome: string;
}

interface Usuario {
  id: number;
  nome: string;
  sobreNome: string;
  email: string;
  perfilID: number;
  fotoUrl: string | null;
}

interface Evento {
  id: number;
  titulo: string;
  local: string;
  statusAprovacao: number;
  tipoEvento: TipoEvento;
  usuario: Usuario;
}

interface ApiResponse {
  data: Evento[];
  currentPage: number;
  totalPage: number;
  totalCount: number;
  pageSize: number;
  message: string;
  code: number;
}

const Eventos = () => {
  const [perfilID, setPerfilID] = useState<number | null>(null);
  const [eventos, setEventos] = useState<Evento[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const pageSize = 5;

  useEffect(() => {
    const storedPerfilID = localStorage.getItem("perfilID");
    if (storedPerfilID) {
      setPerfilID(parseInt(storedPerfilID, 10));
    }
  }, []);

  useEffect(() => {
    carregarEventos();
  }, []);

  const carregarEventos = async () => {
    try {
      const response = await api.get<ApiResponse>(`/v1/ListEvento`);
      if (response.data && response.data.data) {
        setEventos(response.data.data);
      }
    } catch (error) {
      console.error("Erro ao buscar eventos:", error);
    }
  };

  const isAdmin = perfilID === 1;

  const eventosPaginados = eventos.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  const totalPages = Math.ceil(eventos.length / pageSize);

  const statusLabel = (status: number): string => {
    switch (status) {
      case 0: return "Pendente";
      case 1: return "Aprovado";
      case 2: return "Rejeitado";
      default: return "Desconhecido";
    }
  };

  return (
    <section className="eventoMain">
      <div className="eventoHeader">
        <Link to="/administrativa/eventoAdd" className="eventoBtnAdd">
          <FaPlus />
          Add Evento
        </Link>
        <div className="eventoBuscar">
          <input type="text" placeholder="Buscar Evento..." />
          <button className="eventoBtnSearch">
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      <div className="eventoTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Título</th>
              <th>Local</th>
              <th>Estado</th>
              <th>Ação</th>
            </tr>
          </thead>

          <tbody>
            {eventosPaginados.map((evento) => (
              <tr key={evento.id}>
                <td>{evento.id}</td>
                <td>{evento.titulo}</td>
                <td>{evento.local}</td>
                <td>
                  <p className={`status-${evento.statusAprovacao}`}>
                    {statusLabel(evento.statusAprovacao)}
                  </p>
                </td>
                <td className="acoes">
                  <button title="Editar"><FaPen /></button>
                  <button title="Detalhes"><FaInfo /></button>
                  {isAdmin && (
                    <>
                      <button title="Rejeitar"><FaThumbsDown /></button>
                      <button title="Aprovar"><FaThumbsUp /></button>
                    </>
                  )}
                  <button title="Eliminar"><FaTrash /></button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>


      <div className="paginacao">
        <button
          onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
          disabled={currentPage === 1}
        >
          Anterior
        </button>
        <span>Página {currentPage} de {totalPages}</span>
        <button
          onClick={() => setCurrentPage((prev) => Math.min(prev + 1, totalPages))}
          disabled={currentPage === totalPages}
        >
          Próxima
        </button>
      </div>

      <div className="imprimir">
        <button>
          Imprimir
        </button>
      </div>
    </section>
  );
};

export default Eventos;
