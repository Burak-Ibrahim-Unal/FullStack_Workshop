import Paper from "@mui/material/Paper";
import {
  Grid,
  Table,
  TableHeaderRow,
} from "@devexpress/dx-react-grid-material-ui";
import { alpha, styled } from "@mui/material/styles";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import {
  fetchFilters,
  fetchProductsAsync,
  productSelectors,
  setPageNumber,
} from "./productSlice";
import { useEffect } from "react";
import AppPagination from "../../app/components/AppPagination";
import TableColorRowComponent from "../../app/components/TableColorRow";

const columns = [
  { name: "id", title: "ID" },
  { name: "name", title: "Product Name" },
  { name: "description", title: "Description" },
  { name: "price", title: "Price" },
  { name: "pictureUrl", title: "PictureUrl" },
  { name: "type", title: "Type" },
  { name: "brand", title: "Brand" },
  { name: "stockQuantity", title: "Stock Quantity" },
];

export default function ProductList() {
  const products = useAppSelector(productSelectors.selectAll);
  const { productsLoaded, filtersLoaded, metaData } = useAppSelector(
    (state) => state.product
  );
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [filtersLoaded, dispatch]);

  return (
    <Paper>
      <Grid rows={products} columns={columns}>
        <Table tableComponent={TableColorRowComponent} />
        <TableHeaderRow />
        {metaData && (
          <AppPagination
            metaData={metaData}
            onPageChange={(page: number) =>
              dispatch(setPageNumber({ pageNumber: page }))
            }
          />
        )}
      </Grid>
    </Paper>
  );
}
