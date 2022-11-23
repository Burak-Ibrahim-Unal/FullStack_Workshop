import counterReducer from "../../features/contact/counterReducer";
import {createStore} from "redux";

export function configureStore() {
    return createStore(counterReducer);
}