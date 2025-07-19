import { FaInfo, FaMagnifyingGlass, FaPen, FaPlus, FaTrash } from "react-icons/fa6";
import { Link } from "react-router-dom";
import "./Blog.css";

const Blog = () => {
  return (
    <section className="blogMain">
      <div className="blogHeader">
        <Link to="#" className="blogBtnAdd">
          <FaPlus />
          Criar Post
        </Link>
        <div className="blogBuscar">
          <input type="text" placeholder="Buscar Post..." />
          <button className="blogBtnSearch">
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      <div className="blogTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Tutulo</th>
              <th>Data</th>
              <th>Ação</th>
            </tr>
          </thead>
          <tbody>
                <tr>
                  <td>1</td>
                  <td>Agno</td>
                  <td>01 / 09 / 2025</td>
                  <td className="acoes">
                    <button
                      title="Editar">
                      <FaPen />
                    </button>
                    <button
                      title="Detalhes">
                      <FaInfo />
                    </button>
                    <button
                      title="Arquivar">
                      <FaInfo />
                    </button>
                    <button
                      title="Publicar">
                      <FaInfo />
                    </button>
                    <button
                      title="Eliminar">
                      <FaTrash />
                    </button>
                  </td>
                </tr>
              <tr>
                <td colSpan={3}>Nenhum pos encontrado.</td>
              </tr>
          </tbody>
        </table>
      </div>
    </section>
  );
};

export default Blog;
