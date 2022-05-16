import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { history } from "../..";
import { Activity, ActivityFormValues } from '../models/activity';
import { Photo, Profile } from "../models/profile";
import { User, UserFormValues } from '../models/user';
import CommonStore from '../stores/commonStore';
import { store } from "../stores/store";


const sleep = (delay: number) => {
      return new Promise((resolve) => {
            setTimeout(resolve, delay);
      })
}

axios.defaults.baseURL = "http://localhost:5001/api";


axios.interceptors.request.use(config => {
      const token = store.commonStore.token;
      if (token) config.headers!.Authorization = `Bearer ${token}`;
      return config;
});


axios.interceptors.response.use(async response => {
      try {
            await sleep(1000);
            return response;
      } catch (error) {
            console.log(error);
            return await Promise.reject(error);
      }
}, (error: AxiosError) => {
      const { data, status, config } = error.response!;
      switch (status) {
            case 400:
                  if (typeof data === "string") {
                        toast.error(data)
                  }
                  if (config.method === "get" && data.errors.hasOwnProperty("id")) {
                        history.push("/not-found");
                  }
                  if (data.errors) {
                        const modalStateErrors = [];
                        for (const key in data.errors) {
                              if (data.errors[key]) {
                                    modalStateErrors.push(data.errors[key]);
                              }
                        }
                        throw modalStateErrors.flat();
                  }
                  break;
            case 401:
                  toast.error("unauthorized...");
                  break;
            case 404:
                  history.push("not-found");
                  break;
            case 500:
                  store.commonStore.setServerError(data);
                  history.push("/server-error");
                  //toast.error("server error ...");
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
      create: (activity: ActivityFormValues) => requests.post<void>("/activities", activity),
      update: (activity: ActivityFormValues) => requests.put<void>(`/activities/${activity.id}`, activity),
      delete: (id: string) => requests.del<void>(`/activities/${id}`),
      attend: (id: string) => requests.post<void>(`/activities/${id}/attend`, {})

}

const Accounts = {
      current: () => requests.get<User>("/accounts"),
      login: (user: UserFormValues) => requests.post<User>("/accounts/login", user),
      register: (user: UserFormValues) => requests.post<User>("/accounts/register", user),

}

const Profiles = {
      get: (username: string) => requests.get<Profile>(`/profiles/${username}`),
      uploadPhoto: (file: Blob) => {
            let formData = new FormData();
            formData.append("File", file);
            return axios.post<Photo>("photos", formData, {
                  headers: { "Content-type": "multipart/form-data " }
            })
      }
}

const agent = {
      Activities,
      Accounts,
      Profiles
}

export default agent;