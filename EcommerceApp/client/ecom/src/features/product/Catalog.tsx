import { useEffect, useState } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("http://localhost:5029/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts(data));

    return () => {};
  }, []);
  
  return (
    <>
      <ProductList products={products} />
    </>
  );
}
