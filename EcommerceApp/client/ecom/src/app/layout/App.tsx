import { createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Container } from "@mui/system";
import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import Catalog from "../../features/product/Catalog";
import Header from "./Header";
import ProductDetail from "../../features/product/ProductDetail";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import BasketPage from "../../features/basket/BasketPage";

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const palletType = darkMode ? "dark" : "light";

  const theme = createTheme({
    palette: {
      mode: palletType,
      background: {
        default: palletType === "light" ? "#D3D3D3" : "#30333A",
      },
    },
  });

  function handleDarkThemeChange() {
    setDarkMode(!darkMode);
  }

  return (
    <ThemeProvider theme={theme}>
      <ToastContainer
        position="bottom-center"
        hideProgressBar
        theme="colored"
      />
      <CssBaseline />
      <Header
        darkMode={darkMode}
        handleDarkThemeChange={handleDarkThemeChange}
      />
      <Container>
        <Routes>
          {" "}
          {/* switch router 5 */}
          <Route path="/" element={<HomePage />} />
          <Route path="/catalog" element={<Catalog />} />
          <Route path="/catalog/:id" element={<ProductDetail />} />
          <Route path="/about" element={<AboutPage />} />
          <Route path="/contact" element={<ContactPage />} />
          <Route path="/server-error" element={<ServerError />} />
          <Route path="/basket" element={<BasketPage />} />
          <Route element={<NotFound />} />

        </Routes>
      </Container>
    </ThemeProvider>
  );
}

export default App;
