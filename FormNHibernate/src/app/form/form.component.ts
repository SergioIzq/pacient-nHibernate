import { Component, OnInit } from '@angular/core';
import { PacientService } from '../pacient-data.service';
import { tap, of, catchError } from 'rxjs';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  pacientName?: string;
  pacientAge?: string;

  pacients: any[] = [];

  constructor(private pacientService: PacientService) { }

  ngOnInit() {
    this.loadPacients(); 
  }

  submitForm() {
        
    const formData = {
      name: this.pacientName,
      age: this.pacientAge
    };

    this.pacientService.postPacient(formData).pipe(
      tap((response) => {
        console.log('Paciente agregado correctamente:', response);
        this.pacientName = '';
        this.pacientAge = '';

        this.loadPacients();
      }),
      catchError((error) => {
        console.error('Error al agregar el paciente:', error);
        return of(null);
      })
    ).subscribe();
  }

  loadPacients() {
    this.pacientService.getAllPacients().pipe(
      tap((response) => {
        this.pacients = response; 
      }),
      catchError((error) => {
        console.error('Error al obtener los pacientes:', error);
        throw error; // Propagar el error para que pueda ser manejado externamente
      })
    ).subscribe();
  }

  deletePacient(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar este paciente?')) {
      this.pacientService.deletePacient(id).pipe(
        tap((response) => {
          console.log('Paciente eliminado correctamente:', response);
          this.loadPacients();
        }),
        catchError((error) => {
          console.error('paciente al eliminar el empleado:', error);
          throw error; // Propagar el error para que pueda ser manejado externamente
        })
      ).subscribe();
    }
  }

}
