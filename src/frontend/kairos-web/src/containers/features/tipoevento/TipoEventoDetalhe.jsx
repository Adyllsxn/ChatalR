import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import './style/TipoEventoDetalhe.css'

export default function TipoEventoDetalhes() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [tipoEvento, setTipoEvento] = useState(null);
  const [alerta, setAlerta] = useState({ message: '', type: '' });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const carregarDetalhes = async () => {
      try {
        const token = localStorage.getItem('token');
        const config = { headers: { Authorization: `Bearer ${token}` } };
        // Ajuste aqui: usar query param
        const response = await apiservice.get(`/v1/TipoEventoById?Id=${id}`, config);
        const dados = response?.data?.data;
        if (dados) {
          setTipoEvento(dados);
        } else {
          setTipoEvento(null);
          setAlerta({ message: 'Tipo de evento não encontrado.', type: 'error' });
        }
      } catch (error) {
        console.error('Erro ao carregar detalhes:', error);
        setAlerta({ message: 'Erro ao carregar detalhes do tipo de evento.', type: 'error' });
        setTipoEvento(null);
      } finally {
        setLoading(false);
      }
    };

    carregarDetalhes();
  }, [id]);

  if (loading) return <p>Carregando detalhes...</p>;

  if (!tipoEvento) return <p>Tipo de evento não encontrado.</p>;

  return (
    <main>
      <section className="tipo-evento-detahes-section">
        <div className="layout-container">
          {alerta.message && (
            <Alert message={alerta.message} type={alerta.type} onClose={() => setAlerta({ message: '', type: '' })} />
          )}

          <h1>Detalhes do Tipo de Evento</h1>

          <div className="tipo-evento-detahes-container">
            <p><strong>ID:</strong> {tipoEvento.id}</p>
            <p><strong>Nome:</strong> {tipoEvento.nome}</p>
            {/* Caso existam mais campos, exiba aqui */}
          </div>

          <button className="tipo-evento-detahes-btn-cadastrar" onClick={() => navigate(-1)}>
            Voltar
          </button>
        </div>
      </section>
    </main>
  );
}
