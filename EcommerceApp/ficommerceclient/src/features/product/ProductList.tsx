import { useAppSelector } from "../../app/store/configureStore";
import { Product } from "../../app/models/product";
import Paper from '@mui/material/Paper';
import { Grid, Table, TableHeaderRow } from '@devexpress/dx-react-grid-material-ui';

interface Props {
  products: Product[];
}

export default function ProductList({ products }: Props) {
  const { productsLoaded } = useAppSelector((state) => state.product);
  // const [columns1] = useState([
  //   { name: "region", title: "Region" },
  //   { name: "description", title: "Description" },
  //   { name: "price", title: "Price" },
  //   { name: "stockQuantity", title: "StockQuantity" },
  //   { name: "type", title: "Type" },
  //   { name: "brand", title: "Brand" },
  //   { name: "pictureUrl", title: "PictureUrl" },
  // ]);

  const columns = [
    { name: "id", title: "ID" },
    { name: "product", title: "Product" },
    { name: "owner", title: "Owner" },
  ];
  const rows = [
    { id: 0, product: "DevExtreme", owner: "DevExpress" },
    { id: 1, product: "DevExtreme Reactive", owner: "DevExpress" },
  ];

  return (
    <Paper>
      <Grid rows={rows} columns={columns} rootComponent={undefined}>
        <Table />
        <TableHeaderRow />
      </Grid>
    </Paper>
  );
}
