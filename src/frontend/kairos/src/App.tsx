import { useState } from "react";
import type { ReactElement } from "react";
import { Routes, Route, Navigate, useLocation } from "react-router-dom";

import Header from "./components/layouts/Header/Header";
import Footer from "./components/layouts/Footer/Footer";

import Home from "./containers/pages/Home/Main/Home";
import Ajuda from "./containers/pages/Institucional/Ajuda/Ajuda";
import FAQ from "./containers/pages/Institucional/FAQ/FAQ";
import SobreNos from "./containers/pages/Institucional/SobreNos/SobreNos";
import PoliticaDePrivacidade from "./containers/pages/Politica/PoliticaDePrivacidade";

import AdminLayout from "./containers/pages/Administrativa/AdminLayout";
import Dashboard from "./containers/pages/Dashboard/Dashboard";

import Eventos from "./containers/features/Evento/Main/Eventos";
import EventoList from "./containers/features/Evento/List/EventoList";
import EventoDetails from "./containers/features/Evento/Details/EventoDetails";
import EventoCreate from "./containers/features/Evento/Create/EventoCreate";

import Usuarios from "./containers/features/Usuario/Main/Usuarios";
import UsuarioView from "./containers/features/Usuario/View/UsuarioView";
import UsuarioEdit from "./containers/features/Usuario/Edit/UsuarioEdit";

import Blog from "./containers/features/Blog/Main/Blog";
import BlogList from "./containers/features/Blog/List/BlogList";
import BlogView from "./containers/features/Blog/Views/BlogView";
import BlogDetails from "./containers/features/Blog/Details/BlogDetails";

import Presencas from "./containers/features/Presenca/Main/Presencas";
import PresencaList from "./containers/features/Presenca/List/PresencaList";

import Tipos from "./containers/features/Tipo/Main/Tipos";
import Login from "./containers/features/Auth/Login/Login";

import "./core/style/App.css";
import "./core/style/index.css";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(() => !!localStorage.getItem("token"));
  const location = useLocation();
  const isLoginPage = location.pathname === "/login";

  const handleLogin = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    localStorage.clear();
    setIsLoggedIn(false);
  };

  const isProtectedRoute = (element: ReactElement): ReactElement =>
    isLoggedIn ? element : <Navigate to="/login" state={{ from: location }} replace />;

  return (
    <>
      {!isLoginPage && <Header onLogout={handleLogout} />}

      <Routes>
        {/* Rotas Públicas */}
        <Route path="/" element={<Home />} />
        <Route path="/ajuda" element={<Ajuda />} />
        <Route path="/faq" element={<FAQ />} />
        <Route path="/sobreNos" element={<SobreNos />} />
        <Route path="/politicaDePrivacidade" element={<PoliticaDePrivacidade />} />
        <Route path="/eventoList" element={<EventoList />} />
        <Route path="/eventoDetails" element={<EventoDetails />} />
        <Route path="/blogList" element={<BlogList />} />
        <Route path="/blogDetails/:id" element={<BlogDetails />} />
        <Route path="/blogView" element={<BlogView />} />

        {/* Login */}
        {!isLoggedIn && <Route path="/login" element={<Login onLogin={handleLogin} />} />}
        {isLoggedIn && <Route path="/login" element={<Navigate to="/" replace />} />}

        {/* Rotas Protegidas */}
        <Route path="/usuarioView" element={isProtectedRoute(<UsuarioView />)} />
        <Route path="/usuarioEdit" element={isProtectedRoute(<UsuarioEdit />)} />
        <Route path="/minhasPresencas" element={isProtectedRoute(<PresencaList />)} />

        <Route path="/administrativa" element={isProtectedRoute(<AdminLayout />)}>
          <Route index element={<Navigate to="dashboard" replace />} />
          <Route path="dashboard" element={<Dashboard />} />
          <Route path="eventos" element={<Eventos />} />
          <Route path="eventoAdd" element={<EventoCreate />} />
          <Route path="tipos" element={<Tipos />} />
          <Route path="usuarios" element={<Usuarios />} />
          <Route path="presencas" element={<Presencas />} />
          <Route path="blog" element={<Blog />} />
        </Route>

        {/* Fallback */}
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>

      {!isLoginPage && <Footer />}
    </>
  );
}

export default App;
