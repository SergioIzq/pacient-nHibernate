import { Component, OnDestroy, OnInit } from '@angular/core';
import { PatientService } from '../patient-data.service';
import { tap, of, catchError, Subject, map, takeUntil } from 'rxjs';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit/*, OnDestroy*/ {
  patientName?: string;
  patientAge?: string;

  // private subject: Subject<boolean> = new Subject<boolean>();

  patients: Array<{id:number, name: string, age: number}> = [];


  constructor(private patientService: PatientService) { }
 

  ngOnInit() {
    this.loadPatients(); 
  }

  // ngOnDestroy(): void {
  //   this.subject.next(true);
  //   this.subject.complete();
  // }

  submitForm() {
        
    const formData = {
      name: this.patientName,
      age: this.patientAge
    };

    // this.patientService.postPacient(formData).pipe(takeUntil(this.subject)).subscribe( res => res)

    this.patientService.postPatient(formData).pipe(
      // takeUntil(this.subject),
      map((response) => {
        console.log('Paciente agregado correctamente:', response);
        this.patientName = '';
        this.patientAge = '';

        this.loadPatients();
      }),
      catchError((error) => {
        console.error('Error al agregar el paciente:', error);
        return of(null);
      })
    ).subscribe();
  }

  loadPatients() {
    this.patientService.getAllPatients().pipe(
      tap((response) => {
        this.patients = response; 
      }),
      catchError((error) => {
        console.error('Error al obtener los pacientes:', error);
        throw error; // Propagar el error para que pueda ser manejado externamente
      })
    ).subscribe();
  }

  deletePatient(id: number) {
    if (confirm('¿Estás seguro de que quieres eliminar este paciente?')) {
      this.patientService.deletePatient(id).pipe(
        tap((response) => {
          console.log('Paciente eliminado correctamente:', response);
          this.loadPatients();
        }),
        catchError((error) => {
          console.error('paciente al eliminar el empleado:', error);
          throw error; // Propagar el error para que pueda ser manejado externamente
        })
      ).subscribe();
    }
  }

}
