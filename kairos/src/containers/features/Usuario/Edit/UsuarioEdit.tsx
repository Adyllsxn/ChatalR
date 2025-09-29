import { useEffect, useState } from 'react';
import api from '../../../../core/service/api';
import './UsuarioEdit.css';

// Tipagem dos dados do usuário
type Usuario = {
  id: number;
  nome: string;
  sobreNome: string;
  email: string;
  telefone: string;
  bi: string;
};

const UsuarioEdit = () => {
  const [formData, setFormData] = useState<Usuario>({
    id: 0,
    nome: '',
    sobreNome: '',
    email: '',
    telefone: '',
    bi: '',
  });

  // Carrega os dados do usuário logado
  useEffect(() => {
    const id = localStorage.getItem('userId');
    if (!id) {
      alert('Usuário não autenticado');
      return;
    }

    api.get(`/v1/GetByIdUsuario?Id=${id}`)
      .then(res => {
        const user = res.data.data;

        setFormData({
          id: user.id,
          nome: user.nome,
          sobreNome: user.sobreNome,
          email: user.email,
          telefone: user.telefone,
          bi: user.bi,
        });
      })
      .catch(() => {
        alert('Erro ao carregar dados do usuário.');
      });
  }, []);

  // Atualiza estado ao alterar inputs
  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  // Salva as alterações
  const handleSubmit = async () => {
    try {
      console.log('Enviando dados atualizados:', formData);
      await api.put('/v1/UpdateUsuario', formData);
      alert('Dados atualizados com sucesso!');
    } catch (error) {
      console.error('Erro ao atualizar usuário:', error);
      alert('Erro ao atualizar os dados. Tente novamente.');
    }
  };

  return (
    <div className="usuario-edit-container">
      <h2>Editar Perfil</h2>
      <form>
        <input
          type="text"
          name="nome"
          value={formData.nome}
          onChange={handleChange}
          placeholder="Nome"
        />
        <input
          type="text"
          name="sobreNome"
          value={formData.sobreNome}
          onChange={handleChange}
          placeholder="Sobrenome"
        />
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Email"
        />
        <input
          type="text"
          name="telefone"
          value={formData.telefone}
          onChange={handleChange}
          placeholder="Telefone"
        />
        <input
          type="text"
          name="bi"
          value={formData.bi}
          onChange={handleChange}
          placeholder="Bilhete de Identidade"
        />
        <button type="button" onClick={handleSubmit}>
          Salvar Alterações
        </button>
      </form>
    </div>
  );

  return (
    <section className="usuarioEdit-section">
      <div className="layoutContainer">
        <h1>Edita a sua conta</h1>
        <div className="usuarioEditForm">
          <form>
            <input
              type="text"
              name="nome"
              placeholder="Primeiro Nome"
              value={formData.nome}
              onChange={handleChange}
            />
            <input
              type="text"
              name="sobreNome"
              placeholder="Sobre Nome"
              value={formData.sobreNome}
              onChange={handleChange}
            />
            <input
              type="email"
              name="email"
              placeholder="Seu Email"
              value={formData.email}
              onChange={handleChange}
            />
            <input
              type="text"
              name="telefone"
              placeholder="Número de Telefone"
              value={formData.telefone}
              onChange={handleChange}
            />
            <input
              type="text"
              name="bi"
              placeholder="Seu BI"
              value={formData.bi}
              onChange={handleChange}
            />
            <button type="button" onClick={handleSubmit}>
              Salvar
            </button>
          </form>
        </div>
      </div>
    </section>
  );
};

export default UsuarioEdit;
