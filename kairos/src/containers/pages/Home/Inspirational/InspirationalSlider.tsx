import { useState, useEffect } from 'react';
import styles from './InspirationalSlider.module.css';

const frases = [
    "“Entrega o teu caminho ao Senhor; confia nele, e ele o fará.” – Salmos 37:5",
    "“Tudo posso naquele que me fortalece.” – Filipenses 4:13",
    "“O Senhor é meu pastor e nada me faltará.” – Salmos 23:1",
    "“Buscai primeiro o Reino de Deus.” – Mateus 6:33",
    "“Alegrai-vos na esperança, sede pacientes na tribulação.” – Romanos 12:12"
];

export default function InspirationalSlider() {
    const [index, setIndex] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
        setIndex((prev) => (prev + 1) % frases.length);
        }, 5000);
        return () => clearInterval(interval);
    }, []);

    return (
        <>
            <section className={styles.sliderSection}>
                <div className="layoutContainer">
                    <div className={styles.sliderBox}>
                        <p className={styles.sliderFrase}>{frases[index]}</p>
                    </div>
                </div>
            </section>
        </>
    );
}
