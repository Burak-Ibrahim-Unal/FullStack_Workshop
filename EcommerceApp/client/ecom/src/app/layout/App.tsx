import { useEffect, useState } from "react";
import { Product } from "../models/product";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      { name: "product" + (prevState.length + 1), 
      price: prevState.length * 2,
      description:"description"+ (prevState.length+1),
      pictureUrl:"testurl"+ (prevState.length+1),
      type:"type"+ (prevState.length+1),
      brand:"brand" + (prevState.length+1),
      stockQuantity:(prevState.length + 3)
    },
    ]);
  }
  useEffect(() => {
    fetch("http://localhost:5029/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts(data))

    return () => {};
  }, []);

  return (
    <div>
      <h1>Ecom</h1>
      <ul>
        {products.map((item, index) => (
          <li key={index}>
            {" "}
            {item.name} ---  {item.description} ---{item.price}TL ---  {item.stockQuantity} Adet
          </li>
        ))}
      </ul>
      <button onClick={addProduct}>Kaydet</button>
    </div>
  );
}

export default App;
