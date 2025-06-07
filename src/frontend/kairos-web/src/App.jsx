import React, { useState } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';

import Header from './components/Header';
import Administrativa from './components/shared/Administrativa';
import Footer from './components/Footer';
import Ajuda from './pages/public/Ajuda';
import FAQ from './pages/public/FAQ';
import SobreNos from './pages/public/SobreNos';
import PoliticaDePrivacidade from './pages/public/PoliticaDePrivacidade';
import Home from './pages/Home';
import Login from './pages/public/Login';
import Listar from './pages/evento/Listar';
import Detalhes from './pages/evento/Detalhes';
import AlterarSenha from './pages/perfil/AlterarSenha';
import VerPerfil from './pages/perfil/VerPerfil';

import './styles/App.css';

export default function App() {
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
        <Route path="/administrativa" element={<Administrativa />} />
        <Route path="/ajuda" element={<Ajuda />} />
        <Route path="/faq" element={<FAQ />} />
        <Route path="/sobreNos" element={<SobreNos />} />
        <Route path="/politicaDePrivacidade" element={<PoliticaDePrivacidade />} />
        <Route path="/listarEvento" element={<Listar />} />
        <Route path="/detalhesEvento" element={<Detalhes />} />
        <Route path="/verPerfil" element={<VerPerfil />} />
        <Route path="/alterarSenha" element={<AlterarSenha />} />
      </Routes>
      <Footer />
    </>
  );
}
