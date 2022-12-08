import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import React, { useCallback, useEffect, useState } from "react";
import { Route, Switch } from "react-router";
import { ToastContainer } from "react-toastify";
import AboutPage from "../../features/about/AboutPage";
import { fetchCurrentUser } from "../../features/account/accountSlice";
import Login from "../../features/account/Login";
import Register from "../../features/account/Register";
import ContactPage from "../../features/Contact/Contact";
import HomePage from "../../features/home/HomePage";
import ProductDetails from "../../features/product/ProductDetails";
import ProductList from "../../features/product/ProductList";
import NotFound from "../errors/NotFound";
import ServerError from "../errors/ServerError";
import { useAppDispatch } from "../store/configureStore";
import Header from "./Header";
import LoadingComponent from "./LoadingComponent";
import "./styles.css";

function App() {
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(true);

  const initApp = useCallback(async () => {
    try {
      await dispatch(fetchCurrentUser());
    } catch (error) {
      console.log(error);
    }
  }, [dispatch])

  useEffect(() => {
    initApp().then(() => setLoading(false));
  }, [initApp])

  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? 'dark' : 'light'
  const theme = createTheme({
    palette: {
      mode: paletteType,
      background: {
        default: paletteType === 'light' ? '#eaeaea' : '#121212'
      }
    }
  })

  function handleDarkThemeChange() {
    setDarkMode(!darkMode);
  }

  if (loading) return <LoadingComponent message='Initialising app...' />
  
  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
      <CssBaseline />
      <Header darkMode={darkMode} handleDarkThemeChange={handleDarkThemeChange} />
      <Container>
        <Switch>
          <Route exact path='/' component={HomePage} />
          <Route exact path='/products' component={ProductList} />
          <Route path='/products/:id' component={ProductDetails} />
          <Route path='/about' component={AboutPage} />
          <Route path='/contact' component={ContactPage} />
          <Route path='/server-error' component={ServerError} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <Route component={NotFound} />
        </Switch>
      </Container>
    </ThemeProvider>
  );
}

export default App;
