import axios, { AxiosResponse } from "axios";
import { Warehouse } from '../models/warehouse';


const sleep = (delay: number) => {
      return new Promise((resolve) => {
            setTimeout(resolve, delay);
      })
}

axios.defaults.baseURL = "http://localhost:5001/api";

axios.interceptors.response.use(async response => {
      try {
            await sleep(1000);
            return response;
      } catch (error) {
            console.log(error);
            return await Promise.reject(error);
      }
})

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
      get: <T>(url: string) => axios.get<T>(url).then(responseBody),
      post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
      put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
      del: <T>(url: string) => axios.delete<T>(url).then(responseBody),

}

const Warehouses = {
      list: () => requests.get<Warehouse[]>("/warehouses"),
      details: (id: number) => requests.get<Warehouse>(`/warehouses/${id}`),
      create: (warehouse: Warehouse) => axios.post<void>("/warehouses", warehouse),
      update: (warehouse: Warehouse) => axios.put<void>(`/warehouses/${warehouse.id}`, warehouse),
      delete:(id: number) => axios.delete<void>(`/warehouses/${id}`),

      }
      const agent = {
            Warehouses
      }

export default agent;