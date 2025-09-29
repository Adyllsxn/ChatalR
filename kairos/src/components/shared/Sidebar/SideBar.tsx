import { useEffect, useState } from 'react';
import { NavLink } from 'react-router-dom';
import './SideBar.css';
import {
  FaBlog,
  FaChartPie,
  FaTags
} from 'react-icons/fa6';
import {
  FaCalendarAlt,
  FaUsersCog
} from 'react-icons/fa';

export default function Sidebar() {
  const [perfilID, setPerfilID] = useState<number | null>(null);

  useEffect(() => {
    const storedPerfilID = localStorage.getItem('perfilID');
    if (storedPerfilID) {
      setPerfilID(parseInt(storedPerfilID, 10));
    }
  }, []);

  const acessoTotal = perfilID === 1;

  return (
    <aside className="sidebar">
      <nav>
        <NavLink to="/administrativa/dashboard" className="nav-link">
          <FaChartPie />Dashboard
        </NavLink>

        <NavLink to="/administrativa/eventos" className="nav-link">
          <FaCalendarAlt />Eventos
        </NavLink>
        
        {acessoTotal && (
          <NavLink to="/administrativa/tipos" className="nav-link">
            <FaTags />Tipos
          </NavLink>
        )}

        {acessoTotal && (
          <NavLink to="/administrativa/usuarios" className="nav-link">
            <FaUsersCog />Usuários
          </NavLink>
        )}

        <NavLink to="/administrativa/blog" className="nav-link">
          <FaBlog />Blog
        </NavLink>
      </nav>
    </aside>
  );
}
