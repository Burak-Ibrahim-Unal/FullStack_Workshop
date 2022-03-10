import axios, { AxiosResponse } from "axios";
import { Vehicle } from '../models/vehicle';


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

const Vehicles = {
      list: () => requests.get<Vehicle[]>("/vehicles"),
      details: (id: string) => requests.get<Vehicle>(`/vehicles/${id}`),
      create: (vehicle: Vehicle) => axios.post<void>("/vehicles", vehicle),
      update: (vehicle: Vehicle) => axios.put<void>(`/vehicles/${vehicle.id}`, vehicle),
      delete:(id: string) => axios.delete<void>(`/vehicles/${id}`),

      }
      const agent = {
            Vehicles
      }

export default agent;