import { useEffect, useState } from "react";
import {
  FaInfo,
  FaMagnifyingGlass,
  FaPen,
  FaPlus,
  FaTrash,
} from "react-icons/fa6";
import "./Tipos.css";
import api from "../../../../core/service/api";

interface TipoEvento {
  id: number;
  nome: string;
}

interface ApiResponse {
  data: TipoEvento[];
  currentPage?: number;
  totalPage?: number;
  totalCount?: number;
  pageSize?: number;
  message: string;
  code: number;
}

const Tipos = () => {
  const [tipos, setTipos] = useState<TipoEvento[]>([]);
  const [searchTerm, setSearchTerm] = useState<string>("");
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [showModal, setShowModal] = useState<boolean>(false);
  const [showDetalhesModal, setShowDetalhesModal] = useState<boolean>(false);
  const [showConfirmarDelete, setShowConfirmarDelete] = useState<boolean>(false);
  const [novoTipo, setNovoTipo] = useState<string>("");
  const [tipoEmEdicao, setTipoEmEdicao] = useState<TipoEvento | null>(null);
  const [tipoEmVisualizacao, setTipoEmVisualizacao] = useState<TipoEvento | null>(null);
  const [tipoADeletar, setTipoADeletar] = useState<TipoEvento | null>(null);

  const pageSize = 5;

  useEffect(() => {
    carregarTipos();
  }, []);

  const carregarTipos = async () => {
    try {
      const response = await api.get<ApiResponse>("/v1/ListTipoEvento");
      if (response.data && response.data.data) {
        setTipos(response.data.data);
      }
    } catch (error) {
      console.error("Erro ao buscar tipos de evento:", error);
    }
  };

  const buscarTipos = async () => {
    if (searchTerm.trim() === "") {
      carregarTipos();
      return;
    }

    try {
      const response = await api.get<ApiResponse>(
        `/v1/SearchTipoEvento?Nome=${searchTerm}`
      );
      if (response.data && response.data.data) {
        setTipos(response.data.data);
        setCurrentPage(1);
      }
    } catch (error) {
      console.error("Erro ao buscar tipos de evento:", error);
    }
  };

  const abrirModalAdicionar = () => {
    setTipoEmEdicao(null);
    setNovoTipo("");
    setShowModal(true);
  };

  const abrirModalEditar = (tipo: TipoEvento) => {
    setTipoEmEdicao(tipo);
    setNovoTipo(tipo.nome);
    setShowModal(true);
  };

  const abrirModalDetalhes = async (id: number) => {
    try {
      const response = await api.get<{ data: TipoEvento }>(
        `/v1/GetByIdTipoEvento?Id=${id}`
      );
      if (response.data && response.data.data) {
        setTipoEmVisualizacao(response.data.data);
        setShowDetalhesModal(true);
      }
    } catch (error) {
      console.error("Erro ao buscar detalhes:", error);
    }
  };

  const confirmarExclusao = (tipo: TipoEvento) => {
    setTipoADeletar(tipo);
    setShowConfirmarDelete(true);
  };

  const deletarTipo = async () => {
    if (!tipoADeletar) return;

    try {
      await api.delete(`/v1/DeleteTipoEvento?Id=${tipoADeletar.id}`);
      setShowConfirmarDelete(false);
      setTipoADeletar(null);
      carregarTipos();
    } catch (error) {
      console.error("Erro ao excluir tipo de evento:", error);
    }
  };

  const adicionarOuAtualizarTipo = async () => {
    if (!novoTipo.trim()) return;

    try {
      if (tipoEmEdicao) {
        await api.put("/v1/UpdateTipoEvento", {
          id: tipoEmEdicao.id,
          nome: novoTipo,
        });
      } else {
        await api.post("/v1/CreateTipoEvento", {
          nome: novoTipo,
        });
      }

      setNovoTipo("");
      setTipoEmEdicao(null);
      setShowModal(false);
      carregarTipos();
    } catch (error) {
      console.error("Erro ao salvar tipo de evento:", error);
    }
  };

  const tiposPaginados = tipos.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  const totalPages = Math.ceil(tipos.length / pageSize);

  return (
    <section className="tipoMain">
      <div className="tipoHeader">
        <button className="tipoBtnAdd" onClick={abrirModalAdicionar}>
          <FaPlus />
          Add Tipo
        </button>
        <div className="tipoBuscar">
          <input
            type="text"
            placeholder="Buscar Tipo de Evento..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button className="tipoBtnSearch" onClick={buscarTipos}>
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      <div className="tipoTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Tipo de Evento</th>
              <th>Ação</th>
            </tr>
          </thead>
          <tbody>
            {tiposPaginados.length > 0 ? (
              tiposPaginados.map((tipo) => (
                <tr key={tipo.id}>
                  <td>{tipo.id}</td>
                  <td>{tipo.nome}</td>
                  <td className="acoes">
                    <button title="Editar" onClick={() => abrirModalEditar(tipo)}>
                      <FaPen />
                    </button>
                    <button title="Detalhes" onClick={() => abrirModalDetalhes(tipo.id)}>
                      <FaInfo />
                    </button>
                    <button title="Eliminar" onClick={() => confirmarExclusao(tipo)}>
                      <FaTrash />
                    </button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={3}>Nenhum tipo de evento encontrado.</td>
              </tr>
            )}
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

      {/* Modal Adicionar/Editar */}
      {showModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h2>{tipoEmEdicao ? "Atualizar Tipo" : "Adicionar Tipo"}</h2>
            <input
              type="text"
              placeholder="Nome do Tipo de Evento"
              value={novoTipo}
              onChange={(e) => setNovoTipo(e.target.value)}
            />
            <div className="modal-actions">
              <button className="btn-salvar" onClick={adicionarOuAtualizarTipo}>
                {tipoEmEdicao ? "Atualizar" : "Salvar"}
              </button>
              <button className="btn-cancelar" onClick={() => setShowModal(false)}>
                Cancelar
              </button>
            </div>
          </div>
        </div>
      )}

      {/* Modal Detalhes */}
      {showDetalhesModal && tipoEmVisualizacao && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h2>Detalhes do Tipo</h2>
            <p><strong>ID:</strong> {tipoEmVisualizacao.id}</p>
            <p><strong>Nome:</strong> {tipoEmVisualizacao.nome}</p>
            <button className="btn-cancelar" onClick={() => setShowDetalhesModal(false)}>
              Cancelar
            </button>
          </div>
        </div>
      )}

      {/* Modal Confirmação de Exclusão */}
      {showConfirmarDelete && tipoADeletar && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h2>Confirmar Exclusão</h2>
            <p>Deseja realmente excluir o tipo <strong>{tipoADeletar.nome}</strong>?</p>
            <div className="modal-actions">
              <button className="btn-salvar" onClick={deletarTipo}>Sim</button>
              <button className="btn-cancelar" onClick={() => setShowConfirmarDelete(false)}>
                Não
              </button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default Tipos;
