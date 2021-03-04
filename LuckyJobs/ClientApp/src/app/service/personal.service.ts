import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Personal } from '../models/Personal';

@Injectable({
  providedIn: 'root'
})
export class PersonalService {

  constructor(private http: HttpClient) { }

  getPersonal() {
    return this.http.get<Personal[]>('/api/personal');
  }

  addPersonal(employee: Personal) {
    return this.http.post<Personal>('/api/personal', employee);
  }

  editPersonal(employee: Personal) {
    return this.http.put<Personal>(`/api/personal/${employee.idPersonal}`, employee);
  }

  deletePersonal(id: number) {
    return this.http.delete<boolean>(`/api/personal/${id}`);
  }
}
