import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private baseUrl = 'http://localhost:5054/Patient'; 

  constructor(private http: HttpClient) { }

  getAllPatients(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }

  postPatient(patientData: any): Observable<any> {
    // Definir las cabeceras para especificar el tipo de contenido como application/json
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    
    return this.http.post(this.baseUrl, patientData, { headers });
  }

  deletePatient(id: number): Observable<any> {
    // Construir la URL completa con el ID del empleado a eliminar
    const url = `${this.baseUrl}/${id}`;
    
    return this.http.delete(url);
  }
}
