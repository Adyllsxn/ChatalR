import React, { useEffect, useState } from 'react';
import { FaEdit, FaTrash, FaInfoCircle, FaPlus, FaSearch } from 'react-icons/fa';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import { useNavigate } from 'react-router-dom';
import './style/TipoEvento.css';

export default function TipoEvento() {
  const [tiposEvento, setTiposEvento] = useState([]);
  const [alerta, setAlerta] = useState({ message: '', type: '' });
  const [busca, setBusca] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    carregarTiposEvento();
  }, []);

  const carregarTiposEvento = async () => {
    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      const response = await apiservice.get('/v1/TipoEventos', config);
      const dados = response?.data?.data;
      setTiposEvento(Array.isArray(dados) ? dados : []);
    } catch (error) {
      console.error('Erro ao carregar tipos de evento:', error);
      setAlerta({ message: 'Erro ao buscar tipos de evento.', type: 'error' });
    }
  };

  const buscarTipoPorNome = async () => {
    if (!busca.trim()) return carregarTiposEvento();

    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };
      const response = await apiservice.get(`/v1/SearchTipoEvento?Nome=${encodeURIComponent(busca)}`, config);
      const dados = response?.data?.data;
      setTiposEvento(Array.isArray(dados) ? dados : []);
    } catch (error) {
      console.error('Erro na busca:', error);
      setAlerta({ message: 'Erro ao buscar tipos de evento.', type: 'error' });
    }
  };

  const handleEditar = (id) => navigate(`/tipo-evento/editar/${id}`);
  const handleDetalhes = (id) => navigate(`/tipo-evento/detalhes/${id}`);
  const handleCadastrar = () => navigate(`/tipo-evento/novo`);

  const handleEliminar = async (id) => {
    if (window.confirm('Tem certeza que deseja eliminar este tipo de evento?')) {
      try {
        const token = localStorage.getItem('token');
        const config = { headers: { Authorization: `Bearer ${token}` } };
        await apiservice.delete(`/v1/DeleteTipoEvento?Id=${id}`, config);
        setAlerta({ message: 'Tipo de evento eliminado com sucesso.', type: 'success' });
        carregarTiposEvento();
      } catch (error) {
        console.error('Erro ao eliminar tipo:', error);
        setAlerta({ message: 'Erro ao eliminar tipo de evento.', type: 'error' });
      }
    }
  };

  return (
    <main>
      <section className='tipo-evento-section'>
        <div className='layout-container'>
          <div className="tipo-evento-header">
            <h1>Tipos de Evento</h1>
            <button className='tipo-evento-btn-cadastrar' onClick={handleCadastrar}>
              <FaPlus /> Cadastrar Tipo
            </button>
          </div>

          <div className="tipo-evento-busca-container">
            <input
              type="text"
              placeholder="Buscar por nome..."
              value={busca}
              onChange={(e) => setBusca(e.target.value)}
            />
            <button className="tipo-evento-btn-buscar" onClick={buscarTipoPorNome}>
              <FaSearch /> Buscar
            </button>
          </div>

          {alerta.message && (
            <Alert message={alerta.message} type={alerta.type} onClose={() => setAlerta({ message: '', type: '' })} />
          )}

          <table className='tipo-evento-tipo-evento-tabela'>
            <thead>
              <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
              {tiposEvento.map(tipo => (
                <tr key={tipo.id}>
                  <td>{tipo.id}</td>
                  <td>{tipo.nome}</td>
                  <td className="acoes">
                    <button onClick={() => handleEditar(tipo.id)} title="Editar"><FaEdit /></button>
                    <button onClick={() => handleDetalhes(tipo.id)} title="Detalhes"><FaInfoCircle /></button>
                    <button onClick={() => handleEliminar(tipo.id)} title="Eliminar"><FaTrash /></button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

          {tiposEvento.length === 0 && <p className='vazio'>Nenhum tipo de evento encontrado.</p>}
        </div>
      </section>
    </main>
  );
}
