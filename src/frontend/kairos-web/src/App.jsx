import React, { useState } from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';

import Header from './components/Header';
import Footer from './components/Footer';
import Administrativa from './containers/shared/Administrativa';
import Ajuda from './containers/pages/institucional/Ajuda';
import FAQ from './containers/pages/institucional/FAQ';
import SobreNos from './containers/pages/institucional/SobreNos';
import PoliticaDePrivacidade from './containers/pages/politica/PoliticaDePrivacidade';
import Home from './containers/pages/Home';
import Login from './containers/features/auth/Login';
import Listar from './containers/features/evento/Listar';
import Detalhes from './containers/features/evento/Detalhes';
import AlterarSenha from './containers/features/perfil/AlterarSenha';
import VerPerfil from './containers/features/perfil/VerPerfil';

import './App.css';

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
