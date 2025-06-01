import Header from './components/Header'
import Footer from './components/Footer'
import Home from './pages/Home'
import Login from './pages/public/Login'

import { Routes, Route, Navigate } from 'react-router-dom';
import React, { useState } from 'react'

import './styles/App.css'

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)

  function handleLogin() {
    setIsLoggedIn(true)
  }

  function handleLogout() {
    setIsLoggedIn(false)
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
      </Routes>
      <Footer />
    </>
  )
}

export default App
