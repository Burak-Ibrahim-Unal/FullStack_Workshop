import { useEffect, useState } from "react";
import Catalog from "../../features/product/Catalog";
import { Product } from "../models/product";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      {
        id:(prevState.length + 1),
        name: "product" + (prevState.length + 1),
        price: prevState.length * 2,
        description: "description" + (prevState.length + 1),
        pictureUrl: "testurl" + (prevState.length + 1),
        type: "type" + (prevState.length + 1),
        brand: "brand" + (prevState.length + 1),
        stockQuantity: prevState.length + 3,
      },
    ]);
  }
  useEffect(() => {
    fetch("http://localhost:5029/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts(data));

    return () => {};
  }, []);

  return (
    <div>
      <Catalog products={products} addProduct={addProduct} />
    </div>
  );
}

export default App;
