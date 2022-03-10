import axios, { AxiosResponse } from "axios";
import { Location } from '../models/location';


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

const Locations = {
      list: () => requests.get<Location[]>("/locations"),
      details: (id: number) => requests.get<Location>(`/locations/${id}`),
      create: (location: Location) => axios.post<void>("/locations", location),
      update: (location: Location) => axios.put<void>(`/locations/${location.id}`, location),
      delete:(id: number) => axios.delete<void>(`/locations/${id}`),

      }
      const agent = {
            Locations
      }

export default agent;