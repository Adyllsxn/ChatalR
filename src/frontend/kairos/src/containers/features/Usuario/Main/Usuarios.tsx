import { FaMagnifyingGlass, FaPlus } from "react-icons/fa6"
import { Link } from "react-router-dom"
import './Usuarios.css';

const Usuarios = () => {
  return (
    <section className="usuarioMain">
      <div className="usuarioHeader">
        <Link to="#" className="usuarioBtnAdd">
          <FaPlus />
          Add Usuário
        </Link>
        <div className="usuarioBuscar">
          <input type="text" placeholder="Buscar Usuário..." />
          <button className="usuarioBtnSearch">
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>
    </section>
  )
}

export default Usuarios