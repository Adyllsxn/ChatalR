import { FaMagnifyingGlass, FaPlus } from "react-icons/fa6";
import { Link } from "react-router-dom";
import './Blog.css';

const Blog = () => {
  return (
    <section className="blogMain">
      <div className="blogHeader">
        <Link to="#" className="blogBtnAdd">
          <FaPlus />
          Criar Post
        </Link>
        <div className="blogBuscar">
          <input type="text" placeholder="Buscar Post..." />
          <button className="blogBtnSearch">
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>
    </section>
  )
}

export default Blog