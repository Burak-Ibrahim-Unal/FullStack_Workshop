const products = [
  { name: "product1", price: 3 },
  { name: "product2", price: 5 },
];

function App() {
  return (
    <div>
      <h1>Ecom</h1>
      <ul>
        {products.map((item) => (
          <li key={item.name}>
            {" "}
            {item.name} --- {item.price}TL
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
