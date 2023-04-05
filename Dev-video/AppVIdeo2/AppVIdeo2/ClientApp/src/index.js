import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { createRoot } from 'react-dom/client';
import { App } from './Componentes/App';
import './Styles/StyleAgregar.css'

const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

root.render(
    <React.StrictMode>
        <App />
    </React.StrictMode>,
)