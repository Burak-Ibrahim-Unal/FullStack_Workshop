import axios, { AxiosResponse } from "axios";
import { Car } from '../models/car';


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

const Cars = {
      list: () => requests.get<Car[]>("/cars"),
      details: (id: number) => requests.get<Car>(`/cars/${id}`),
      create: (car: Car) => axios.post<void>("/cars", car),
      update: (car: Car) => axios.put<void>(`/cars/${car.id}`, car),
      delete:(id: number) => axios.delete<void>(`/cars/${id}`),

      }
      const agent = {
            Cars
      }

export default agent;