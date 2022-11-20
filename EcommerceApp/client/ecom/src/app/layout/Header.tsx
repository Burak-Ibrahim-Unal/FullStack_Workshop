import {
  AppBar,
  Toolbar,
  Typography,
} from "@mui/material";
import DarkModeSwitch from "./DarkModeSwitch";

interface Props {
  darkMode: boolean;
  handleDarkThemeChange: () => void;
}

export default function Header({ darkMode, handleDarkThemeChange }: Props) {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Toolbar>
        <Typography variant="h6">ECOM</Typography>
        <DarkModeSwitch darkMode={darkMode} handleDarkThemeChange={handleDarkThemeChange}/>
      </Toolbar>
    </AppBar>
  );
}
