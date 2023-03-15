import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import './App.css'
import TablaEntidad from './Components/TablaMedico'

import { Medico } from './Components/interfaces'
import TablaMedico from './Components/TablaMedico'
import TablaPaciente from './Components/TablaPaciente'
import TablaConsulta from './Components/TablaConsulta'
import API_agent from './Components/Api'


function App() {
  const[medicos, setMedicos] = useState<any>([])
  const[pacientes, setPacientes] = useState<any>([])
  const[consultas, setConsultas] = useState<any>([])


  useEffect(() => {
      const getMedicos = async () => {
        const res = await API_agent.Medicos.list()
        setMedicos(res.data)
      }
      getMedicos()
  }, [medicos])

  useEffect(() => {
    const getPacientes = async () => {
      const res = await API_agent.Pacientes.list()
      setPacientes(res.data)
    }
    getPacientes()
}, [pacientes])

useEffect(() => {
  const getConsultas = async () => {
    const res = await API_agent.Consultas.list()
    setConsultas(res.data)
  }
  getConsultas()
}, [consultas])

  return (
    <div className="App">

      <h1>Clinica</h1>
      
      <div style={{display:"flex", flexDirection:"column"}}>
        <TablaMedico medicosArr={medicos} />
        <TablaPaciente pacientesArr={pacientes} />
        <TablaConsulta consultasArr={consultas} />
      </div>
     

    </div>
  )
}

export default App

