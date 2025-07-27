import { useLocation, useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import api from '../../../../core/service/api';
import './EventoDetails.css';

interface Presenca {
  usuarioID: number;
  eventoID: number;
  // outros campos se tiverem...
}

export default function Detalhes() {
  const location = useLocation();
  const navigate = useNavigate();
  const evento = location.state?.evento;

  const [mostrarPresenca, setMostrarPresenca] = useState(false);
  const [mensagemPresenca, setMensagemPresenca] = useState<string | null>(null);
  const [carregando, setCarregando] = useState(true);

  useEffect(() => {
    if (!evento) {
      navigate('/');
      return;
    }

    const agora = new Date();
    const inicio = new Date(evento.dataHoraInicio);
    const fim = new Date(evento.dataHoraFim);
    const userId = localStorage.getItem('userId');

    if (!userId) {
      setMensagemPresenca('⚠️ Usuário não autenticado.');
      setCarregando(false);
      return;
    }

    const eventoAtivo = agora >= inicio && agora <= fim;
    const eventoPassado = agora > fim;

    const verificarPresenca = async () => {
      try {
        const response = await api.get('/v1/ListPresenca');
        const presencas: Presenca[] = response.data?.data || [];

        const jaRespondeu = presencas.some(
          (p) =>
            p.usuarioID === parseInt(userId) &&
            p.eventoID === evento.id
        );

        if (jaRespondeu) {
          setMostrarPresenca(false);
          setMensagemPresenca('⚠️ Você já respondeu sobre este evento.');
        } else if (eventoAtivo) {
          setMostrarPresenca(true);
        } else if (eventoPassado) {
          setMensagemPresenca('⏳ Este evento já ocorreu e você não participou.');
        }
      } catch (err) {
        console.error('Erro ao verificar presença:', err);
        setMensagemPresenca('❗ Erro ao verificar presença. Tente novamente.');
      } finally {
        setCarregando(false);
      }
    };

    verificarPresenca();
  }, [evento, navigate]);

  const registrarPresenca = async (confirmado: boolean) => {
    if (!evento) return;

    try {
      await api.post('/v1/CreatePresenca', {
        eventoID: evento.id,
        confirmado: confirmado,
      });

      setMostrarPresenca(false);
      if (confirmado) {
        setMensagemPresenca('✅ Presença confirmada! Obrigado pela resposta.');
      } else {
        setMensagemPresenca('❌ Você optou por não participar deste evento.');
      }
    } catch (error) {
      console.error('Erro ao registrar presença:', error);
      setMensagemPresenca('❗ Não foi possível registrar sua resposta. Tente novamente.');
    }
  };

  if (!evento) return null;

  return (
    <main>
      <section className="evento-detalhe-content">
        <div className="layoutContainer">
          <h1>Detalhes do Evento</h1>

          <div className="evento-detalhes">
            <div className="evento-detalhe-img">
              <img
                src={`http://localhost:5232/${evento.imagemUrl}`}
                alt={evento.titulo}
              />
            </div>

            <div className="evento-detalhe-inf">
              <p><strong>Título:</strong> {evento.titulo}</p>
              <p><strong>Descrição:</strong> {evento.descricao}</p>
              <p><strong>Local:</strong> {evento.local}</p>
              <p><strong>Data de Início:</strong> {new Date(evento.dataHoraInicio).toLocaleString()}</p>
              <p><strong>Data de Fim:</strong> {new Date(evento.dataHoraFim).toLocaleString()}</p>
            </div>
          </div>

          {/* Seção de presença */}
          {!carregando && mostrarPresenca && (
            <div className="eventoPresenca">
              <h2>Desejas Participar do evento?</h2>
              <div>
                <button onClick={() => registrarPresenca(true)}>Sim</button>
                <button onClick={() => registrarPresenca(false)}>Não</button>
              </div>
            </div>
          )}

          {!carregando && mensagemPresenca && (
            <p className="mensagemPresenca">{mensagemPresenca}</p>
          )}
        </div>
      </section>
    </main>
  );
}
