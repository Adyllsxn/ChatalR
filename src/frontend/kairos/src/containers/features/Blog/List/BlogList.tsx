import './BlogList.css';
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

const BlogList = () => {
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
          const ordered = [...response.data.data].reverse(); // mais recente primeiro
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

  const principalPost = posts[0];
  const sidePosts = posts.slice(1, 4); // até 3 posts laterais

  return (
    <section className='blogSection'>
      <div className="layoutContainer blogContainer">
        <motion.h1 
          className="blogTitle"
          initial={{ opacity: 0, y: -30 }}
          animate={{ opacity: 1, y: 0 }}
          transition={{ duration: 0.6 }}
        >
          Blog Kairos
        </motion.h1>

        {loading ? (
          <p>Carregando posts...</p>
        ) : posts.length === 0 ? (
          <p>Nenhum post publicado até o momento.</p>
        ) : (
          <>
            <div className="blogGrid">
              {/* Post em destaque */}
              {principalPost && (
                <motion.div
                  className="blogMainPost"
                  initial={{ opacity: 0, y: 40 }}
                  whileInView={{ opacity: 1, y: 0 }}
                  viewport={{ once: true }}
                  transition={{ duration: 0.8 }}
                >
                  <div className="blogMainImageWrapper">
                    <img
                      src={`http://localhost:5232/${principalPost.imagemCapaUrl}`}
                      alt={principalPost.titulo}
                      className="blogMainImage"
                    />
                  </div>
                  <div className="blogPostContent">
                    <span className="blogDate">
                      <FaRegCalendarAlt /> {formatDate(principalPost.dataPublicacao)}
                    </span>
                    <h2 className="blogPostTitle">
                      {principalPost.titulo}
                    </h2>
                  </div>
                </motion.div>
              )}

              {/* Posts laterais */}
              <div className="blogSidePosts">
                {sidePosts.map((post, index) => (
                  <motion.div
                    className="blogSidePost"
                    key={post.id}
                    initial={{ opacity: 0, x: 40 }}
                    whileInView={{ opacity: 1, x: 0 }}
                    viewport={{ once: true }}
                    transition={{ duration: 0.6, delay: index * 0.15 }}
                  >
                    <img src={`http://localhost:5232/${post.imagemCapaUrl}`} alt={post.titulo} />
                    <div>
                      <span className="blogDate">
                        <FaRegCalendarAlt /> {formatDate(post.dataPublicacao)}
                      </span>
                      <p>{post.titulo}</p>
                    </div>
                  </motion.div>
                ))}
              </div>
            </div>

            {/* Botão "Ver todos os posts" */}
            <motion.div
              className="blogButtonWrapper"
              initial={{ opacity: 0, scale: 0.8 }}
              whileInView={{ opacity: 1, scale: 1 }}
              viewport={{ once: true }}
              transition={{ duration: 0.5 }}
            >
              <button className="blogSeeMoreButton">
                <Link to='/blogView'>Ver todos os posts</Link>
              </button>
            </motion.div>
          </>
        )}
      </div>
    </section>
  );
};

export default BlogList;
