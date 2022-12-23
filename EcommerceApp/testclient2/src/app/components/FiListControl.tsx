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
import { useAppDispatch, useAppSelector } from "../store/configureStore";
import AppPagination from "./AppPagination";
import TableColorRowComponent from "./TableColorRow";
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

export default function FiListControl() {
  const products = [
    {
      "name": "Angular Blue Boots",
      "description": "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
      "price": 18000,
      "pictureUrl": "/images/products/boot-ang1.png",
      "type": "Boots",
      "brand": "Angular",
      "stockQuantity": 100,
      "id": 18
    },
    {
      "name": "Angular Purple Boots",
      "description": "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
      "price": 15000,
      "pictureUrl": "/images/products/boot-ang2.png",
      "type": "Boots",
      "brand": "Angular",
      "stockQuantity": 100,
      "id": 17
    },
    {
      "name": "Angular Speedster Board 2000",
      "description": "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 20000,
      "pictureUrl": "/images/products/sb-ang1.png",
      "type": "Boards",
      "brand": "Angular",
      "stockQuantity": 99,
      "id": 1
    },
    {
      "name": "Blue Code Gloves",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1800,
      "pictureUrl": "/images/products/glove-code1.png",
      "type": "Gloves",
      "brand": "VS Code",
      "stockQuantity": 100,
      "id": 10
    },
    {
      "name": "Core Blue Hat",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1000,
      "pictureUrl": "/images/products/hat-core1.png",
      "type": "Hats",
      "brand": "NetCore",
      "stockQuantity": 100,
      "id": 7
    },
    {
      "name": "Core Board Speed Rush 3",
      "description": "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
      "price": 18000,
      "pictureUrl": "/images/products/sb-core1.png",
      "type": "Boards",
      "brand": "NetCore",
      "stockQuantity": 98,
      "id": 3
    },
    {
      "name": "Core Purple Boots",
      "description": "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
      "price": 19999,
      "pictureUrl": "/images/products/boot-core1.png",
      "type": "Boots",
      "brand": "NetCore",
      "stockQuantity": 100,
      "id": 16
    },
    {
      "name": "Core Red Boots",
      "description": "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 18999,
      "pictureUrl": "/images/products/boot-core2.png",
      "type": "Boots",
      "brand": "NetCore",
      "stockQuantity": 100,
      "id": 15
    },
    {
      "name": "Green Angular Board 3000",
      "description": "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
      "price": 15000,
      "pictureUrl": "/images/products/sb-ang2.png",
      "type": "Boards",
      "brand": "Angular",
      "stockQuantity": 98,
      "id": 2
    },
    {
      "name": "Green Code Gloves",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1500,
      "pictureUrl": "/images/products/glove-code2.png",
      "type": "Gloves",
      "brand": "VS Code",
      "stockQuantity": 100,
      "id": 11
    },
    {
      "name": "Green React Gloves",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1400,
      "pictureUrl": "/images/products/glove-react2.png",
      "type": "Gloves",
      "brand": "React",
      "stockQuantity": 100,
      "id": 13
    },
    {
      "name": "Green React Woolen Hat",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 8000,
      "pictureUrl": "/images/products/hat-react1.png",
      "type": "Hats",
      "brand": "React",
      "stockQuantity": 100,
      "id": 8
    },
    {
      "name": "Net Core Super Board",
      "description": "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
      "price": 30000,
      "pictureUrl": "/images/products/sb-core2.png",
      "type": "Boards",
      "brand": "NetCore",
      "stockQuantity": 100,
      "id": 4
    },
    {
      "name": "Purple React Gloves",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1600,
      "pictureUrl": "/images/products/glove-react1.png",
      "type": "Gloves",
      "brand": "React",
      "stockQuantity": 100,
      "id": 12
    },
    {
      "name": "Purple React Woolen Hat",
      "description": "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 1500,
      "pictureUrl": "/images/products/hat-react2.png",
      "type": "Hats",
      "brand": "React",
      "stockQuantity": 100,
      "id": 9
    },
    {
      "name": "React Board Super Whizzy Fast",
      "description": "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 25000,
      "pictureUrl": "/images/products/sb-react1.png",
      "type": "Boards",
      "brand": "React",
      "stockQuantity": 100,
      "id": 5
    },
    {
      "name": "Redis Red Boots",
      "description": "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
      "price": 25000,
      "pictureUrl": "/images/products/boot-redis1.png",
      "type": "Boots",
      "brand": "Redis",
      "stockQuantity": 100,
      "id": 14
    },
    {
      "name": "Typescript Entry Board",
      "description": "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
      "price": 12000,
      "pictureUrl": "/images/products/sb-ts1.png",
      "type": "Boards",
      "brand": "TypeScript",
      "stockQuantity": 100,
      "id": 6
    }
  ];
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

  // Sabit ve hareketli kolonlar için bölünmüş kolonlar Start
  // const [leftColumns] = useState(['name', 'channel']);
  // const [rightColumns] = useState<any[]>([
  // {
  //   columnName: "description",
  //   align: "left",
  //   width: "20%",
  //   wordWrapEnabled: false,
  // },
  // { columnName: "pictureUrl", align: "center", width: "20%" },
  // { columnName: "brand", align: "center", width: "10%" },
  // { columnName: "type", align: "center", width: "10%" },
  // { columnName: "price", align: "center", width: "10%" },
  // { columnName: "stockQuantity", align: "right", width: 150 },]);
    // Sabit ve hareketli kolonlar için bölünmüş kolonlar End

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
        {/* <TableFixedColumns
          leftColumns={leftColumns}
          rightColumns={rightColumns}
        /> */}
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
