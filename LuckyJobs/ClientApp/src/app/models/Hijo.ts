import { Personal } from "./Personal";

export interface Hijo {
  idDerHab: number,
  apPaterno: string,
  apMaterno: string,
  nombre1: string,
  nombre2: string | null,
  nombreCompleto: string,
  fchNac: Date,
  padre: Personal,
  estado: boolean
}
