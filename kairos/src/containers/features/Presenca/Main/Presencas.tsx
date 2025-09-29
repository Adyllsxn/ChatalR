import { FaSearch } from "react-icons/fa";
import "./Presencas.css";

const Presencas = () => {
  return (
    <section className="presensaMain">
      <div className="presencaHeader">
        <div className="presencaNumero">
          <h3>20</h3>
        </div>
        <div className="presencaBuscar">
          <input type="text" placeholder="Presença por Eventos..." />
          <button className="presencaBtnSearch">
            <FaSearch />
          </button>
        </div>
      </div>

      <div className="presencaTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Evento</th>
              <th>Usuário</th>
              <th>Confirmação</th>
              <th>Data</th>
            </tr>
          </thead>

          <tbody>
            <tr>
              <td>1</td>
              <td>Retiro</td>
              <td>Domingos Nascimento</td>
              <td><p className="presencaEstado">Sim</p></td>
              <td>02/05/2025</td>
            </tr>

            <tr>
              <td>2</td>
              <td>Retiro</td>
              <td>Domingos Nascimento</td>
              <td><p className="presencaEstado">Sim</p></td>
              <td>02/05/2025</td>
            </tr>
            <tr>
              <td>3</td>
              <td>Retiro</td>
              <td>Domingos Nascimento</td>
              <td><p className="presencaEstado">Sim</p></td>
              <td>02/05/2025</td>
            </tr>
            <tr>
              <td>4</td>
              <td>Retiro</td>
              <td>Domingos Nascimento</td>
              <td><p className="presencaEstado">Sim</p></td>
              <td>02/05/2025</td>
            </tr>
            <tr>
              <td>5</td>
              <td>Retiro</td>
              <td>Domingos Nascimento</td>
              <td><p className="presencaEstado">Sim</p></td>
              <td>02/05/2025</td>
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

export default Presencas;
