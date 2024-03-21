import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { Patient } from './patient.interface';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private baseUrl = 'http://localhost:5054/Patient'; 

  constructor(private http: HttpClient) { }

  getAllPatients(): Observable<Patient[]> {
    return this.http.get<Patient[]>(`${this.baseUrl}`);
  }

  postPatient(patientData: Patient): Observable<Patient> {
    // Definir las cabeceras para especificar el tipo de contenido como application/json
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    
    return this.http.post<Patient>(this.baseUrl, patientData, { headers });
  }

  deletePatient(id: number): Observable<any> {
    // Construir la URL completa con el ID del empleado a eliminar
    const url = `${this.baseUrl}/${id}`;
    
    return this.http.delete(url);
  }
}
