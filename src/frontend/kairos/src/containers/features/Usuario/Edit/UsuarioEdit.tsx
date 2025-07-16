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
        const user = res.data.data; // <-- acessa o `data` da resposta

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
      console.log('Enviando dados atualizados:', formData); // Debug

      await api.put('/v1/UpdateUsuario', formData);
      alert('Dados atualizados com sucesso!');
    } catch (error) {
      alert('Erro ao atualizar dados.');
    }
  };

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
