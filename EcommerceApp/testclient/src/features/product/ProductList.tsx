import Paper from "@mui/material/Paper";
import {
  Grid,
  Table,
  TableHeaderRow,
  TableSelection,
} from "@devexpress/dx-react-grid-material-ui";
import {
  SelectionState,
  PagingState,
  IntegratedPaging,
  IntegratedSelection,
} from "@devexpress/dx-react-grid";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import {
  fetchFilters,
  fetchProductsAsync,
  productSelectors,
  setPageNumber,
} from "./productSlice";
import { useEffect, useState } from "react";
import AppPagination from "../../app/components/AppPagination";
import TableColorRowComponent from "../../app/components/TableColorRow";
import { SortingState, IntegratedSorting } from "@devexpress/dx-react-grid";

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
  const [sorting, setSorting] = useState<any>([
    { columnName: "name", direction: "asc" },
  ]);
  const [selection, setSelection] = useState<any>([]);
  const [tableColumnAlignmentExtensions] = useState<any[]>([
    {
      columnName: "id",
      align: "left",
      width: 80,
    },
    { columnName: "name", align: "center", width: "20%" },
    {
      columnName: "description",
      align: "left",
      width: "20%",
      wordWrapEnabled: false,
    },
    { columnName: "pictureUrl", align: "center", width: "20%" },
    { columnName: "brand", align: "center", width: "10%" },
    { columnName: "type", align: "center", width: "10%" },
    { columnName: "price", align: "center", width: "10%" },
    { columnName: "stockQuantity", align: "right", width: 150 },
  ]);

  useEffect(() => {
    if (!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [filtersLoaded, dispatch]);

  return (
    <Paper>
      <Grid rows={products} columns={columns}>
        <SelectionState
          selection={selection}
          onSelectionChange={setSelection}
        />
        <PagingState defaultCurrentPage={1} pageSize={6} />
        <SortingState sorting={sorting} onSortingChange={setSorting} />
        <IntegratedSorting />
        <IntegratedSelection />
        <IntegratedPaging />
        <Table
          tableComponent={TableColorRowComponent}
          columnExtensions={tableColumnAlignmentExtensions}
        />
        <TableHeaderRow showSortingControls />
        <TableSelection showSelectAll />
        {/* <PagingPanel /> */}
        {metaData && (
          <AppPagination
            metaData={metaData}
            onPageChange={(page: number) =>
              dispatch(setPageNumber({ pageNumber: page }))
            }
          />
        )}
      </Grid>
      <span>Total rows selected: {selection.length}</span>
    </Paper>
  );
}
