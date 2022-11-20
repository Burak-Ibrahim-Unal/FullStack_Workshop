import { createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Container } from "@mui/system";
import { useState } from "react";
import Catalog from "../../features/product/Catalog";
import Header from "./Header";

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const palletType = darkMode ? "dark" : "light";

  const theme = createTheme({
    palette: {
      mode: palletType,
      background:{
        default:palletType==="light"? "#D3D3D3"  : "#30333A"
      }
    },
  });

  function handleDarkThemeChange() {
    setDarkMode(!darkMode);
  }

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header
        darkMode={darkMode}
        handleDarkThemeChange={handleDarkThemeChange}
      />
      <Container>
        <Catalog />
      </Container>
    </ThemeProvider>
  );
}

export default App;
