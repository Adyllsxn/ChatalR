import React from 'react';
import './ChurChmap.css';

export default function ChurchMap() {
    return (
        <section className="church-map-section">
        <div className="layout-container">
            <h2>Como Chegar</h2>
            <p>Rua nº 03, Bairro Sossego, Kilamba – Luanda, Angola</p>
            <div className="map-container">
            <iframe
                title="Mapa da Igreja"
                src="https://www.google.com/maps?q=-8.9970638,13.2721197&z=15&output=embed"
                allowFullScreen
                loading="lazy"
            ></iframe>
            </div>
        </div>
        </section>
    );
}
