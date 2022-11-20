import { CssBaseline } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import Catalog from "../../features/product/Catalog";
import { Product } from "../models/product";
import Header from "./Header";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      {
        id: prevState.length + 1,
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
    <>
      <CssBaseline />
      <Header />
      <Container>
        <Catalog products={products} addProduct={addProduct} />
      </Container>
    </>
  );
}

export default App;
