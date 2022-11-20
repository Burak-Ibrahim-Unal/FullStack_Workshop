import {
  Avatar,
  Button,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Typography,
} from "@mui/material";
import { Product } from "../../app/models/product";

interface Props {
  products: Product[];
  addProduct: () => void;
}

export default function ProductList({ products, addProduct }: Props) {
  return (
    <div>
      <Typography variant="h2">Ecom</Typography>
      <List>
        {products.map((item, index) => (
          <ListItem key={index}>
            <ListItemAvatar>
              <Avatar src={item.pictureUrl} />
            </ListItemAvatar>
            <ListItemText>{item.name} -- {item.price}</ListItemText>
          </ListItem>
        ))}
      </List>
      <Button variant="contained" onClick={addProduct}>Kaydet</Button>
    </div>
  );
}
