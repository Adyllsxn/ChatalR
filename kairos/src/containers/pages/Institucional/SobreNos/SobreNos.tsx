import styles from './SobreNos.module.css';

export default function SobreNos() {
  return (
      <>
          <main>
            <section className={styles.sobreNosSection}>
              <div className='layoutContainer'>
                <div className={styles.sobreNosContent}>
                  <h1>Sobre Nós</h1>
                  <p>
                    O <strong>Kairos</strong> é uma plataforma desenvolvida com o propósito de auxiliar igrejas na gestão eficiente de cultos, eventos e atividades ministeriais.
                    Buscamos oferecer uma solução prática e segura para líderes, membros e equipes administrativas, promovendo organização e excelência no serviço cristão.
                  </p>

                  <p>
                    Nosso sistema permite o agendamento de eventos, controle de presenças, comunicação interna e centralização de informações importantes.
                    Tudo isso em um ambiente simples, intuitivo e acessível, pensado para fortalecer a missão da igreja e facilitar o envolvimento dos membros.
                  </p>

                  <p>
                    Acreditamos que a tecnologia pode e deve ser usada como ferramenta para o avanço do Reino de Deus.
                    Por isso, desenvolvemos o Kairos com base em princípios cristãos, transparência e compromisso com a segurança dos dados.
                  </p>

                  <p>
                    Seja bem-vindo à nossa plataforma. Que cada funcionalidade aqui sirva para edificar e apoiar sua comunidade de fé.
                  </p>

                  <p>
                    <em>“Tudo deve ser feito com decência e ordem.” – 1 Coríntios 14:40</em>
                  </p>
                </div>
              </div>
            </section>
          </main>
      </>
  );
}
