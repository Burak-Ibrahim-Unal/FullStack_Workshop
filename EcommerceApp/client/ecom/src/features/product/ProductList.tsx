import { Grid } from "@mui/material";
import { Product } from "../../app/models/product";
import ProductCard from "./ProductCard";

interface Props {
  products: Product[];
}
export default function ProductList({ products }: Props) {
  return (
    <Grid container spacing={4}>
      {products.map((product, index) => (
        <Grid item xs={4} key={product.id} sx={{ mt: -3, mb: 2 }}>
          <ProductCard product={product} />
        </Grid>
      ))}
    </Grid>
  );
}
