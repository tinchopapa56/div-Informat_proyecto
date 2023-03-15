import React from 'react'
import { toast } from 'react-toastify'
import reactLogo from '../assets/react.svg'
import API_agent from './Api'


import { Consulta, cut } from './interfaces'

interface Props{
    consultasArr: Consulta[]
}

const TablaConsulta:React.FC<Props> = ({consultasArr} : Props) => {

  const deleteI = "https://i.gadgets360cdn.com/large/delete_apps_thumb_1532676846539.jpg"
  const editI = "https://image.shutterstock.com/image-vector/create-icon-260nw-238157620.jpg"

  const handleAdd = async () => {
    const res = await API_agent.Consultas.create()
    toast("Created!", {position: "bottom-right", theme:"dark"})
    // toast.success("Created")
  }
  const handleDelete = async (id: string) => {
    const res = await API_agent.Consultas.delete(id)
    toast("Deleted!", {position: "bottom-right", theme:"dark"})
  }

  return (
    <table style={{border: "2px solid red"}}>
        <thead>
          <h2>Consultas</h2>
        </thead>
        <tbody>
            <tr>
              <td>ID </td>
              <td>MEDICO ID </td>
              <td>Fecha </td>
              <td>Tipo</td>
              <td>Costo </td>
              <td>Descripcion </td>
              <td>Costo Materiales  </td>
            </tr>
            {consultasArr && consultasArr.map((consulta) => (
            <tr key={consulta.consultaId}>
              <td>{consulta.consultaId.slice(0,15) + "..."}</td>
              <td>{consulta.medicoId.slice(0,15) + "..."}</td>
              <td>{consulta.fecha.toString().slice(0,10)}</td>
              <td>{consulta.tipo}</td>
              <td>{consulta.costo}</td>
              <td>{consulta.descripcion}</td>
              <td>{consulta.costoMateriales} </td>
              <td>
                <img src={editI} onClick={() => toast("Coming Soon!")}  width="35px" />
                <img src={deleteI} onClick={() => handleDelete(consulta.consultaId)} width="50px" />
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

export default TablaConsulta