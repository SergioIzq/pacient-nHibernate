import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PacientService {

  private baseUrl = 'http://localhost:5054/Pacient'; 

  constructor(private http: HttpClient) { }

  getAllPacients(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
  }

  postPacient(pacientData: any): Observable<any> {
    // Definir las cabeceras para especificar el tipo de contenido como application/json
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    
    return this.http.post(this.baseUrl, pacientData, { headers });
  }

  deletePacient(id: number): Observable<any> {
    // Construir la URL completa con el ID del empleado a eliminar
    const url = `${this.baseUrl}/${id}`;
    
    return this.http.delete(url);
  }
}
