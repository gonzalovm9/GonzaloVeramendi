import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Hijo } from '../models/Hijo';

@Injectable({
  providedIn: 'root'
})
export class HijoService {

  constructor(private http: HttpClient) { }

  getHijosByPersonal(idPersonal: number) {
    console.log(idPersonal);
    return this.http.get<Hijo[]>(`/api/hijos/personal/${idPersonal}`);
  }

  addHijo(employee: Hijo) {
    return this.http.post<Hijo>('/api/hijos', employee);
  }

  editHijo(employee: Hijo) {
    return this.http.put<Hijo>(`/api/hijos/${employee.idDerHab}`, employee);
  }

  deleteHijo(id: number) {
    return this.http.delete<boolean>(`/api/hijos/${id}`);
  }
}
