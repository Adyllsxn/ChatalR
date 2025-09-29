import { useEffect, useState, useCallback, useMemo } from 'react';
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

interface Usuario {
  id: number;
  nome: string;
  sobreNome: string;
  email: string;
  fotoUrl: string;
  perfilID: number;
  perfil: {
    id: number;
    nome: string;
  };
  dataCadastro: string;
  telefone: string;
  bi: string;
}

export default function Dashboard() {
  const [dados, setDados] = useState<DashboardData | null>(null);
  const [contadores, setContadores] = useState({
    administradores: 0,
    organizadores: 0,
    membros: 0,
  });

  const authorization = useMemo(() => {
    const token = localStorage.getItem('token');
    return {
      headers: {
        Authorization: `Bearer ${token ?? ''}`,
      },
    };
  }, []);

  const extrairValor = (texto: string, chave: string): number => {
    const regex = new RegExp(`${chave}:\\s*(\\d+)`, 'i');
    const match = texto.match(regex);
    return match ? parseInt(match[1], 10) : 0;
  };

  const carregarDashboard = useCallback(async () => {
    try {
      const response = await apiservice.get('/v1/GetDashboard', authorization);
      const texto: string = response.data;

      const valores = {
        perfil: extrairValor(texto, 'PERFIL'),
        usuario: extrairValor(texto, 'USUARIO'),
        tipoEvento: extrairValor(texto, 'TIPO DE EVENTO'),
        evento: extrairValor(texto, 'EVENTOS'),
        presenca: extrairValor(texto, 'PRESENCA'),
        blogPost: extrairValor(texto, 'BLOG POST'),
      };

      setDados(valores);
    } catch (error) {
      console.error('Erro ao carregar o dashboard:', error);
      alert('Erro ao carregar dados do dashboard.');
    }
  }, [authorization]);

  const carregarUsuarios = useCallback(async () => {
    try {
      const response = await apiservice.get<{ data: Usuario[] }>('/v1/ListUsuario', authorization);
      const lista = response.data.data;

      const admin = lista.filter(u => u.perfilID === 1).length;
      const orgs = lista.filter(u => u.perfilID === 2).length;
      const membros = lista.filter(u => u.perfilID === 3).length;

      setContadores({
        administradores: admin,
        organizadores: orgs,
        membros: membros,
      });
    } catch (error) {
      console.error('Erro ao carregar usuários:', error);
    }
  }, [authorization]);

  useEffect(() => {
    carregarDashboard();
    carregarUsuarios();
  }, [carregarDashboard, carregarUsuarios]);

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
        <PieChart width={700} height={280}>
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

      <div className='perfilUsuario'>
        <div className='administradores'>
          <div>{contadores.administradores}</div>
          <p>Administradores</p>
        </div>

        <div className='organizadores'>
          <div>{contadores.organizadores}</div>
          <p>Organizadores</p>
        </div>

        <div className='membros'>
          <div>{contadores.membros}</div>
          <p>Membros Comuns</p>
        </div>
      </div>
    </div>
  );
}
