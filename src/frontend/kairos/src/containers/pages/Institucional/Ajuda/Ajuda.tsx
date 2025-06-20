import styles from './Ajuda.module.css';

export default function Ajuda() {
  return (
    <>
        <main>
          <section className={styles.ajudaSection}>
            <div className='layoutContainer'>
              <h1>Ajuda</h1>
              <div className={styles.ajudaContent}>

                <section className={styles.ajudaItem}>
                  <h2>1. Não consigo fazer login</h2>
                  <p>
                    Verifique se digitou corretamente seu e-mail e senha. Se o problema persistir, utilize a opção "Esqueci minha senha" ou entre em contato com o suporte da igreja.
                  </p>
                </section>

                <section className={styles.ajudaItem}>
                  <h2>2. Como agendar um culto ou evento?</h2>
                  <p>
                    Apenas organizadores e administradores têm permissão para agendar eventos. Acesse o painel e clique em "Novo Evento" para começar o agendamento.
                  </p>
                </section>

                <section className={styles.ajudaItem}>
                  <h2>3. Não recebo notificações por e-mail</h2>
                  <p>
                    Verifique sua caixa de spam ou lixeira. Adicione o endereço do sistema Kairos à sua lista de remetentes confiáveis.
                  </p>
                </section>

                <section className={styles.ajudaItem}>
                  <h2>4. Preciso de suporte técnico</h2>
                  <p>
                    Entre em contato com nossa equipe pelo e-mail: <strong>suporte@kairos.org</strong> ou fale com a secretaria da igreja.
                  </p>
                </section>

                <section className={styles.ajudaItem}>
                  <h2>5. Sugestões ou melhorias</h2>
                  <p>
                    Queremos melhorar! Envie suas ideias para <strong>melhorias@kairos.org</strong>.
                  </p>
                </section>

              </div>
            </div>
          </section>
        </main>
    </>
  );
}
