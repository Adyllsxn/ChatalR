import { useEffect, useState, useMemo } from "react";
import {
  FaInfo,
  FaMagnifyingGlass,
  FaPen,
  FaPlus,
  FaTrash,
  FaBoxArchive,
  FaCloudArrowUp,
} from "react-icons/fa6";
import api from "../../../../core/service/api";
import "./Blog.css";

interface Usuario {
  nome: string;
  sobreNome: string;
}

interface BlogPost {
  id: number;
  titulo: string;
  conteudo?: string;
  dataPublicacao: string;
  status: number;
  imagemCapaUrl?: string;
  usuario?: Usuario;
}

const getStatusLabel = (status: number): string => {
  switch (status) {
    case 0: return "Rascunho";
    case 1: return "Publicado";
    case 2: return "Arquivado";
    default: return "Desconhecido";
  }
};

const getStatusClass = (status: number): string => {
  switch (status) {
    case 0: return "rascunho";
    case 1: return "publicado";
    case 2: return "arquivado";
    default: return "";
  }
};

export default function Blog() {
  const [posts, setPosts] = useState<BlogPost[]>([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [page, setPage] = useState(1);
  const [isModalCreate, setIsModalCreate] = useState(false);
  const [isModalDetail, setIsModalDetail] = useState(false);
  const [isModalEdit, setIsModalEdit] = useState(false);
  const [isModalDelete, setIsModalDelete] = useState(false);
  const [postToDelete, setPostToDelete] = useState<BlogPost | null>(null);
  const [current, setCurrent] = useState<BlogPost | null>(null);
  const [titulo, setTitulo] = useState("");
  const [conteudo, setConteudo] = useState("");
  const [imagemFile, setImagemFile] = useState<File | null>(null);
  const pageSize = 5;

  const authorization = useMemo(() => ({
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
    },
  }), []);

  useEffect(() => {
    load();
  }, []);

  const load = async () => {
    try {
      const response = await api.get("/v1/ListBlog");
      if (response.data?.data) setPosts(response.data.data);
    } catch (error) {
      console.error("Erro ao carregar posts:", error);
      alert("Erro ao carregar posts.");
    }
  };

  const search = async () => {
    if (!searchTerm.trim()) return;
    try {
      const r = await api.get(`/v1/SearchBlog?Titulo=${searchTerm}`);
      if (r.data?.data) {
        setPosts(r.data.data);
        setPage(1);
      }
    } catch (error) {
      console.error("Erro na busca:", error);
      alert("Erro na busca.");
    }
  };

  const criarPost = async () => {
    if (!titulo || !conteudo || !imagemFile) {
      return alert("Preencha todos os campos.");
    }

    const formData = new FormData();
    formData.append("Titulo", titulo);
    formData.append("Conteudo", conteudo);
    formData.append("ImagemCapaUrl", imagemFile);

    try {
      const r = await api.post("/v1/CreateBlog", formData, authorization);
      if (r.data?.isSuccess) {
        alert("Post criado com sucesso!");
        fecharModais();
        await load();
      }
    } catch (error) {
      console.error("Erro ao criar post:", error);
      alert("Erro ao criar post.");
    }
  };

  const abrirConfirmarDelete = (post: BlogPost) => {
    setPostToDelete(post);
    setIsModalDelete(true);
  };

  const deletarPost = async () => {
    if (!postToDelete) return;

    try {
      const r = await api.delete(`/v1/DeleteBlog?Id=${postToDelete.id}`, authorization);
      if (r.data?.isSuccess) {
        alert("Post deletado com sucesso.");
        setPosts(posts.filter((p) => p.id !== postToDelete.id));
        fecharModais();
      } else {
        alert("Erro ao deletar: " + r.data?.message);
      }
    } catch (error) {
      console.error("Erro ao deletar post:", error);
      alert("Erro ao deletar post.");
    }
  };

  const publicarPost = async (id: number) => {
    try {
      await api.patch("/v1/PublishBlog", { id }, authorization);
      await load();
    } catch (error) {
      console.error("Erro ao publicar post:", error);
      alert("Erro ao publicar.");
    }
  };

  const arquivarPost = async (id: number) => {
    try {
      await api.patch("/v1/ArchiveBlog", { id }, authorization);
      await load();
    } catch (error) {
      console.error("Erro ao arquivar post:", error);
      alert("Erro ao arquivar.");
    }
  };

  const verDetalhes = async (id: number) => {
    try {
      const r = await api.get(`/v1/GetByIdBlog?Id=${id}`);
      if (r.data?.data) {
        setCurrent(r.data.data);
        setIsModalDetail(true);
      }
    } catch (error) {
      console.error("Erro ao buscar detalhes:", error);
      alert("Erro ao carregar detalhes.");
    }
  };

  const abrirModalEdicao = async (id: number) => {
    try {
      const r = await api.get(`/v1/GetByIdBlog?Id=${id}`);
      if (r.data?.data) {
        const post = r.data.data;
        setCurrent(post);
        setTitulo(post.titulo);
        setConteudo(post.conteudo || "");
        setImagemFile(null);
        setIsModalEdit(true);
      }
    } catch (error) {
      console.error("Erro ao buscar post para edição:", error);
      alert("Erro ao carregar post.");
    }
  };

  const atualizarPost = async () => {
    if (!current?.id || !titulo || !conteudo) {
      return alert("Preencha os campos obrigatórios.");
    }

    const formData = new FormData();
    formData.append("Id", current.id.toString());
    formData.append("Titulo", titulo);
    formData.append("Conteudo", conteudo);
    if (imagemFile) {
      formData.append("ImagemCapaUrl", imagemFile);
    } else {
      formData.append("ImagemCapaUrl", current.imagemCapaUrl || "");
    }

    try {
      const r = await api.put("/v1/EditBlog", formData, {
        ...authorization,
        headers: {
          ...authorization.headers,
          "Content-Type": "multipart/form-data",
        },
      });

      if (r.data?.isSuccess) {
        alert("Post atualizado com sucesso!");
        fecharModais();
        await load();
      } else {
        alert("Erro: " + r.data?.message);
      }
    } catch (error) {
      console.error("Erro ao atualizar post:", error);
      alert("Erro ao atualizar post.");
    }
  };

  const fecharModais = () => {
    setIsModalCreate(false);
    setIsModalDetail(false);
    setIsModalEdit(false);
    setIsModalDelete(false);
    setTitulo("");
    setConteudo("");
    setImagemFile(null);
    setCurrent(null);
    setPostToDelete(null);
  };

  const postsPaginados = posts.slice((page - 1) * pageSize, page * pageSize);
  const totalPages = Math.ceil(posts.length / pageSize);


  return (
    <section className="blogMain">
      <div className="blogHeader">
        <button className="blogBtnAdd" onClick={() => setIsModalCreate(true)}>
          <FaPlus /> Criar Post
        </button>
        <div className="blogBuscar">
          <input
            type="text"
            placeholder="Buscar Post..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button className="blogBtnSearch" onClick={search}>
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      <div className="blogTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Título</th>
              <th>Estado</th>
              <th>Data</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {postsPaginados.length > 0 ? (
              postsPaginados.map((post) => (
                <tr key={post.id}>
                  <td>{post.id}</td>
                  <td>{post.titulo}</td>
                  <td>
                    <p className={`status ${getStatusClass(post.status)}`}>
                      {getStatusLabel(post.status)}
                    </p>
                  </td>
                  <td>{new Date(post.dataPublicacao).toLocaleDateString()}</td>
                  <td className="acoes">
                    <button title="Editar" onClick={() => abrirModalEdicao(post.id)}><FaPen /></button>
                    <button title="Detalhes" onClick={() => verDetalhes(post.id)}><FaInfo /></button>
                    {post.status === 1 && (
                      <button title="Arquivar" onClick={() => arquivarPost(post.id)}><FaBoxArchive /></button>
                    )}
                    {post.status === 0 && (
                      <button title="Publicar" onClick={() => publicarPost(post.id)}><FaCloudArrowUp /></button>
                    )}
                    <button title="Eliminar" onClick={() => abrirConfirmarDelete(post)}><FaTrash /></button>
                  </td>
                </tr>
              ))
            ) : (
              <tr><td colSpan={5}>Nenhum post encontrado.</td></tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="paginacao">
        <button onClick={() => setPage(p => Math.max(p - 1, 1))} disabled={page === 1}>Anterior</button>
        <span>Página {page} de {totalPages}</span>
        <button onClick={() => setPage(p => Math.min(p + 1, totalPages))} disabled={page === totalPages}>Próxima</button>
      </div>

      {/* Modal Criar */}
      {isModalCreate && (
        <div className="modal-overlay">
          <div className="modal">
            <h2>Criar Novo Post</h2>
            <label>Título *</label>
            <input value={titulo} onChange={(e) => setTitulo(e.target.value)} />
            <label>Conteúdo *</label>
            <textarea value={conteudo} onChange={(e) => setConteudo(e.target.value)} />
            <label>Imagem de Capa *</label>
            <input type="file" accept="image/*" onChange={(e) => setImagemFile(e.target.files?.[0] || null)} />
            <div className="modal-actions">
              <button onClick={criarPost}>Publicar</button>
              <button className="btn-cancelar" onClick={fecharModais}>Cancelar</button>
            </div>
          </div>
        </div>
      )}

      {/* Modal Detalhes */}
      {isModalDetail && current && (
        <div className="modal-overlay">
          <div className="modal">
            <h2>Detalhes do Post</h2>
            <p><strong>Título:</strong> {current.titulo}</p>
            <p><strong>Status:</strong> {getStatusLabel(current.status)}</p>
            <p><strong>Autor:</strong> {current.usuario?.nome} {current.usuario?.sobreNome}</p>
            <p><strong>Conteúdo:</strong> {current.conteudo}</p>
            <p><strong>Publicado em:</strong> {new Date(current.dataPublicacao).toLocaleDateString()}</p>
            {current.imagemCapaUrl && (
              <img src={`http://localhost:5232/${current.imagemCapaUrl}`} alt="Imagem Capa" />
            )}
            <div className="modal-actions">
              <button onClick={fecharModais}>Fechar</button>
            </div>
          </div>
        </div>
      )}

      {/* Modal Editar */}
      {isModalEdit && current && (
        <div className="modal-overlay">
          <div className="modal">
            <h2>Editar Post</h2>
            <label>Título *</label>
            <input value={titulo} onChange={(e) => setTitulo(e.target.value)} />
            <label>Conteúdo *</label>
            <textarea value={conteudo} onChange={(e) => setConteudo(e.target.value)} />
            <label>Imagem Atual:</label>
            {current.imagemCapaUrl && (
              <img src={`http://localhost:5232/${current.imagemCapaUrl}`} alt="Imagem Atual" />
            )}
            <label>Nova Imagem (opcional)</label>
            <input type="file" accept="image/*" onChange={(e) => setImagemFile(e.target.files?.[0] || null)} />
            <div className="modal-actions">
              <button onClick={atualizarPost}>Atualizar</button>
              <button className="btn-cancelar" onClick={fecharModais}>Cancelar</button>
            </div>
          </div>
        </div>
      )}

      {/* Modal Confirmar Exclusão */ }
      {isModalDelete && postToDelete && (
        <div className="modal-overlay">
          <div className="modal">
            <h2>Confirmar Exclusão</h2>
            <p>Deseja realmente excluir o post <strong>{postToDelete.titulo}</strong>?</p>
            <div className="modal-actions">
              <button onClick={deletarPost}>Sim</button>
              <button className="btn-cancelar" onClick={fecharModais}>Não</button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
}
