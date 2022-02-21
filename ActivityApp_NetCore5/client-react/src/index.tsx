import React from 'react';
import ReactDOM from 'react-dom';
import './app/layout/sytles.css';
import App from './app/layout/App';
import { StoreContext, store } from './app/stores/store';

ReactDOM.render(
  <StoreContext.Provider value={store}>
    <App />
  </StoreContext.Provider>,
  document.getElementById('root')
);

