import React from 'react';
import ReactDOM from 'react-dom';
import './app/layout/sytles.css';
import App from './app/layout/App';
import { StoreContext, store } from './app/stores/store';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.render(
  <StoreContext.Provider value={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </StoreContext.Provider>,
  document.getElementById('root')
);

