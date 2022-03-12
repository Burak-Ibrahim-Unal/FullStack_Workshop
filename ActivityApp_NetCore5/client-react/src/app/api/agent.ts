import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../..";
import { Activity } from '../models/activity';


const sleep = (delay: number) => {
      return new Promise((resolve) => {
            setTimeout(resolve, delay);
      })
}

axios.defaults.baseURL = "http://localhost:5001/api";
const testUrl = "http://localhost:5001/";

axios.interceptors.response.use(async response => {
      try {
            await sleep(1000);
            return response;
      } catch (error) {
            console.log(error);
            return await Promise.reject(error);
      }
}, (error: AxiosError) => {
      const { data, status } = error.response!;
      switch (status) {
            case 400:
                  toast.error("bad request ...");
                  break;
            case 401:
                  toast.error("unauthorized...");
                  break;
            case 404:
                  history.push("not-found");
                  break;
            case 500:
                  toast.error("server error ...");
                  break;


            default:
                  break;
      }
      return Promise.reject(error);

})

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
      get: <T>(url: string) => axios.get<T>(url).then(responseBody),
      post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
      put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
      del: <T>(url: string) => axios.delete<T>(url).then(responseBody),

}

const Activities = {
      list: () => requests.get<Activity[]>("/activities"),
      details: (id: string) => requests.get<Activity>(`/activities/${id}`),
      create: (activity: Activity) => axios.post<void>("/activities", activity),
      update: (activity: Activity) => axios.put<void>(`/activities/${activity.id}`, activity),
      delete: (id: string) => axios.delete<void>(`/activities/${id}`),

}
const agent = {
      Activities
}

export default agent;