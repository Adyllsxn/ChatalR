import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import './style/TipoEventoCriar.css';
export default function TipoEventoCriar() {
  const navigate = useNavigate();
  const [tipoEvento, setTipoEvento] = useState({ nome: '' });
  const [alerta, setAlerta] = useState({ message: '', type: '' });

  const handleChange = (e) => {
    setTipoEvento({ ...tipoEvento, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      const payload = { nome: tipoEvento.nome };

      await apiservice.post('/v1/CreateTipoEvento', payload, config);

      setAlerta({ message: 'Tipo de evento criado com sucesso.', type: 'success' });

      setTimeout(() => navigate('/tipo-evento'), 2000);
    } catch (error) {
      console.error('Erro ao criar tipo de evento:', error);
      setAlerta({ message: 'Erro ao criar tipo de evento.', type: 'error' });
    }
  };

  return (
    <main>
      <section className="tipo-evento-criar-section">
        <div className="layout-container">
          <h1>Cadastrar Novo Tipo de Evento</h1>

          {alerta.message && (
            <Alert message={alerta.message} type={alerta.type} onClose={() => setAlerta({ message: '', type: '' })} />
          )}

          <form onSubmit={handleSubmit} className="tipo-evento-criar-form">
            <label htmlFor="nome">Nome:</label>
            <input
              type="text"
              id="nome"
              name="nome"
              value={tipoEvento.nome}
              onChange={handleChange}
              required
            />

            <div className="tipo-evento-criarr-botoes">
              <button type="submit" className="tipo-evento-criar-btn-salvar">Salvar</button>
              <button type="button" className="tipo-evento-criar-btn-cancelar" onClick={() => navigate('/tipo-evento')}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      </section>
    </main>
  );
}
