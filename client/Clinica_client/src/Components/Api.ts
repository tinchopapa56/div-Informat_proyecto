import axios, { AxiosResponse } from "axios";
import { Medico, Paciente, Consulta } from "./interfaces";


// axios.defaults.baseURL = "/api"
// axios.defaults.baseURL = "https://bandify.fly.dev/api"
// axios.defaults.baseURL = "http://localhost:5001/api"
// axios.defaults.baseURL = process.env.REACT_APP_API_URL;  

// axios.defaults.baseURL = "http://localhost:7213/api"
axios.defaults.baseURL = "https://localhost:7213/api/"
// axios.defaults.baseURL = "http://localhost:5264/api/"

const HARDMedico = {
    "name": "nombreHARD",
    // nMatricula: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nMatricula": self.crypto.randomUUID(),
    "especialidad": "Otorrino"
  } 
//   const HARDPaciente = {
//     "name": "nombreCODED",
//     "h_Clinica": self.crypto.randomUUID(),
//     "consultas": []
//   } 


const resBody = <T> (response: AxiosResponse<T>) => response.data;
const requests = {
    get: <T> (url:string) => axios.get<T>(url).then(resBody),
    post: <T> (url:string, body: {}) => axios.post<T>(url, body).then(resBody),
    put: <T> (url:string, body: {}) => axios.put<T>(url, body).then(resBody),
    del: <T> (url:string) => axios.delete<T>(url).then(resBody),
}
const Medicos = {
    list: () => axios.get<Medico[]>("/Doctors"),
    getById: (id: string) => requests.get<Medico>(`/Doctors/${id}`),
    create: () => requests.post<void>('/Doctors', {
                    "name": "nombreHARD",
                    "nMatricula": self.crypto.randomUUID(),
                    "especialidad": "Otorrino"
                }
    ),

    delete: (id: string) => requests.del<void>(`/Doctors/${id}`),
}

const Pacientes = {
    list: () => axios.get<Paciente[]>("/pacientes"),
    getById: (id: string) => requests.get<Paciente>(`/pacientes/${id}`),
    create: () => requests.post<void>('/pacientes', {
        "name": "nombreCODED",
        "h_Clinica": self.crypto.randomUUID(),
        "consultas": []
      }),
    // create: (activity: ActivityFormValues) => requests.post<void>('/activities', activity),
    // update: (activity: ActivityFormValues) => requests.put<void>(`/activities/${activity.id}`, activity),
    delete: (id: string) => requests.del<void>(`/pacientes/${id}`),
}
const Consultas = {
    list: () => axios.get<Consulta[]>("/consultas"),
    getById: (id: string) => requests.get<Consulta>(`/consultas/${id}`),

    create: () => requests.post<void>('/consultas?pacienteId=3fa85f64-5717-4562-b3fc-2c963f66afa6', {
        "consultaId": self.crypto.randomUUID(),
        "medicoId": "3fa85f64-5717-4762-b3fc-2c963f66afa6",
        "fecha": new Date(),
        "costo": 452,
        "costoMateriales": 45,
        "tipo": "number",
        "descripcion" : "consulta muy importante de salud",
      }
    ),
    delete: (id: string) => requests.del<void>(`/consultas/${id}`),
}
const API_agent = {
    Medicos,
    Pacientes,
    Consultas
}
export default API_agent;