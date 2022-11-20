import { ShoppingCart } from "@mui/icons-material";
import {
  AppBar,
  Badge,
  IconButton,
  List,
  ListItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { NavLink } from "react-router-dom";
import DarkModeSwitch from "./DarkModeSwitch";

interface Props {
  darkMode: boolean;
  handleDarkThemeChange: () => void;
}

const headerMidLinks = [
  { title: "catalog", path: "/catalog" },
  { title: "about", path: "/about" },
  { title: "contact", path: "/contact" },
];

const headerRightLinks = [
  { title: "login", path: "/login" },
  { title: "register", path: "/register" },
];

export default function Header({ darkMode, handleDarkThemeChange }: Props) {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Typography
          variant="h6"
          component={NavLink}
          to="/"
          sx={{ color: "inherit", textDecoration: "none" }}
        >
          ECOM
        </Typography>
        <DarkModeSwitch
          darkMode={darkMode}
          handleDarkThemeChange={handleDarkThemeChange}
        />
        <List sx={{ display: "flex" }}>
          {headerMidLinks.map(({ title, path }) => (
            <ListItem
              component={NavLink}
              to={path}
              key={path}
              sx={{ color: "inherit", typography: "h6" }}
            >
              {title.toUpperCase()}
            </ListItem>
          ))}
        </List>
        <IconButton size="large" sx={{ color: "inherit" }}>
          <Badge badgeContent={4} color="secondary">
            <ShoppingCart />
          </Badge>
        </IconButton>
        <List sx={{ display: "flex" }}>
          {headerRightLinks.map(({ title, path }) => (
            <ListItem
              component={NavLink}
              to={path}
              key={path}
              sx={{ color: "inherit", typography: "h6" }}
            >
              {title.toUpperCase()}
            </ListItem>
          ))}
        </List>
      </Toolbar>
    </AppBar>
  );
}
