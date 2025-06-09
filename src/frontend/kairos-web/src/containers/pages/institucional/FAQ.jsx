import React from 'react';
import './FAQ.css';

export default function FAQ() {
  const perguntasERespostas = [
    {
      pergunta: "O que é o sistema Kairos?",
      resposta: "O Kairos é um sistema desenvolvido para gerenciar cultos e eventos da Igreja Sossego em Cristo, facilitando o trabalho de organização e comunicação com os membros."
    },
    {
      pergunta: "Quem pode utilizar o sistema?",
      resposta: "Líderes, organizadores, equipe de comunicação, administração da igreja e membros cadastrados têm acesso ao sistema de acordo com seu nível de permissão."
    },
    {
      pergunta: "Como posso me cadastrar no sistema?",
      resposta: "O cadastro é feito pela equipe de administração da igreja. Caso ainda não tenha acesso, entre em contato com a secretaria."
    },
    {
      pergunta: "Preciso pagar para usar o Kairos?",
      resposta: "Não. O uso do Kairos é gratuito para membros e equipes autorizadas da Igreja Sossego em Cristo."
    },
    {
      pergunta: "O que fazer se eu esquecer minha senha?",
      resposta: "Utilize a opção de recuperação de senha na tela de login ou entre em contato com o suporte da igreja."
    },
  ];

  return (
    <main>
      <section className='faq-section'>
        <div className='layout-container'>
          <h1>FAQ</h1>
          <div className='faq-list'>
            {perguntasERespostas.map((item, index) => (
              <div key={index} className='faq-item'>
                <h3>{item.pergunta}</h3>
                <p>{item.resposta}</p>
              </div>
            ))}
          </div>
        </div>
      </section>
    </main>
  );
}
