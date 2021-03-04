export interface Personal{
  idPersonal: number,
  apPaterno: string,
  apMaterno: string,
  nombre1: string,
  nombre2: string | null,
  nombreCompleto: string,
  fchNac: Date,
  fchIngreso: Date,
  estado: boolean
}
