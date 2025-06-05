import React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import '../../styles/evento/Detalhe.css';

export default function Detalhes() {
  const location = useLocation();
  const navigate = useNavigate();
  const evento = location.state?.evento;

  if (!evento) {
    navigate('/');
    return null;
  }

  return (
    <main>
      <div className='layout-container'>
        <section className='evento-detalhe-content'>
          <div className='evento-detalhes'>

            <div className='evento-detalhe-img'>
              <img src={`http://localhost:5232/${evento.imagemUrl}`}  alt={evento.titulo} />
            </div>

            <div className='evento-detalhe-inf'>
              <p><strong>Título</strong> : {evento.titulo}</p>
              <p><strong>Descrição</strong> : {evento.descricao}</p>
              <p><strong>Local</strong> : {evento.local}</p>
              <p><strong>Data e Hora de Início</strong> : {new Date(evento.dataHoraInicio).toLocaleString()}</p>
              <p><strong>Data e Hora do Fim</strong> : {new Date(evento.dataHoraFim).toLocaleString()}</p>
            </div>

          </div>
        </section>
      </div>
    </main>
  );
}
