//#region Imports
    import './UsuarioEdit.css';
//#endregion

const UsuarioEdit = () => {
  return (
    <section className='usuarioEdit-section'>
      <div className="layoutContainer">
        <h1>Edita a sua conta</h1>
        <div className='usuarioEditForm'>
          <form>
            <input type="text" placeholder='Primeiro Nome'/>
            <input type="text" placeholder='Sobre Nome'/>
            <input type="email" placeholder='Seu Email'/>
            <input type="number" placeholder='Número de Telefone'/>
            <input type="text" placeholder='Seu BI' />
            <button type='button'>Salvar</button>
          </form>
        </div>
      </div>
    </section>
  );
};

export default UsuarioEdit;
