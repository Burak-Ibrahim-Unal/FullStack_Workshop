import axios, { AxiosError, AxiosResponse } from 'axios';

axios.defaults.baseURL = "http://localhost:5029/api/";

const responseBody = (response: AxiosResponse) => response.data;

// function responseBodyFn(response:AxiosResponse){
//     return response.data;
// }

axios.interceptors.response.use(response => {
    return response;
}, (error: AxiosError) => {
    console.log("Error caught by Axios Interceptors");
    return Promise.reject(error.response);
})

const requests = {
    get: (url: string) => axios.get(url).then(responseBody),
    post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody),
}

const Catalog = {
    list: () => requests.get("Products"),
    details: (id: number) => requests.get(`Products/${id}`),

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
    TestErrors,
}

export default agent;