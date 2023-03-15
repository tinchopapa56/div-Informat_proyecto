import React from 'react'
import { toast } from 'react-toastify'
import reactLogo from '../assets/react.svg'
import API_agent from './Api'


import { Consulta, Medico, Paciente } from './interfaces'

interface Props{
  medicosArr: Medico[]
}


const TablaEntidad:React.FC<Props> = ({medicosArr} : Props) => {

  const deleteI = "https://i.gadgets360cdn.com/large/delete_apps_thumb_1532676846539.jpg"
  const editI = "https://image.shutterstock.com/image-vector/create-icon-260nw-238157620.jpg"

  const handleAdd = async () => {
    const res = await API_agent.Medicos.create()
    toast("Created!", {position: "bottom-right", theme:"dark"})

  }
  const handleDelete = async (id: string) => {
    const res = await API_agent.Medicos.delete(id)
    toast("Deleted!", {position: "bottom-right", theme:"dark"})
  }

  return (
    <table style={{border: "2px solid red"}}>
        <thead>
          <h2>Medicos</h2>
        </thead>
        <tbody>
            <tr>
                <th>Id(matricula) </th>
                <th>Nombre </th>
                <th>Especialidad </th>
            </tr>
            {medicosArr && medicosArr.map((medico) => (
            <tr key={medico.nMatricula}>
                <td>{medico.nMatricula} </td>
                <td>{medico.name} </td>
                <td>{medico.especialidad}</td>
                <td>
                  <img src={editI} onClick={() => toast("Coming Soon!")}  width="35px" />
                  <img src={deleteI} onClick={() => handleDelete(medico.nMatricula)} width="50px" />
                </td>
            </tr>
            ))} 
            <tr>
            {/* <button onClick={() => setCount((count) => count + 1)}> */}
            <button onClick={() => handleAdd()}>
            Add
            </button>
            </tr>
        </tbody>
    </table>
  )
}

export default TablaEntidad