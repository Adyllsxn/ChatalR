import React, { useEffect, useState } from 'react';
import { FaUserCircle } from 'react-icons/fa';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import './VerPerfil.css';

export default function VerPerfil() {
    const [meuPerfil, setMeuPerfil] = useState(null);
    const [alert, setAlert] = useState({ message: '', type: '' });

    const token = localStorage.getItem("token");
    const authorization = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    useEffect(() => {
        apiservice.get('/v1/UsuarioGetNotId', authorization)
            .then(response => {
                setMeuPerfil(response.data.data);
            })
            .catch(error => {
                console.error("Erro ao buscar usuário:", error);
                setAlert({ message: "Erro ao carregar perfil. Tente novamente mais tarde.", type: "error" });
            });
    }, []);

    return (
        <main>
            {alert.message && (
                <Alert
                    message={alert.message}
                    type={alert.type}
                    onClose={() => setAlert({ message: '', type: '' })}
                />
            )}

            <section className='verperfil-section'>
                <div className='layout-container'>
                    <h1>Meu Perfil</h1>

                    {meuPerfil ? (
                        <div className='perfil-dados'>
                            <div className='perfil-conteudo'>
                                {/* Lado esquerdo: Foto */}
                                <div className='perfil-foto'>
                                    <FaUserCircle size={140} color="#bbb" />
                                    <p className="foto-legenda">Foto do usuário</p>
                                </div>

                                {/* Lado direito: Informações */}
                                <div className='perfil-info'>
                                    <p><strong>Nome:</strong> {meuPerfil.nome} {meuPerfil.sobreNome}</p>
                                    <p><strong>Email:</strong> {meuPerfil.email}</p>
                                    <p><strong>Telefone:</strong> {meuPerfil.telefone}</p>
                                    <p><strong>BI:</strong> {meuPerfil.bi}</p>
                                    <p><strong>Perfil:</strong> {meuPerfil.perfil?.nome}</p>
                                    <p><strong>Data de Cadastro:</strong> {new Date(meuPerfil.dataCadastro).toLocaleString()}</p>
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
