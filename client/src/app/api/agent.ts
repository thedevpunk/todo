import axios, { AxiosResponse } from "axios";
import { IItem } from "../models/item";

axios.defaults.baseURL = "https://localhost:5001/api";

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  put: (url: string, body: {}) => axios.put(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Items = {
  list: (): Promise<IItem[]> => requests.get("/items"),
  detail: (id: string): Promise<IItem> => requests.get(`/items/${id}`),
  create: (item: IItem) => requests.post("/items", item),
  update: (item: IItem) => requests.put("/items", item),
  delete: (id: string) => requests.delete(`/items/${id}`),
  done: (id: string) => requests.post(`/items/${id}/done`, {}),
  undone: (id: string) => requests.post(`/items/${id}/undone`, {}),
};

export default {
  Items,
};
