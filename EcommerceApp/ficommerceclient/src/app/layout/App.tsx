import React from 'react';
import ProductList from '../../features/product/ProductList';
import './styles.css';

function App() {
  return (
    <div className="App">
      <h1>App.tsx</h1>
      <ProductList products={[]} />
    </div>
  );
}

export default App;
