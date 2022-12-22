import { useCallback, useEffect, useRef, useState } from "react";
import Paper from "@mui/material/Paper";
import { GridExporter } from "@devexpress/dx-react-grid-export";
import {
  Grid,
  PagingPanel,
  Table,
  TableKeyboardNavigation,
  TableHeaderRow,
  TableFixedColumns,
  Toolbar,
  ExportPanel,
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
import AppPagination from "../../app/components/AppPagination";
import TableColorRowComponent from "../../app/components/TableColorRow";
import { SortingState, IntegratedSorting } from "@devexpress/dx-react-grid";
import Tooltip from "@mui/material/Tooltip";
import Input from "@mui/material/Input";
import { styled } from "@mui/material/styles";
import * as PropTypes from "prop-types";
import saveAs from "file-saver";

//ilgili rowun idsimni tutan kod
const getRowId = (row: any) => row.id;

//Tablo sütunları Start
const columns = [
  //{ name: "id", title: "ID" },
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

//Custom Filtering Start
const PREFIX = "Fiplatform";
const classes = {
  root: `${PREFIX}-root`,
  numericInput: `${PREFIX}-numericInput`,
};
const StyledInput = styled(Input)(({ theme }: { theme: any }) => ({
  [`&.${classes.root}`]: {
    margin: theme.spacing(1),
  },
  [`& .${classes.numericInput}`]: {
    fontSize: "14px",
    textAlign: "right",
    width: "100%",
  },
}));

const CurrencyEditor = ({
  value,
  onValueChange,
}: {
  value: any;
  onValueChange: any;
}) => {
  const handleChange = (event: any) => {
    const { value: targetValue } = event.target;
    if (targetValue.trim() === "") {
      onValueChange();
      return;
    }
    onValueChange(parseInt(targetValue, 10));
  };
  return (
    <StyledInput
      type="number"
      classes={{
        input: classes.numericInput,
        root: classes.root,
      }}
      fullWidth
      value={value === undefined ? "" : value}
      inputProps={{
        min: 2000,
        placeholder: "Filter",
      }}
      onChange={handleChange}
    />
  );
};

CurrencyEditor.propTypes = {
  value: PropTypes.number,
  onValueChange: PropTypes.func.isRequired,
};

CurrencyEditor.defaultProps = {
  value: undefined,
};
//Custom Filtering End

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

//Excel export start
const onSave = (workbook: any) => {
  workbook.xlsx.writeBuffer().then((buffer: any) => {
    saveAs(
      new Blob([buffer], { type: "application/octet-stream" }),
      "DataGrid.xlsx"
    );
  });
};
//Excel export end

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

  // Sabit ve hareketli kolonlar için bölünmüş kolonlar
  const [leftColumns] = useState(['name', 'channel']);
  const [rightColumns] = useState<any[]>([
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
  { columnName: "stockQuantity", align: "right", width: 150 },]);

  //Hücreler arasında klavye yön tuşlarıyla gezmek için gereken kod
  const [focusedCell, setFocusedCell] = useState<any>(undefined);


  //Excel Ayarları Start
  const exporterRef = useRef<any>(null);
  const startExport = useCallback((options) => {
    exporterRef.current.exportGrid(options);
  }, [exporterRef]);
  //Excel Ayarları End

  // Price alanına $ koymak ve renki kalın mavi yapmak için gereken kod
  const [currencyColumns] = useState(["price"]);

  // Price alanına custom filter ekledik
  const [currencyFilterOperations] = useState([
    "equal",
    "notEqual",
    "greaterThan",
    "greaterThanOrEqual",
    "lessThan",
    "lessThanOrEqual",
  ]);

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
      <Grid rows={products} columns={columns} getRowId={getRowId}>
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
        <DataTypeProvider
          for={currencyColumns}
          editorComponent={CurrencyEditor}
          availableFilterOperations={currencyFilterOperations}
        />
        <FilteringState defaultFilters={[]} />
        <IntegratedFiltering />
        <Table
          tableComponent={TableColorRowComponent}
          columnExtensions={tableColumnAlignmentExtensions}
        />
        <TableFilterRow showFilterSelector />
        <TableHeaderRow showSortingControls />
        <TableKeyboardNavigation
          focusedCell={focusedCell}
          onFocusedCellChange={setFocusedCell}
        />
        <PagingPanel pageSizes={pageSizes} />
        <TableSelection showSelectAll />
        {/* {metaData && (
          <AppPagination
            metaData={metaData}
            onPageChange={(page: number) =>
              dispatch(setPageNumber({ pageNumber: page }))
            }
          />
        )} */}
        <Toolbar />
        <ExportPanel startExport={startExport} />
        <TableFixedColumns
          leftColumns={leftColumns}
          rightColumns={rightColumns}
        />
      </Grid>
      <span>Total rows selected: {selection.length}</span>
      <GridExporter
        ref={exporterRef}
        rows={products}
        columns={columns}
        selection={selection}
        onSave={onSave}
      />
    </Paper>
  );
}
