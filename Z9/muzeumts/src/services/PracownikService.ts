import http from "../http-common";
import IPracownikData from "../types/Pracownik";

const getAll = () => {
  return http.get<Array<IPracownikData>>("/Pracownik/GetAllPracownik");
};
const get = (pracownikId: any) => {
  return http.get<IPracownikData>(`/Pracownik/${pracownikId}`);
};
const create = (data: IPracownikData) => {
  return http.post<IPracownikData>("/Pracownik", data);
};
const update = (pracownikId: any, data: IPracownikData) => {
  return http.patch<any>(`/Pracownik/edit/${pracownikId}`, data);
};
const remove = (pracownikId: any) => {
  return http.delete<any>(`/pracownik/delete/${pracownikId}`);
};
const removeAll = () => {
  return http.delete<any>(`/Pracownik/`);
};
const findById = (pracownikId: string) => {
  return http.get<Array<IPracownikData>>(`/Pracownik/${pracownikId}`);
};
const PracownikService = {
  getAll,
  get,
  create,
  update,
  remove,
  removeAll,
  findById,
};
export default PracownikService;