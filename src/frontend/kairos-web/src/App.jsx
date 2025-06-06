{/* Header*/}
import Header from './components/Header'
import Administrativa from './components/shared/Administrativa'

{/* Footer*/}
import Footer from './components/Footer'
import Ajuda from './pages/public/Ajuda';
import FAQ from './pages/public/FAQ';
import SobreNos from './pages/public/SobreNos';
import PoliticaDePrivacidade from './pages/public/PoliticaDePrivacidade';

{/* Home*/}
import Home from './pages/Home'
import Login from './pages/public/Login'

{/* Evento*/}
import Listar from './pages/evento/Listar';
import Detalhes from './pages/evento/Detalhes';

{/* Perfil*/}
import AlterarSenha from './pages/perfil/AlterarSenha';
import VerPerfil from './pages/perfil/VerPerfil';

{/* React*/}
import { Routes, Route, Navigate } from 'react-router-dom';
import React, { useState } from 'react'

{/* Css*/}
import './styles/App.css'



function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)

  function handleLogin() {
    setIsLoggedIn(true)
  }

  function handleLogout() {
    setIsLoggedIn(false)
  }

  if (isLoggedIn) {
    return <Login onLogin={handleLogin} />
  }

  return (
    <>
      <Header onLogout={handleLogout} />
      <Routes>

        {/* Home*/}
        <Route path="/" element={<Home />} />
        
        {/* Login*/}
        <Route path="/login" element={<Navigate to="/" replace />} />

        {/* Header*/}
        <Route path="/administrativa" element={<Administrativa />} />

        {/* Footer*/}
        <Route path="/ajuda" element={<Ajuda />} />
        <Route path="/faq" element={<FAQ />} />
        <Route path="/sobreNos" element={<SobreNos />} />
        <Route path="/politicaDePrivacidade" element={<PoliticaDePrivacidade />} />

        {/* Evento*/}
        <Route path="/listarEvento" element={<Listar />} />
        <Route path="/detalhesEvento" element={<Detalhes />} />

        {/* Perfil*/}
        <Route path="/verPerfil" element={<VerPerfil />} />
        <Route path="/alterarSenha" element={<AlterarSenha />} />

      </Routes>
      <Footer />
    </>
  )
}

export default App
