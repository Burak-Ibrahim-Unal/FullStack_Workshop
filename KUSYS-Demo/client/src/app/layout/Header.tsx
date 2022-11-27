import { ShoppingCart } from "@mui/icons-material";
import {
  AppBar,
  Badge,
  Box,
  IconButton,
  List,
  ListItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { Link } from "react-router-dom";
import { NavLink } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";
import DarkModeSwitch from "./DarkModeSwitch";
import SignedInMenu from "./SignedInMenu";

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

const navbarStyles = {
  color: "inherit",
  textDecoration: "none",
  typography: "h6",
  "&:hover": {
    color: "grey.400",
  },
  "&.active": {
    color: "warning.main",
  },
};

export default function Header({ darkMode, handleDarkThemeChange }: Props) {
  const { user } = useAppSelector((state) => state.auth);

  return (
    <AppBar position="static" sx={{ mb: 6 }}>
      <Toolbar
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box display="flex" alignItems="center">
          <Typography variant="h6" component={NavLink} to="/" sx={navbarStyles}>
            ECOM
          </Typography>
        </Box>

        <List sx={{ display: "flex" }}>
          {headerMidLinks.map(({ title, path }) => (
            <ListItem
              component={NavLink}
              to={path}
              key={path}
              sx={navbarStyles}
            >
              {title.toUpperCase()}
            </ListItem>
          ))}
        </List>
        <Box display="flex" alignItems="center">
          <DarkModeSwitch
            darkMode={darkMode}
            handleDarkThemeChange={handleDarkThemeChange}
          />
          {user ? (
            <SignedInMenu />
          ) : (
            <List sx={{ display: "flex" }}>
              {headerRightLinks.map(({ title, path }) => (
                <ListItem
                  component={NavLink}
                  to={path}
                  key={path}
                  sx={navbarStyles}
                >
                  {title.toUpperCase()}
                </ListItem>
              ))}
            </List>
          )}
        </Box>
      </Toolbar>
    </AppBar>
  );
}
