import "./PresencaList.css";
import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { FaEye } from "react-icons/fa";
import apiservice from "../../../../core/service/api";

type Evento = {
  id: number;
  titulo: string;
  descricao?: string;
  dataHoraInicio?: string;
  dataHoraFim?: string;
  local?: string;
  imagemUrl?: string;
};

type Presenca = {
  id: number;
  eventoID: number;
  evento: Evento;
  dataHoraCheckin: string;
};

const PresencaList = () => {
  const [presencas, setPresenca] = useState<Presenca[]>([]);

  async function getPresencas() {
    try {
      const response = await apiservice.get("/v1/SearchPresenca");
      const data = response.data?.data;

      // Garante que não quebre mesmo com null ou erro
      setPresenca(Array.isArray(data) ? data : []);
    } catch (error) {
      console.error("Erro ao buscar presenças:", error);
      setPresenca([]);
    }
  }

  useEffect(() => {
    getPresencas();
  }, []);

  return (
    <section className="presencaSection">
      <div className="layoutContainer">
        <h1>Minhas Presenças</h1>

        {presencas.length === 0 ? (
          <div className="semPresenca">
            <p>⚠️ Você ainda não participou de nenhum evento.</p>
          </div>
        ) : (
          presencas.map((presenca) => (
            <div className="presencaContext" key={presenca.id}>
              <div>
                <p>
                  <strong>Título:</strong>{" "}
                  <span>{presenca.evento?.titulo || "Evento sem título"}</span>
                </p>
              </div>

              <div>
                <Link
                  to="/eventoDetails"
                  state={{ evento: presenca.evento }}
                  className="btnDetalhes"
                >
                  <FaEye style={{ marginRight: "5px" }} />
                  Ver Detalhes
                </Link>
              </div>
            </div>
          ))
        )}
      </div>
    </section>
  );
};

export default PresencaList;
