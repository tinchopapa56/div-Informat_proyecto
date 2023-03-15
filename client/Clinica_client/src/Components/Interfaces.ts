export interface Medico {
    // id: string,
    nMatricula: string,
    especialidad: string,
    name: string
}
export interface Paciente {
    // id: string,
    h_Clinica: string,
    consultas: Consulta[],
    name: string
}
export interface Consulta {
    consultaId: string,
    medicoId: string,
    fecha: Date,
    costo: number,
    costoMateriales: number,
    tipo: number,
    name: string,
    descripcion : string,
}
export function cut(text: string){
    if(text.length > 10)
    return text.slice(0,5)
}