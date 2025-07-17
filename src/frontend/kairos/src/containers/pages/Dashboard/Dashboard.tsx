import { useEffect, useState } from 'react';
import {
  FaCalendarAlt,
  FaUsers,
  FaBlog
} from 'react-icons/fa';
import {
  PieChart,
  Pie,
  Cell,
  Tooltip,
  Legend
} from 'recharts';
import apiservice from '../../../core/service/api';
import './Dashboard.css';

interface DashboardData {
  perfil: number;
  usuario: number;
  tipoEvento: number;
  evento: number;
  presenca: number;
  blogPost: number;
}

export default function Dashboard() {
  const [dados, setDados] = useState<DashboardData | null>(null);

  const token = localStorage.getItem('token');
  const authorization = {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };

  useEffect(() => {
    apiservice
      .get('/v1/GetDashboard', authorization)
      .then((response) => {
        const texto: string = response.data;

        const valores = {
          perfil: extrairValor(texto, 'PERFIL'),
          usuario: extrairValor(texto, 'USUARIO'),
          tipoEvento: extrairValor(texto, 'TIPO DE EVENTO'),
          evento: extrairValor(texto, 'EVENTO'),
          presenca: extrairValor(texto, 'PRESENCA'),
          blogPost: extrairValor(texto, 'BLOG POST'),
        };

        setDados(valores);
      })
      .catch((error) => {
        console.error('Erro ao carregar o dashboard:', error);
        alert('Erro ao carregar dados do dashboard.');
      });
  }, []);

  const extrairValor = (texto: string, chave: string): number => {
    const regex = new RegExp(`${chave}:\\s*(\\d+)`, 'i');
    const match = texto.match(regex);
    return match ? parseInt(match[1], 10) : 0;
  };

  const cards = [
    {
      title: 'Eventos',
      value: dados?.evento ?? 0,
      icon: <FaCalendarAlt />,
      color: '#4e73df',
    },
    {
      title: 'Usuários',
      value: dados?.usuario ?? 0,
      icon: <FaUsers />,
      color: '#1cc88a',
    },
    {
      title: 'Blog',
      value: dados?.blogPost ?? 0,
      icon: <FaBlog />,
      color: '#36b9cc',
    },
  ];

  const pieData = [
    { name: 'Eventos', value: dados?.evento ?? 0 },
    { name: 'Usuários', value: dados?.usuario ?? 0 },
    { name: 'Blog Posts', value: dados?.blogPost ?? 0 },
    { name: 'Presenças', value: dados?.presenca ?? 0 },
  ];

  const COLORS = ['#4e73df', '#1cc88a', '#36b9cc', '#f6c23e'];

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

      <div className="chart-row">
        <PieChart width={700} height={300}>
          <Pie
            data={pieData}
            dataKey="value"
            nameKey="name"
            cx="50%"
            cy="50%"
            outerRadius={100}
            fill="#8884d8"
            label
          >
            {pieData.map((_, index) => (
              <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
            ))}
          </Pie>
          <Tooltip />
          <Legend />
        </PieChart>
      </div>
    </div>
  );
}
