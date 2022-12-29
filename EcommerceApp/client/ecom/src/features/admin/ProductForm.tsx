import { Typography, Grid, Paper, Box, Button } from "@mui/material";
import { useEffect } from "react";
import { useForm } from "react-hook-form";
import { AppSelectList } from "../../app/components/AppSelectList";
import AppTextInput from "../../app/components/AppTextInput";
import useProducts from "../../app/hooks/useProducts";
import { Product } from "../../app/models/product";

interface Props {
  product?: Product;
  cancelEdit: () => void;
}

export default function ProductForm({ product, cancelEdit }: Props) {
  const { control, reset } = useForm();
  const { brands, types } = useProducts();

  useEffect(() => {
    if (product) reset(product);
  }, [product, reset]);

  return (
    <Box component={Paper} sx={{ p: 4 }}>
      <Typography variant="h4" gutterBottom sx={{ mb: 4 }}>
        Product Details
      </Typography>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={12}>
          <AppTextInput control={control} name="name" label="Product name" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppSelectList control={control} items={brands} name="brand" label="Brand" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppSelectList control={control} items={types} name="type" label="Type" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput control={control} name="price" label="Price" />
        </Grid>
        <Grid item xs={12} sm={6}>
          <AppTextInput
            control={control}
            name="quantityInStock"
            label="Quantity in Stock"
          />
        </Grid>
        <Grid item xs={12}>
          <AppTextInput
            control={control}
            name="description"
            label="Description"
          />
        </Grid>
        <Grid item xs={12}>
          <AppTextInput control={control} name="pictureUrl" label="Image" />
        </Grid>
      </Grid>
      <Box display="flex" justifyContent="space-between" sx={{ mt: 3 }}>
        <Button onClick={cancelEdit} variant="contained" color="inherit">
          Cancel
        </Button>
        <Button variant="contained" color="success">
          Submit
        </Button>
      </Box>
    </Box>
  );
}
