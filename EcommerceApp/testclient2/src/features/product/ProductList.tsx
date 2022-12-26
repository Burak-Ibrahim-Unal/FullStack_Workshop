import { useEffect } from "react";
import Paper from "@mui/material/Paper";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import {
  fetchFilters,
  fetchProductsAsync,
  productSelectors,
} from "./productSlice";
import FiListControl from "../../app/components/FiListControl";
import {Product} from "../../app/models/product"

//ilgili rowun idsimni tutan kod
const getRowId = (row: any) => row.id;

//const columnItems = product

export default function ProductList() {
  const products = useAppSelector(productSelectors.selectAll);
  const { productsLoaded, filtersLoaded } = useAppSelector(
    (state) => state.product
  );
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!productsLoaded) {
      dispatch(fetchProductsAsync());
    }
  }, [productsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [filtersLoaded, dispatch]);

  return (
    <Paper>
      <FiListControl rowItems={products} />
    </Paper>
  );
}
