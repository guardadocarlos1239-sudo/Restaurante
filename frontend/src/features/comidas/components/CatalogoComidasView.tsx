
import { useState, useEffect } from 'react'
import type { Comida } from '../types/comida.types'
import { obtenerComidasAsync } from '../api/comidasApi'
import { ComidaCard } from './ComidaCard'

export function CatalogoComidasView() {

  // ZONA 1: ESTADOS DEL MÓDULO

  const [comidas, setComidas] = useState<Comida[]>([])
  const [cargando, setCargando] = useState<boolean>(true)
  const [busqueda, setBusqueda] = useState<string>('')

  // ZONA 2: CONSUMO DE LA CAPA API

  useEffect(() => {

    obtenerComidasAsync().then((datos) => {
      setComidas(datos)
      setCargando(false)
    })

  }, [])

  // ZONA 3: FILTRADO DE COMIDAS

  const comidasFiltradas = comidas.filter((comida) =>
    comida.nombre.toLowerCase().includes(busqueda.toLowerCase())
  )

  // ZONA 4: RENDERIZADO DEL CATÁLOGO

  return (
    <div>

      {/* BARRA SUPERIOR */}
      <div className="flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4 pb-6 mb-6 border-b border-slate-800">

        <div>
          <h1 className="text-2xl md:text-3xl font-bold text-white">
            Catálogo de Comidas
          </h1>

          <p className="text-slate-400 text-sm mt-1">
            Módulo de comidas organizado bajo arquitectura
            <code className="text-indigo-400 font-mono"> Vertical Slicing</code>.
          </p>
        </div>

        <button
          disabled
          className="bg-indigo-600 text-white font-medium text-sm px-4 py-2.5 rounded-lg opacity-60 cursor-not-allowed"
        >
          + Nueva Comida (Próximamente)
        </button>

      </div>

      {/* BUSCADOR */}
      <div className="mb-6 flex flex-col sm:flex-row sm:items-center justify-between gap-4">

        <input
          type="text"
          placeholder="🔍 Buscar comidas en el catálogo..."
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
          className="w-full sm:max-w-md bg-slate-950 border border-slate-800 rounded-lg px-4 py-2.5 text-sm text-white placeholder-slate-500 focus:outline-none focus:border-indigo-500 transition-colors"
        />

        <span className="text-xs text-slate-400">
          Mostrando <strong className="text-white">{comidasFiltradas.length}</strong> de {comidas.length} registros
        </span>

      </div>

      {/* CARGA Y REJILLA DE COMIDAS */}
      {cargando ? (

        <div className="bg-slate-800/50 border border-slate-800 rounded-xl p-12 text-center">
          <p className="text-indigo-400 font-semibold animate-pulse text-lg">
            ⏳ Consultando capa de servicios (comidasApi.ts)...
          </p>
        </div>

      ) : (

        <section className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-5">

          {comidasFiltradas.map((comida) => (
            <ComidaCard
              key={comida.id}
              id={comida.id}
              nombre={comida.nombre}
              precio={comida.precio}
            />
          ))}

        </section>

      )}

    </div>
  )
}
