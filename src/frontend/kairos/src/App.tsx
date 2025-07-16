import { Routes, Route, Navigate } from 'react-router-dom';
import { useState } from 'react';

import Header from './components/layouts/Header/Header';
import Footer from './components/layouts/Footer/Footer';
import Home   from './containers/pages/Home/Main/Home';
import Ajuda  from './containers/pages/Institucional/Ajuda/Ajuda';
import FAQ from './containers/pages/Institucional/FAQ/FAQ';
import SobreNos from './containers/pages/Institucional/SobreNos/SobreNos';
import PoliticaDePrivacidade from './containers/pages/Politica/PoliticaDePrivacidade';
import AdminLayout from './containers/pages/Administrativa/AdminLayout';
import Dashboard from './containers/pages/Dashboard/Dashboard';
import EventoList from './containers/features/Evento/List/EventoList';
import EventoDetails from './containers/features/Evento/Details/EventoDetails';
import UsuarioView from './containers/features/Usuario/View/UsuarioView'
import UsuarioEdit from './containers/features/Usuario/Edit/UsuarioEdit';
import BlogList from './containers/features/Blog/List/BlogList';
import BlogView from './containers/features/Blog/Views/BlogView';
import PresencaList from './containers/features/Presenca/PresencaList';
import Login from './containers/features/Auth/Login/Login';

import './core/style/App.css';
import './core/style/index.css';


function App() {
  
  const [isLoggedIn, setIsLoggedIn] = useState(() => {
    // Verifica se já tem token salvo
    return !!localStorage.getItem('token');
  });

  function handleLogin() {
    setIsLoggedIn(true);
  }

  function handleLogout() {
    localStorage.removeItem('email');
    localStorage.removeItem('token');
    setIsLoggedIn(false);
  }

  if (!isLoggedIn) {
    return <Login onLogin={handleLogin} />
  }

  return (
    <>
      <Header onLogout={handleLogout} />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Navigate to="/" replace />} />
          <Route path="/ajuda" element={<Ajuda />} />
          <Route path="/faq" element={<FAQ />} />
          <Route path="/sobreNos" element={<SobreNos />} />
          <Route path="/politicaDePrivacidade" element={<PoliticaDePrivacidade />} />
          <Route path="/minhasPresencas" element={<PresencaList />} />
          <Route path="/eventoList" element={<EventoList />} />
          <Route path="/eventoDetails" element={<EventoDetails />} />
          <Route path="/usuarioView" element={<UsuarioView />} />
          <Route path="/usuarioEdit" element={<UsuarioEdit />} />
          <Route path="/blogList" element={<BlogList />} />
          <Route path="/blogView" element={<BlogView />} />

          <Route path="/administrativa" element={<AdminLayout />}>
            <Route index element={<Navigate to="dashboard" replace />} />
            <Route path="dashboard" element={<Dashboard />} />
          </Route>
        </Routes>
      <Footer />
    </>
  )
}

export default App
