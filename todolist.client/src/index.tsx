import React from 'react';
import ReactDOM from 'react-dom/client';
import './Styles/style.css';
import "./Assets/css/bootstrap.min.css";
import App from './App';
import { BrowserRouter } from 'react-router-dom';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>
);
