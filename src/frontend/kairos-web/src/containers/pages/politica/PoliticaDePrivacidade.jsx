import React from 'react';
import './PoliticaDePrivacidade.css';

export default function PoliticaDePrivacidade() {
  return (
    <main>
      <section className='politica-section'>
        <div className='layout-container'>
          <h1>Política de Privacidade</h1>

          <div className='politica-content'>

            <p>
              A sua privacidade é importante para nós. Esta política descreve como o sistema <strong>Kairos</strong> coleta, utiliza e protege as informações pessoais dos usuários.
            </p>

            <h2>1. Coleta de Informações</h2>
            <p>
              Coletamos informações fornecidas diretamente pelos usuários, como nome, e-mail, telefone, função na igreja e dados relacionados a eventos e cultos.
            </p>

            <h2>2. Uso das Informações</h2>
            <p>
              As informações coletadas são utilizadas para:
              <ul>
                <li>Gerenciar eventos e cultos;</li>
                <li>Enviar notificações e lembretes;</li>
                <li>Melhorar a experiência dos usuários no sistema.</li>
              </ul>
            </p>

            <h2>3. Compartilhamento de Dados</h2>
            <p>
              Não compartilhamos suas informações com terceiros, exceto quando necessário para cumprimento de obrigações legais ou com consentimento do usuário.
            </p>

            <h2>4. Segurança</h2>
            <p>
              Adotamos medidas de segurança para proteger suas informações contra acessos não autorizados, uso indevido ou divulgação indevida.
            </p>

            <h2>5. Direitos dos Usuários</h2>
            <p>
              Você tem o direito de acessar, corrigir ou excluir suas informações pessoais. Para isso, entre em contato pelo e-mail <strong>privacidade@kairos.org</strong>.
            </p>

            <h2>6. Alterações na Política</h2>
            <p>
              Esta política pode ser atualizada periodicamente. Recomendamos que você revise esta página regularmente para estar ciente de qualquer alteração.
            </p>

            <p>Última atualização: 5 de junho de 2025</p>

          </div>
        </div>
      </section>
    </main>
  );
}