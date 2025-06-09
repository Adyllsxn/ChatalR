import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import './style/TipoEventoEditar.css';

export default function TipoEventoEdit() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [tipoEvento, setTipoEvento] = useState({ nome: '' });
  const [alerta, setAlerta] = useState({ message: '', type: '' });
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const carregarTipoEvento = async () => {
      try {
        const token = localStorage.getItem('token');
        const config = { headers: { Authorization: `Bearer ${token}` } };

        const response = await apiservice.get(`/v1/TipoEventoById?Id=${id}`, config);
        const dados = response?.data?.data;

        if (dados) {
          setTipoEvento({ nome: dados.nome });
        } else {
          setAlerta({ message: 'Tipo de evento não encontrado.', type: 'error' });
        }
      } catch (error) {
        console.error('Erro ao carregar tipo de evento:', error);
        setAlerta({ message: 'Erro ao carregar tipo de evento.', type: 'error' });
      } finally {
        setLoading(false);
      }
    };

    carregarTipoEvento();
  }, [id]);

  const handleChange = (e) => {
    setTipoEvento({ ...tipoEvento, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      // ✅ Incluindo ID no corpo da requisição como exigido pela API
      const payload = {
        id: parseInt(id), // Garante que vai como número
        nome: tipoEvento.nome
      };

      await apiservice.put(`/v1/UpdateTipoEvento`, payload, config);

      setAlerta({ message: 'Tipo de evento atualizado com sucesso.', type: 'success' });

      setTimeout(() => navigate('/tipo-evento'), 2000);
    } catch (error) {
      console.error('Erro ao atualizar tipo de evento:', error);
      setAlerta({ message: 'Erro ao atualizar tipo de evento.', type: 'error' });
    }
  };

  if (loading) return <p>Carregando dados...</p>;

  return (
    <main>
      <section className="tipo-evento-editar-section">
        <div className="layout-container">
          <h1>Editar Tipo de Evento</h1>

          {alerta.message && (
            <Alert message={alerta.message} type={alerta.type} onClose={() => setAlerta({ message: '', type: '' })} />
          )}

          <form onSubmit={handleSubmit} className="tipo-evento-editar-form">
            <label htmlFor="nome">Nome:</label>
            <input
              type="text"
              id="nome"
              name="nome"
              value={tipoEvento.nome}
              onChange={handleChange}
              required
            />

            <div className="tipo-evento-editar-botoes">
              <button type="submit" className="tipo-evento-editar-btn-salvar">Salvar</button>
              <button type="button" className="tipo-evento-editar-btn-cancelar" onClick={() => navigate('/tipo-evento')}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      </section>
    </main>
  );
}
