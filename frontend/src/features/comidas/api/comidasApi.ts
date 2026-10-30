
// Importamos la interfaz Comida
import type { Comida } from '../types/comida.types'

// Función asíncrona que retorna una Promesa con el arreglo de comidas
export const obtenerComidasAsync = (): Promise<Comida[]> => {

    return new Promise((resolve) => {

        setTimeout(() => {

            const datosCatalogo: Comida[] = [
                { id: 1, nombre: 'Baleada Sencilla', precio: 13 },
                { id: 2, nombre: 'Baleada con Huevo', precio: 24 },
                { id: 3, nombre: 'Baleada con Carne', precio: 33 },
            ]

            resolve(datosCatalogo)

        }, 1000)

    })
}
