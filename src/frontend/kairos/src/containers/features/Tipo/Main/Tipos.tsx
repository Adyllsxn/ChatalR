import {
  FaInfo,
  FaMagnifyingGlass,
  FaPen,
  FaPlus,
  FaTrash,
} from "react-icons/fa6";
import "./Tipos.css";
import { Link } from "react-router-dom";

const Tipos = () => {
  
  return (
    <section className="tipoMain">
      <div className="tipoHeader">
        <Link to="#" className="tipoBtnAdd">
          <FaPlus />
          Add Tipo
        </Link>
        <div className="tipoBuscar">
          <input type="text" placeholder="Buscar Tipo de Evento..." />
          <button className="tipoBtnSearch">
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
            <tr>
              <td>1</td>
              <td>Retiro</td>
              <td className="acoes">
                <button title="Editar">
                  <FaPen />
                </button>
                <button title="Detalhes">
                  <FaInfo />
                </button>
                <button title="Eliminar">
                  <FaTrash />
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

    </section>
  );
};

export default Tipos;
