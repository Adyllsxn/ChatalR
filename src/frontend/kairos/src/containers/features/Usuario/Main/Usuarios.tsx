import { useEffect, useState } from "react";
import {
  FaInfo,
  FaMagnifyingGlass,
  FaPen,
  FaPlus,
  FaTrash,
  FaUser,
  FaX,
} from "react-icons/fa6";
import "./Usuarios.css";
import api from "../../../../core/service/api";

interface Perfil {
  id: number;
  nome: string;
}

interface Usuario {
  id: number;
  nome: string;
  sobreNome: string;
  email: string;
  bi: string;
  perfil: Perfil;
}

interface ApiResponse {
  data: Usuario[];
  currentPage: number;
  totalPage: number;
  pageSize: number;
  totalCount: number;
  message: string;
  code: number;
}

const Usuarios = () => {
  const [usuarios, setUsuarios] = useState<Usuario[]>([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [showModal, setShowModal] = useState(false);

  const [novoUsuario, setNovoUsuario] = useState({
    nome: "",
    sobreNome: "",
    email: "",
    password: "",
    telefone: "",
    bi: "",
  });

  const [erros, setErros] = useState<{ telefone?: string; bi?: string }>({});

  const pageSize = 5;

  useEffect(() => {
    carregarUsuarios();
  }, []);

  const carregarUsuarios = async () => {
    try {
      const response = await api.get<ApiResponse>("/v1/ListUsuario");
      if (response.data?.data) {
        setUsuarios(response.data.data);
      }
    } catch (error) {
      console.error("Erro ao carregar usuários:", error);
    }
  };

  const validar = (): boolean => {
    const erros: { telefone?: string; bi?: string } = {};

    if (!/^9\d{8}$/.test(novoUsuario.telefone)) {
      erros.telefone = "Telefone inválido: deve começar com 9 e conter 9 dígitos.";
    }

    if (!/^\d{9}[A-Z]{2}\d{3}$/.test(novoUsuario.bi)) {
      erros.bi = "BI inválido: deve seguir o formato 000000000XX000.";
    }

    const biDuplicado = usuarios.some((u) => u.bi === novoUsuario.bi);
    if (biDuplicado) {
      erros.bi = "Já existe um usuário com esse número de BI.";
    }

    setErros(erros);
    return Object.keys(erros).length === 0;
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    if (name === "telefone") {
      const onlyNumbers = value.replace(/\D/g, "");
      if (/^9\d{0,8}$/.test(onlyNumbers)) {
        setNovoUsuario({ ...novoUsuario, telefone: onlyNumbers });
        setErros((prev) => ({ ...prev, telefone: "" }));
      } else {
        setErros((prev) => ({
          ...prev,
          telefone: "Telefone deve começar com 9 e conter até 9 dígitos.",
        }));
      }
    } else if (name === "bi") {
      const upper = value.toUpperCase().replace(/[^0-9A-Z]/g, "");
      if (upper.length > 14) return;

      const isValidPartial = /^[0-9]{0,9}[A-Z]{0,2}[0-9]{0,3}$/.test(upper);
      if (isValidPartial) {
        setNovoUsuario({ ...novoUsuario, bi: upper });
        setErros((prev) => ({ ...prev, bi: "" }));
      } else {
        setErros((prev) => ({
          ...prev,
          bi: "BI deve seguir o formato 000000000XX000 (letras maiúsculas).",
        }));
      }
    } else {
      setNovoUsuario({ ...novoUsuario, [name]: value });
    }
  };

  const registrarUsuario = async () => {
    if (!validar()) return;

    try {
      await api.post("/v1/Register", novoUsuario);
      setShowModal(false);
      setNovoUsuario({
        nome: "",
        sobreNome: "",
        email: "",
        password: "",
        telefone: "",
        bi: "",
      });
      carregarUsuarios();
    } catch (error) {
      console.error("Erro ao registrar usuário:", error);
    }
  };

  const usuariosFiltrados = usuarios.filter((usuario) =>
    `${usuario.nome} ${usuario.sobreNome}`
      .toLowerCase()
      .includes(searchTerm.toLowerCase())
  );

  const totalPages = Math.ceil(usuariosFiltrados.length / pageSize);
  const usuariosPaginados = usuariosFiltrados.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  return (
    <section className="usuarioMain">
      {/* Header */}
      <div className="usuarioHeader">
        <button className="usuarioBtnAdd" onClick={() => setShowModal(true)}>
          <FaPlus />
          Add Usuário
        </button>
        <div className="usuarioBuscar">
          <input
            type="text"
            placeholder="Buscar Usuário..."
            value={searchTerm}
            onChange={(e) => {
              setSearchTerm(e.target.value);
              setCurrentPage(1);
            }}
          />
          <button className="usuarioBtnSearch">
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      {/* Tabela */}
      <div className="usuarioTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Nome Completo</th>
              <th>Email</th>
              <th>BI</th>
              <th>Perfil</th>
              <th>Ação</th>
            </tr>
          </thead>
          <tbody>
            {usuariosPaginados.length > 0 ? (
              usuariosPaginados.map((usuario) => (
                <tr key={usuario.id}>
                  <td>{usuario.id}</td>
                  <td>{`${usuario.nome} ${usuario.sobreNome}`}</td>
                  <td>{usuario.email}</td>
                  <td>{usuario.bi}</td>
                  <td>{usuario.perfil?.nome}</td>
                  <td className="acoes">
                    <button title="Editar"><FaPen /></button>
                    <button title="Detalhes"><FaInfo /></button>
                    <button title="Perfil"><FaUser /></button>
                    <button title="Eliminar"><FaTrash /></button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan={6}>Nenhum usuário encontrado.</td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {/* Paginação */}
      <div className="paginacao">
        <button
          onClick={() => setCurrentPage((p) => Math.max(p - 1, 1))}
          disabled={currentPage === 1}
        >
          Anterior
        </button>
        <span>
          Página {currentPage} de {totalPages || 1}
        </span>
        <button
          onClick={() => setCurrentPage((p) => Math.min(p + 1, totalPages))}
          disabled={currentPage === totalPages || totalPages === 0}
        >
          Próxima
        </button>
      </div>

      {/* Modal */}
      {showModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <button className="close-btn" onClick={() => setShowModal(false)}>
              <FaX />
            </button>
            <h2>Cadastrar Novo Usuário</h2>

            <input name="nome" type="text" placeholder="Nome" value={novoUsuario.nome} onChange={handleChange} />
            <input name="sobreNome" type="text" placeholder="Sobrenome" value={novoUsuario.sobreNome} onChange={handleChange} />
            <input name="email" type="email" placeholder="Email" value={novoUsuario.email} onChange={handleChange} />
            <input name="password" type="password" placeholder="Senha" value={novoUsuario.password} onChange={handleChange} />

            <input name="telefone" type="text" placeholder="Telefone (começa com 9)" value={novoUsuario.telefone} onChange={handleChange} />
            {erros.telefone && <small className="erro">{erros.telefone}</small>}

            <input name="bi" type="text" placeholder="BI (000000000XX000)" value={novoUsuario.bi} onChange={handleChange} />
            {erros.bi && <small className="erro">{erros.bi}</small>}

            <div className="modal-actions">
              <button className="btn-salvar" onClick={registrarUsuario}>Salvar</button>
              <button className="btn-cancelar" onClick={() => setShowModal(false)}>Cancelar</button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default Usuarios;
