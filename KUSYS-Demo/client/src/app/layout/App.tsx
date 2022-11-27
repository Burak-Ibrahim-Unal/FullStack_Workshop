import { createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { Container } from "@mui/system";
import { useCallback, useEffect, useState } from "react";
import { Route, Routes } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import Header from "./Header";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import LoadingComponent from "./LoadingComponent";
import CheckoutPage from "../../features/checkout/CheckoutPage";
import { useAppDispatch } from "../store/configureStore";
import Login from "../../features/auth/Login";
import Register from "../../features/auth/Register";
import { fetchCurrentUser } from "../../features/auth/authSlice";
import StudentDetail from "../../features/student/StudentDetail";
import Catalog from "../../features/student/Catalog";

function App() {
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(true);

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
    } catch (error: any) {
      console.log(error);
    }
  }, [dispatch]);

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp]);

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

  if (loading) return <LoadingComponent loadingMessage="Initializing..." />;

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
          <Route path="/catalog/:id" element={<StudentDetail />} />
          <Route path="/about" element={<AboutPage />} />
          <Route path="/contact" element={<ContactPage />} />
          <Route path="/server-error" element={<ServerError />} />
          <Route path="/checkout" element={<CheckoutPage />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route element={<NotFound />} />
        </Routes>
      </Container>
    </ThemeProvider>
  );
}

export default App;
