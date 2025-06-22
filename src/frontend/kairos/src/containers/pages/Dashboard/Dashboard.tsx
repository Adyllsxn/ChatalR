import './Dashboard.css';
import {
  FaCalendarAlt,
  FaUsers,
  FaBoxOpen,
  FaBlog,
  FaCheckCircle
} from 'react-icons/fa';

export default function Dashboard() {
  const cards = [
    { title: 'Eventos', value: 14, icon: <FaCalendarAlt />, color: '#4e73df' },
    { title: 'Usuários', value: 8, icon: <FaUsers />, color: '#1cc88a' },
    { title: 'Tipos', value: 5, icon: <FaBoxOpen />, color: '#36b9cc' },
    { title: 'Blog', value: 5, icon: <FaBlog />, color: '#333333' },
    { title: 'Presença', value: 5, icon: <FaCheckCircle />, color: '#D9782C' }
  ];

  return (
    <div className="dashboard-container">


      <div className="card-row">
        {cards.map((card, index) => (
          <div
            className="card"
            key={index}
            style={{ borderLeft: `5px solid ${card.color}` }}
          >
            <div className="card-icon" style={{ color: card.color }} title={card.title}>
              {card.icon}
            </div>
            <div className="card-info">
              <h3>{card.value}</h3>
              <p>{card.title}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
