import { PaginatedResponse } from './../models/pagination';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { history } from '../..';
import { store } from '../store/configureStore';

const sleep = () => new Promise(resolve => setTimeout(resolve, 700));

axios.defaults.baseURL = "http://localhost:5096/api/";
axios.defaults.withCredentials = true; // to receive cookies

const responseBody = (response: AxiosResponse) => response.data;

axios.interceptors.request.use(config => {
    const token = store.getState().auth.user?.token;
    if (token) config.headers!.Authorization = `Bearer ${token}`;
    return config;
})

axios.interceptors.response.use(async response => {
    await sleep();
    //console.log(response);
    const pagination = response.headers["pagination"]; //lowercase only
    if (pagination) {
        response.data = new PaginatedResponse(response.data, JSON.parse(pagination));
        console.log(response);
        return response;
    }
    return response;
}, (error: AxiosError) => {
    console.log("Error caught by Axios Interceptors");
    const { data, status } = error.response as any;
    switch (status) {
        case 400:
            if (data.errors) {
                const modelStateErrors: string[] = [];
                for (const key in data.errors) {
                    if (data.errors[key]) {
                        modelStateErrors.push(data.errors[key])
                    }
                }
                throw modelStateErrors.flat();
            }
            toast.error(data.title);
            break;
        case 401:
            toast.error(data.title || "Unauthorized");
            break;
        case 404:
            toast.error(data.title);
            break;
        case 500:
            history.push({
                pathname: "/server-error",
                // state:{error:data}
            });
            toast.error(data.title);
            break;
        default:
            break;
    }
    return Promise.reject(error.response);
})

const requests = {
    get: (url: string, params?: URLSearchParams) => axios.get(url, { params }).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

const Catalog = {
    list: (params: URLSearchParams) => requests.get("Students", params),
    details: (id: number) => requests.get(`Students/${id}`),
    fetchFilters: () => requests.get("Students/filters")

}

const Auth = {
    login: (values: any) => requests.post("Auth/login", values),
    register: (values: any) => requests.post("Auth/register", values),
    currentUser: () => requests.get("Auth/currentUser"),
    role: (values: any) => requests.get("Auth/role",values),
}

const TestErrors = {
    get400Error: () => requests.get("buggy/bad-request"),
    get401Error: () => requests.get("buggy/unauthorized"),
    get404Error: () => requests.get("buggy/not-found"),
    get500Error: () => requests.get("buggy/server-error"),
    getValidationError: () => requests.get("buggy/validation-error"),
}

const agent = {
    Catalog,
    Auth,
    TestErrors,
}

export default agent;