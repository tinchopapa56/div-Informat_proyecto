import React from 'react'
import reactLogo from '../assets/react.svg'
import { toast } from 'react-toastify'


import { Consulta, Medico, Paciente } from './interfaces'
import API_agent from './Api'

interface Props{
  pacientesArr: Paciente[]
}

const Tablapaciente:React.FC<Props> = ({pacientesArr} : Props) => {

  const deleteI = "https://i.gadgets360cdn.com/large/delete_apps_thumb_1532676846539.jpg"
  const editI = "https://image.shutterstock.com/image-vector/create-icon-260nw-238157620.jpg"

  const handleAdd = async () => {
    const res = await API_agent.Pacientes.create()
    toast("Created!", {position: "bottom-right", theme:"dark"})
    // toast.success("Created")
  }
  const handleDelete = async (id: string) => {
    const res = await API_agent.Pacientes.delete(id)
    toast("Deleted!", {position: "bottom-right", theme:"dark"})
  }

  return (
    <table style={{border: "2px solid red"}}>
        <thead>
          <h2>Pacientes</h2>
        </thead>
        <tbody>
            <tr>
                <td>Id </td>
                <td>Nombre </td>
                <td>Consultas </td>
            </tr>
            {pacientesArr && pacientesArr.map(paciente => (
            <tr key={paciente.h_Clinica}>
                <td>{paciente.h_Clinica} </td>
                <td>{paciente.name} </td>
                <td>{paciente.consultas ? paciente.consultas.length : 0} </td>
                <td>
                <img src={editI} onClick={() => toast("Coming Soon!")}  width="35px" />
                <img src={deleteI} onClick={() => handleDelete(paciente.h_Clinica)} width="50px" />
                </td>
            </tr>
            ))} 
            <tr>
            <button onClick={() => handleAdd()}>
            Add
            </button>
            </tr>
        </tbody>
    </table>
  )
}

export default Tablapaciente