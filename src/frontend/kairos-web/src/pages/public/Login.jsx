import React from 'react'
import {FaUser, FaLock} from 'react-icons/fa'
import { useState } from 'react'
import '../../styles/public/Login.css'

export default function Login({ onLogin }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const handlerSubmit = (event) =>{
        event.preventDefault();
        alert(`Bem-vindo ao Kairos: ${email} ${password}`);
    }

    return (
        <main className='login-wrap'>
            <div className='login-conteiner'>
                <form onSubmit={handlerSubmit}>
                    <h1>Acesse o sistema</h1>

                    <div className='input-field'>
                        <input  type="email" 
                                placeholder='Exemplo@gmail.com'
                                required
                                onChange={(e) => setEmail(e.target.value)} />
                        <FaUser className='icon'/> 
                    </div>

                    <div className='input-field'>
                        <input  type="password" 
                                placeholder='Senha'
                                required
                                onChange={(e) => setPassword(e.target.value)}/>
                        <FaLock className='icon'/> 
                    </div>

                    <button onClick={onLogin}>Entrar</button>
                </form>
            </div>
        </main>
    )
}