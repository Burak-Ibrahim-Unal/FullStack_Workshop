import Paper from "@mui/material/Paper";
import {
  Grid,
  PagingPanel,
  Table,
  TableHeaderRow,
  TableSelection,
  TableFilterRow,
} from "@devexpress/dx-react-grid-material-ui";
import {
  SelectionState,
  PagingState,
  IntegratedPaging,
  IntegratedSelection,
  DataTypeProvider,
  FilteringState,
  IntegratedFiltering,
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
import Tooltip from "@mui/material/Tooltip";

//Tablo sütunları Start
const columns = [
  { name: "id", title: "ID" },
  { name: "name", title: "Product Name" },
  { name: "description", title: "Description" },
  { name: "price", title: "Price" },
  { name: "market", title: "Market" },
  { name: "pictureUrl", title: "PictureUrl" },
  { name: "type", title: "Type" },
  { name: "brand", title: "Brand" },
  { name: "stockQuantity", title: "Stock Quantity" },
];
//Tablo sütunları End

// Hücreye ek biçim vermek için yazdığım örnek kod Start
// Not: Price alanına $ koymak ve renki kalın mavi yapmak için gereken kod
const CurrencyFormatterTL = ({ value }: any) => (
  <b style={{ color: "darkblue" }}>
    {value.toLocaleString("tr-TR", { style: "currency", currency: "TL" })}
  </b>
);
const CurrencyFormatterUSD = ({ value }: any) => (
  <b style={{ color: "darkblue" }}>
    {value.toLocaleString("en-US", { style: "currency", currency: "USD" })}
  </b>
);
const CurrencyTypeProvider = (props: any) => (
  <DataTypeProvider formatterComponent={CurrencyFormatterUSD} {...props} />
);
// Hücreye ek biçim vermek için yazdığım örnek kod End

// Tooltip Ayarları Start
const TooltipFormatter = ({
  row: { name, description, price, type, brand, stockQuantity },
  value,
}: {
  row: {
    name: any;
    description: any;
    price: any;
    type: any;
    brand: any;
    stockQuantity: any;
  };
  value: any;
}) => (
  <Tooltip
    title={
      <span>
        {`Name: ${name}`}
        <br />
        <hr />
        {`Description: ${description}`}
        <br />
        <hr />
        {`Price: $${price}`}
        <br />
        <hr />
        {`Type: ${type}`}
        <br />
        <hr />
        {`Brand: ${brand}`}
        <br />
        <hr />
        {`Stock Quantity: ${stockQuantity}`}
      </span>
    }
  >
    <span>{value}</span>
  </Tooltip>
);
const CellTooltip = (props: any) => (
  <DataTypeProvider
    for={columns.map(({ name }) => name)}
    formatterComponent={TooltipFormatter}
    {...props}
  />
);
// Tooltip Ayarları End

export default function ProductList() {
  const products = useAppSelector(productSelectors.selectAll);
  const { productsLoaded, filtersLoaded, metaData } = useAppSelector(
    (state) => state.product
  );
  console.log(metaData);
  const dispatch = useAppDispatch();

  //Sütun ayarları Start
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
  //Sütun ayarları End

  // Price alanına $ koymak ve renki kalın mavi yapmak için gereken kod
  const [currencyColumns] = useState(["price"]);

  // Price alanına göre sort yapmayı engelleyen fonksiyon
  const [sortingStateColumnExtensions] = useState([
    { columnName: "price", sortingEnabled: false },
  ]);

  // Pagination Hook Ayarları Start
  const [pageSize, setPageSize] = useState(10);
  const [pageSizes] = useState([5, 10, 20, 50]);
  const [currentPage, setCurrentPage] = useState(0);
  // Pagination Hook Ayarları End

  // Ürünleri,pagination ayarlarını ve filtreleri Getiren Bölüm Start
  useEffect(() => {
    if (!productsLoaded) {
      dispatch(fetchProductsAsync());
    }
  }, [productsLoaded, dispatch]);

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [filtersLoaded, dispatch]);

  function onPageSizeChange(pageSize: number) {
    setCurrentPage(currentPage);
  }
  // Ürünleri,pagination ayarlarını ve filtreleri Getiren Bölüm End

  return (
    <Paper>
      <Grid rows={products} columns={columns}>
        <SelectionState
          selection={selection}
          onSelectionChange={setSelection}
        />
        <PagingState
          currentPage={currentPage}
          onCurrentPageChange={setCurrentPage}
          pageSize={pageSize}
          onPageSizeChange={setPageSize}
          // defaultCurrentPage={metaData?.currentPage}
          // pageSize={metaData?.pageSize}
          // onPageSizeChange={setPageSize}
        />
        <SortingState
          sorting={sorting}
          onSortingChange={setSorting}
          columnExtensions={sortingStateColumnExtensions}
        />
        <IntegratedSorting />
        <IntegratedSelection />
        <IntegratedPaging />
        <CurrencyTypeProvider for={currencyColumns} />
        <CellTooltip />
        <FilteringState defaultFilters={[]} />
        <IntegratedFiltering />
        <Table
          tableComponent={TableColorRowComponent}
          columnExtensions={tableColumnAlignmentExtensions}
        />
        <TableFilterRow />
        <TableHeaderRow showSortingControls />
        <PagingPanel pageSizes={pageSizes} />
        <TableSelection showSelectAll />
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
