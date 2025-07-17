import { FaEdit, FaInfoCircle, FaSearch } from "react-icons/fa";
import { FaPlus, FaTrash } from "react-icons/fa6";
import "./Eventos.css";
import { Link } from "react-router-dom";

const Eventos = () => {
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
            <FaSearch />
          </button>
        </div>
      </div>

      <div className="eventoTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Titulo</th>
              <th>Local</th>
              <th>Estado</th>
              <th>Ação</th>
            </tr>
          </thead>

          <tbody>
            <tr>
              <td>1</td>
              <td>Monte da Oração</td>
              <td>Luanda</td>
              <td className="pendenteEstado"><p>Aprovado</p></td>
              <td className="acoes">
                <button title="Editar"><FaEdit /></button>
                <button title="Detalhes"><FaInfoCircle /></button>
                <button title="Reijetar"><FaInfoCircle /></button>
                <button title="Aprovar"><FaInfoCircle /></button>
                <button title="Eliminar"><FaTrash /></button>
              </td>
            </tr>


            <tr>
              <td>2</td>
              <td>Monte da Oração</td>
              <td>Luanda</td>
              <td className="pendenteEstado"><p>Aprovado</p></td>
              <td className="acoes">
                <button title="Editar"><FaEdit /></button>
                <button title="Detalhes"><FaInfoCircle /></button>
                <button title="Reijetar"><FaInfoCircle /></button>
                <button title="Aprovar"><FaInfoCircle /></button>
                <button title="Eliminar"><FaTrash /></button>
              </td>
            </tr>
            <tr>
              <td>3</td>
              <td>Monte da Oração</td>
              <td>Luanda</td>
              <td className="pendenteEstado"><p>Aprovado</p></td>
              <td className="acoes">
                <button title="Editar"><FaEdit /></button>
                <button title="Detalhes"><FaInfoCircle /></button>
                <button title="Reijetar"><FaInfoCircle /></button>
                <button title="Aprovar"><FaInfoCircle /></button>
                <button title="Eliminar"><FaTrash /></button>
              </td>
            </tr>
            <tr>
              <td>4</td>
              <td>Monte da Oração</td>
              <td>Luanda</td>
              <td className="pendenteEstado"><p>Aprovado</p></td>
              <td className="acoes">
                <button title="Editar"><FaEdit /></button>
                <button title="Detalhes"><FaInfoCircle /></button>
                <button title="Reijetar"><FaInfoCircle /></button>
                <button title="Aprovar"><FaInfoCircle /></button>
                <button title="Eliminar"><FaTrash /></button>
              </td>
            </tr>
            <tr>
              <td>5</td>
              <td>Monte da Oração</td>
              <td>Luanda</td>
              <td className="pendenteEstado"><p>Aprovado</p></td>
              <td className="acoes">
                <button title="Editar"><FaEdit /></button>
                <button title="Detalhes"><FaInfoCircle /></button>
                <button title="Reijetar"><FaInfoCircle /></button>
                <button title="Aprovar"><FaInfoCircle /></button>
                <button title="Eliminar"><FaTrash /></button>
              </td>
            </tr>
            
          </tbody>
        </table>
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
