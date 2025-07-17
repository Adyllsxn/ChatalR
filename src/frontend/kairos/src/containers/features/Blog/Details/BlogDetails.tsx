// src/components/BlogDetails.tsx
import './BlogDetails.css';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { motion } from 'framer-motion';
import { useEffect, useState } from 'react';
import { useParams, Link } from 'react-router-dom';
import axios from 'axios';

interface Usuario {
  nome: string;
  sobreNome: string;
  email: string;
}

interface BlogPost {
  id: number;
  titulo: string;
  conteudo: string;
  imagemCapaUrl: string;
  dataPublicacao: string;
  usuario: Usuario;
}

const BlogDetails = () => {
  const { id } = useParams();
  const [post, setPost] = useState<BlogPost | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchPost = async () => {
      if (!id || isNaN(Number(id))) return;

      try {
        const response = await axios.get(`http://localhost:5232/v1/GetByIdBlog?Id=${id}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        console.log("Post recebido:", response.data);
        setPost(response.data.data);
      } catch (error) {
        console.error('Erro ao buscar post:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchPost();
  }, [id]);

  const formatDate = (data: string) => {
    const date = new Date(data);
    return isNaN(date.getTime())
      ? 'Data inválida'
      : date.toLocaleDateString('pt-PT', {
          day: '2-digit',
          month: 'long',
          year: 'numeric'
        }).toLowerCase();
  };

  if (loading) return <p className="blogDetailsLoading">Carregando post...</p>;

  if (!post) {
    return (
      <div className="blogDetailsNotFound">
        <p>Post não encontrado. Verifica se o ID é válido e se há token.</p>
        <p>ID recebido: {id}</p>
      </div>
    );
  }

  return (
    <section className="blogDetailsSection">
      <div className="layoutContainer">
        <motion.h1
          className="blogDetailsTitle"
          initial={{ opacity: 0, y: -20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          {post.titulo}
        </motion.h1>

        <div className="blogDetailsImageWrapper">
          <img
            src={`http://localhost:5232/${post.imagemCapaUrl}`}
            alt={post.titulo}
            className="blogDetailsImage"
          />
        </div>

        <div className="blogDetailsInfo">
          <span className="blogDetailsDate">
            <FaRegCalendarAlt /> {formatDate(post.dataPublicacao)}
          </span>
          <p className="blogDetailsAuthor">
            Publicado por {post.usuario.nome} {post.usuario.sobreNome}
          </p>
        </div>

        <p className="blogDetailsContent">{post.conteudo}</p>

        <Link to="/blogView" className="blogDetailsBack">
          ← Voltar aos posts
        </Link>
      </div>
    </section>
  );
};

export default BlogDetails;
