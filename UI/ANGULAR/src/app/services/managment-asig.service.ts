import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManagmentAsigService {
  
  readonly BaseApiUrl = "https://localhost:44347/api"
  constructor(private http: HttpClient) { }

  obtenerAsignaciones(): Observable<any[]>{
    return this.http.get<any>(`${this.BaseApiUrl}/Asignaciones`);
  }

  añadirAsignaciones(Asignacion: any){
    return this.http.post(`${this.BaseApiUrl}/Asignaciones`, Asignacion)
  }

  actualizarAsignaciones(Asignaciones: any){
    
    console.log(Asignaciones)
    console.log(Asignaciones.Asignacionid)
    return this.http.put(`${this.BaseApiUrl}/Asignaciones/${Asignaciones.asignacionid}`, Asignaciones)
  }

  eliminarAsignaciones(id: any){
    return this.http.delete(`${this.BaseApiUrl}/Asignaciones/${id}`);
  }

  verAsignacion(id: any){
      return this.http.get(`${this.BaseApiUrl}/Asignaciones/${id}`)
  }
  buscarAsignacion(){
    return this.http.get<any>(`${this.BaseApiUrl}/Asignaciones`);
  }
}
