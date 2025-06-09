import React, { useEffect, useState } from 'react';
import './Alert.css';

const Alert = ({ message, type = 'info', onClose }) => {
    const [visible, setVisible] = useState(true);

    useEffect(() => {
        const timer = setTimeout(() => {
            setVisible(false);
            if (onClose) onClose();
        }, 3000);

        return () => clearTimeout(timer);
    }, [onClose]);

    if (!visible || !message) return null;

    return (
        <div className={`custom-alert ${type}`}>
            <span>{message}</span>
        </div>
    );
};

export default Alert;
