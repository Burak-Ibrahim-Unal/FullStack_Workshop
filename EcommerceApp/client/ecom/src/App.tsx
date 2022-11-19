import { useEffect, useState } from "react";

const productList = [
  { name: "product1", price: 3 },
  { name: "product2", price: 5 },
];

function App() {
  const [products, setProducts] = useState(productList);

  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      { name: "product" + (prevState.length + 1), price: prevState.length * 2 },
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
            {item.name} --- {item.price}TL
          </li>
        ))}
      </ul>
      <button onClick={addProduct}>Kaydet</button>
    </div>
  );
}

export default App;
