import { useEffect, useState, useCallback } from "react";
import {
  FaPen,
  FaInfo,
  FaThumbsDown,
  FaThumbsUp,
  FaMagnifyingGlass,
  FaPlus,
  FaTrash,
  FaPrint,
  FaX,
} from "react-icons/fa6";
import api from "../../../../core/service/api";
import jsPDF from "jspdf";
import autoTable from "jspdf-autotable";
import "./Eventos.css";

interface TipoEvento {
  id: number;
  nome: string;
}

interface Usuario {
  id: number;
  nome: string;
  sobreNome: string;
  email: string;
}

interface Evento {
  id: number;
  titulo: string;
  descricao: string;
  local: string;
  statusAprovacao: number;
  tipoEventoID: number;
  tipoEvento: TipoEvento;
  usuario: Usuario;
  dataHoraInicio: string;
  dataHoraFim: string;
  imagemUrl: string;
}

const Eventos = () => {
  const [perfilID, setPerfilID] = useState<number | null>(null);
  const [eventosOriginais, setEventosOriginais] = useState<Evento[]>([]);
  const [eventosFiltrados, setEventosFiltrados] = useState<Evento[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [titulo, setTitulo] = useState<string>("");
  const [dataInicio, setDataInicio] = useState<string>("");
  const [dataFim, setDataFim] = useState<string>("");
  const [mensagem, setMensagem] = useState<string>("");

  const [mostrarModal, setMostrarModal] = useState(false);
  const [mostrarDetalhes, setMostrarDetalhes] = useState(false);
  const [tiposEvento, setTiposEvento] = useState<TipoEvento[]>([]);
  const [modoEdicao, setModoEdicao] = useState(false);
  const [eventoSelecionado, setEventoSelecionado] = useState<Evento | null>(null);

  const [novoEvento, setNovoEvento] = useState({
    id: 0,
    titulo: "",
    descricao: "",
    dataHoraInicio: "",
    dataHoraFim: "",
    local: "",
    tipoEventoID: 0,
    imagem: null as File | null,
    imagemUrl: "",
  });

  const carregarEventos = useCallback(async () => {
    try {
      const response = await api.get("/v1/ListEvento");
      setEventosOriginais(response.data.data);
      setEventosFiltrados(response.data.data);
    } catch (error) {
      console.error("Erro ao buscar eventos:", error);
    }
  }, []);

  const carregarTiposEvento = useCallback(async () => {
    try {
      const tiposRes = await api.get("/v1/ListTipoEvento");
      setTiposEvento(tiposRes.data.data);
    } catch (err) {
      console.error("Erro ao carregar tipos:", err);
    }
  }, []);

  useEffect(() => {
    const storedPerfilID = localStorage.getItem("perfilID");
    if (storedPerfilID) setPerfilID(parseInt(storedPerfilID, 10));
    carregarEventos();
    carregarTiposEvento();
  }, [carregarEventos, carregarTiposEvento]);

  const aprovarOuRejeitar = async (id: number, status: number) => {
    try {
      const res = await api.patch("/v1/UpdateStatusEvento", { id, statusAprovacao: status }, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
        },
      });
      if (res.data?.isSuccess) carregarEventos();
    } catch (err) {
      console.error("Erro ao atualizar status:", err);
    }
  };

  const deletarEvento = async (id: number) => {
    if (!window.confirm("Deseja realmente excluir este evento?")) return;
    try {
      const res = await api.delete(`/v1/DeleteEvento?Id=${id}`);
      if (res.data?.isSuccess) carregarEventos();
    } catch (err) {
      console.error("Erro ao excluir evento:", err);
    }
  };

  const abrirModalEdicao = async (id: number) => {
    try {
      const res = await api.get(`/v1/GetByIdEvento?Id=${id}`);
      const evento = res.data.data;
      setNovoEvento({
        id: evento.id,
        titulo: evento.titulo,
        descricao: evento.descricao,
        dataHoraInicio: evento.dataHoraInicio,
        dataHoraFim: evento.dataHoraFim,
        local: evento.local,
        tipoEventoID: evento.tipoEventoID,
        imagem: null,
        imagemUrl: evento.imagemUrl,
      });
      setModoEdicao(true);
      setMostrarModal(true);
    } catch (err) {
      console.error("Erro ao buscar evento:", err);
    }
  };

  const abrirModalDetalhes = async (id: number) => {
    try {
      const res = await api.get(`/v1/GetByIdEvento?Id=${id}`);
      setEventoSelecionado(res.data.data);
      setMostrarDetalhes(true);
    } catch (err) {
      console.error("Erro ao buscar detalhes:", err);
    }
  };

  const handleChangeNovo = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value, files } = e.target as HTMLInputElement;
    if (name === "imagem" && files?.length) {
      setNovoEvento((prev) => ({ ...prev, imagem: files[0] }));
    } else {
      setNovoEvento((prev) => ({ ...prev, [name]: value }));
    }
  };

  const criarOuAtualizarEvento = async () => {
    const {
      id,
      titulo,
      descricao,
      dataHoraInicio,
      dataHoraFim,
      local,
      tipoEventoID,
      imagem,
      imagemUrl,
    } = novoEvento;

    const formData = new FormData();
    formData.append("Id", String(id));
    formData.append("Titulo", titulo);
    formData.append("Descricao", descricao);
    formData.append("DataHoraInicio", dataHoraInicio);
    formData.append("DataHoraFim", dataHoraFim);
    formData.append("Local", local);
    formData.append("TipoEventoID", String(tipoEventoID));
    if (imagem) {
      formData.append("ImagemUrl", imagem);
    } else {
      formData.append("ImagemUrl", imagemUrl);
    }

    try {
      const res = modoEdicao
        ? await api.put("/v1/UpdateEvento", formData, {
            headers: {
              "Content-Type": "multipart/form-data",
              Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
            },
          })
        : await api.post("/v1/CreateEvento", formData, {
            headers: {
              "Content-Type": "multipart/form-data",
              Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
            },
          });
      if (res.data?.isSuccess) {
        setMostrarModal(false);
        setModoEdicao(false);
        carregarEventos();
      }
    } catch (err) {
      console.error("Erro ao salvar evento:", err);
    }
  };

  const statusLabel = (status: number): string => {
    switch (status) {
      case 0: return "Pendente";
      case 1: return "Aprovado";
      case 2: return "Rejeitado";
      default: return "Desconhecido";
    }
  };

  const eventosPaginados = eventosFiltrados.slice((currentPage - 1) * 5, currentPage * 5);
  const totalPages = Math.ceil(eventosFiltrados.length / 5);
  const isAdmin = perfilID === 1;

  const handleGerarPDF = () => {
    const doc = new jsPDF();
    doc.setFontSize(18);
    doc.text("Relatório de Eventos", 14, 20);
    autoTable(doc, {
      startY: 30,
      head: [["ID", "Título", "Local", "Tipo Evento", "Responsável", "Data", "Estado"]],
      body: eventosFiltrados.map((evento) => [
        evento.id,
        evento.titulo,
        evento.local,
        evento.tipoEvento?.nome,
        `${evento.usuario?.nome} ${evento.usuario?.sobreNome}`,
        new Date(evento.dataHoraInicio).toLocaleDateString(),
        statusLabel(evento.statusAprovacao),
      ]),
    });
    doc.save("relatorio_eventos.pdf");
  };

  return (
    <section className="eventoMain">
      <div className="eventoHeader">
        <button className="eventoBtnAdd" onClick={() => {
          setNovoEvento({ id: 0, titulo: "", descricao: "", dataHoraInicio: "", dataHoraFim: "", local: "", tipoEventoID: 0, imagem: null, imagemUrl: "" });
          setModoEdicao(false);
          setMostrarModal(true);
        }}>
          <FaPlus /> Add Evento
        </button>
        <div className="eventoBuscar">
          <input type="text" placeholder="Buscar por título..." value={titulo} onChange={(e) => setTitulo(e.target.value)} />
          <input type="date" value={dataInicio} onChange={(e) => setDataInicio(e.target.value)} />
          <input type="date" value={dataFim} onChange={(e) => setDataFim(e.target.value)} />
          <button className="eventoBtnSearch" onClick={() => {
            let filtrados = [...eventosOriginais];
            if (titulo.trim()) {
              filtrados = filtrados.filter((evento) => evento.titulo.toLowerCase().includes(titulo.toLowerCase()));
            }
            if (dataInicio && dataFim) {
              const inicio = new Date(dataInicio);
              const fim = new Date(dataFim);
              filtrados = filtrados.filter((evento) => {
                const dataEvento = new Date(evento.dataHoraInicio);
                return dataEvento >= inicio && dataEvento <= fim;
              });
            }
            setMensagem(filtrados.length === 0 ? "Nenhum evento encontrado." : "");
            setEventosFiltrados(filtrados);
            setCurrentPage(1);
          }}>
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      {mensagem && <div className="mensagem-erro">{mensagem}</div>}

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
            {eventosPaginados.length > 0 ? eventosPaginados.map((evento) => (
              <tr key={evento.id}>
                <td>{evento.id}</td>
                <td>{evento.titulo}</td>
                <td>{evento.local}</td>
                <td><p className={`status-${evento.statusAprovacao}`}>{statusLabel(evento.statusAprovacao)}</p></td>
                <td className="acoes">
                  <button title="Editar" onClick={() => abrirModalEdicao(evento.id)}><FaPen /></button>
                  <button title="Detalhes" onClick={() => abrirModalDetalhes(evento.id)}><FaInfo /></button>
                  {isAdmin && evento.statusAprovacao === 0 && (
                    <>
                      <button title="Rejeitar" onClick={() => aprovarOuRejeitar(evento.id, 2)}><FaThumbsDown /></button>
                      <button title="Aprovar" onClick={() => aprovarOuRejeitar(evento.id, 1)}><FaThumbsUp /></button>
                    </>
                  )}
                  <button title="Eliminar" onClick={() => deletarEvento(evento.id)}><FaTrash /></button>
                </td>
              </tr>
            )) : <tr><td colSpan={5}>Nenhum evento encontrado.</td></tr>}
          </tbody>
        </table>
      </div>

      <div className="paginacao">
        <button onClick={() => setCurrentPage((p) => Math.max(p - 1, 1))} disabled={currentPage === 1}>Anterior</button>
        <span>Página {currentPage} de {totalPages}</span>
        <button onClick={() => setCurrentPage((p) => Math.min(p + 1, totalPages))} disabled={currentPage === totalPages}>Próxima</button>
      </div>

      {dataInicio && dataFim && eventosFiltrados.length > 0 && (
        <div className="imprimir">
          <button onClick={handleGerarPDF}><FaPrint /> Gerar PDF</button>
        </div>
      )}

      {mostrarModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <button className="close-btn" onClick={() => setMostrarModal(false)}><FaX /></button>
            <h2>{modoEdicao ? "Editar Evento" : "Criar Evento"}</h2>
            <input name="titulo" placeholder="Título" value={novoEvento.titulo} onChange={handleChangeNovo} />
            <textarea name="descricao" placeholder="Descrição" value={novoEvento.descricao} onChange={handleChangeNovo}></textarea>
            <input type="datetime-local" name="dataHoraInicio" value={novoEvento.dataHoraInicio} onChange={handleChangeNovo} />
            <input type="datetime-local" name="dataHoraFim" value={novoEvento.dataHoraFim} onChange={handleChangeNovo} />
            <input name="local" placeholder="Local" value={novoEvento.local} onChange={handleChangeNovo} />
            <select name="tipoEventoID" value={novoEvento.tipoEventoID} onChange={handleChangeNovo}>
              <option value={0}>-- Tipo de Evento --</option>
              {tiposEvento.map((tipo) => (
                <option key={tipo.id} value={tipo.id}>{tipo.nome}</option>
              ))}
            </select>
            <input type="file" name="imagem" onChange={handleChangeNovo} accept="image/*" />
            {novoEvento.imagem && <img src={URL.createObjectURL(novoEvento.imagem)} alt="Preview" style={{ width: 150, marginTop: 10 }} />}
            {!novoEvento.imagem && novoEvento.imagemUrl && <img src={`http://localhost:5232/${novoEvento.imagemUrl}`} alt="Atual" style={{ width: 150, marginTop: 10 }} />}
            <div className="modal-actions">
              <button onClick={criarOuAtualizarEvento}>Salvar</button>
              <button onClick={() => setMostrarModal(false)}>Cancelar</button>
            </div>
          </div>
        </div>
      )}

      {mostrarDetalhes && eventoSelecionado && (
        <div className="modal-overlay">
          <div className="modal-content">
            <button className="close-btn" onClick={() => setMostrarDetalhes(false)}><FaX /></button>
            <h2>Detalhes do Evento</h2>
            <p><strong>Título:</strong> {eventoSelecionado.titulo}</p>
            <p><strong>Descrição:</strong> {eventoSelecionado.descricao}</p>
            <p><strong>Local:</strong> {eventoSelecionado.local}</p>
            <p><strong>Tipo:</strong> {eventoSelecionado.tipoEvento?.nome}</p>
            <p><strong>Responsável:</strong> {eventoSelecionado.usuario?.nome} {eventoSelecionado.usuario?.sobreNome}</p>
            <p><strong>Início:</strong> {new Date(eventoSelecionado.dataHoraInicio).toLocaleString()}</p>
            <p><strong>Fim:</strong> {new Date(eventoSelecionado.dataHoraFim).toLocaleString()}</p>
            {eventoSelecionado.imagemUrl && <img src={`http://localhost:5232/${eventoSelecionado.imagemUrl}`} alt="Imagem" style={{ width: 200, marginTop: 10 }} />}
            <div className="modal-actions" style={{ marginTop: "1rem", display: "flex", justifyContent: "center" }}>
              <button onClick={() => setMostrarDetalhes(false)}>Fechar</button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default Eventos;
