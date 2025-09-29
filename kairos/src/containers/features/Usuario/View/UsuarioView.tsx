import { useEffect, useMemo, useState } from 'react';
import apiservice from '../../../../core/service/api';
import './UsuarioView.css';

//#region CODE
type MeuPerfilType = {
  nome: string;
  sobreNome: string;
  email: string;
  fotoUrl: string;
  telefone: string;
  bi: string;
  dataCadastro: string;
  perfil?: {
    nome: string;
  };
};

export default function VerPerfil() {
  const [meuPerfil, setMeuPerfil] = useState<MeuPerfilType | null>(null);

  // useMemo garante que authorization não seja recriado a cada render
  const authorization = useMemo(() => {
    const token = localStorage.getItem('token');
    return {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
  }, []);

  useEffect(() => {
    apiservice
      .get('/v1/GetCurrentUsuario', authorization)
      .then((response) => {
        setMeuPerfil(response.data.data);
      })
      .catch((error) => {
        console.error('Erro ao buscar usuário:', error);
        alert('Erro ao carregar perfil. Tente novamente mais tarde.');
      });
  }, [authorization]); // agora authorization está como dependência
  //#endregion


  return (
    <main>
      <section className="verperfil-section">
        <div className="layoutContainer">
          <h1>Meu Perfil</h1>

          {meuPerfil ? (
            <div className="perfil-dados">
              <div className="perfil-conteudo">
                {/* Foto */}
                <div className="perfil-foto">
                  <img src={`http://localhost:5232/${meuPerfil.fotoUrl}`}
                    alt={meuPerfil.fotoUrl}/>
                </div>

                {/* Informações */}
                <div className="perfil-info">
                  <p>
                    <strong>Nome:</strong> {meuPerfil.nome} {meuPerfil.sobreNome}
                  </p>
                  <p>
                    <strong>Email:</strong> {meuPerfil.email}
                  </p>
                  <p>
                    <strong>Telefone:</strong> {meuPerfil.telefone}
                  </p>
                  <p>
                    <strong>BI:</strong> {meuPerfil.bi}
                  </p>
                  <p>
                    <strong>Perfil:</strong> {meuPerfil.perfil?.nome}
                  </p>
                  <p>
                    <strong>Data de Cadastro:</strong>{' '}
                    {new Date(meuPerfil.dataCadastro).toLocaleString()}
                  </p>
                </div>
              </div>
            </div>
          ) : (
            <p>Carregando perfil...</p>
          )}
        </div>
      </section>
    </main>
  );
}
