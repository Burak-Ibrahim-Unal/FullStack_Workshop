import ReactDOM from "react-dom/client";
import "./app/layout/styles.css";
import App from "./app/layout/App";
import reportWebVitals from "./reportWebVitals";
import { createBrowserHistory } from "history";
import CustomRouter from "./CustomRouter";
import { StoreProvider } from "./app/context/StoreContext";
import { Provider } from "react-redux";
import { store } from "./app/store/configureStore";

export const history = createBrowserHistory();

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <CustomRouter history={history}>
    <StoreProvider>
      <Provider store={store}>
        <App />
      </Provider>
    </StoreProvider>
  </CustomRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
