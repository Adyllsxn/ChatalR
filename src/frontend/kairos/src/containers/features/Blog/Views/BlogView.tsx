import './BlogView.css';
import { FaRegCalendarAlt } from 'react-icons/fa';
import { Link } from 'react-router-dom';
import { motion } from 'framer-motion';
import { useEffect, useState } from 'react';
import axios from 'axios';

interface Usuario {
  nome: string;
  sobreNome: string;
}

interface BlogPost {
  id: number;
  titulo: string;
  conteudo: string;
  imagemCapaUrl: string;
  dataPublicacao: string;
  usuario: Usuario;
}

const BlogView = () => {
  const [posts, setPosts] = useState<BlogPost[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const response = await axios.get('http://localhost:5232/v1/GetPublishBlog', {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('token')}`
          }
        });

        if (response.data?.data) {
          const ordered = [...response.data.data].reverse();
          setPosts(ordered);
        }
      } catch (error) {
        console.error('Erro ao carregar os posts:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchPosts();
  }, []);

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

  return (
    <section className="blogViewSection">
      <div className="layoutContainer">
        <motion.h1
          className="blogViewListTitle"
          initial={{ opacity: 0, y: -20 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.5 }}
        >
          Todos os Posts
        </motion.h1>

        {loading ? (
          <p>Carregando posts...</p>
        ) : posts.length === 0 ? (
          <motion.div
            className="semPosts"
            initial={{ opacity: 0, y: 20 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.5 }}
          >
            <p style={{ textAlign: 'center', fontSize: '1.1rem', color: '#555' }}>
              Nenhum post publicado ainda. Volte em breve para mais novidades do Kairos! 🙌
            </p>
          </motion.div>
        ) : (
          <div className="blogListGrid">
            {posts.map((post, index) => (
              <motion.div
                className="blogCard"
                key={post.id}
                initial={{ opacity: 0, y: 40 }}
                whileInView={{ opacity: 1, y: 0 }}
                viewport={{ once: true }}
                transition={{ duration: 0.5, delay: index * 0.1 }}
              >
                <div className="blogCardImageWrapper">
                  <img
                    src={`http://localhost:5232/${post.imagemCapaUrl}`}
                    alt={post.titulo}
                    className="blogCardImage"
                  />
                </div>
                <div className="blogCardContent">
                  <span className="blogDate">
                    <FaRegCalendarAlt /> {formatDate(post.dataPublicacao)}
                  </span>
                  <h2 className="blogCardTitle">{post.titulo}</h2>
                  <Link to="#" className="blogReadMore">Ler mais</Link>
                </div>
              </motion.div>
            ))}
          </div>
        )}
      </div>
    </section>
  );
};

export default BlogView;
