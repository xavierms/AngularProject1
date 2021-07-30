import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { Observable } from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class TrabajadoresService {

  readonly APIurl ="https://localhost:44347"
  busqueda:string = ""

  constructor(private http:HttpClient) { }

  getEmplist(): Observable<any[]>{

    return this.http.get<any>(this.APIurl+'/api/Trabajador');
  }
  addEmp(val:any){

    return this.http.post(this.APIurl+'/api/Trabajador',val);
  }
  updateEmp(val:any){

    return this.http.put(this.APIurl+'/api/Trabajador/'+val.trabajadorid,val);
  }

  deleteEmp(val:any){

    return this.http.delete(this.APIurl+'/api/Trabajador/'+val);
  }

  getbyId(val:any){

    return this.http.get<any>(this.APIurl+'/api/Trabajador/'+val);
  }

  buscartrabajador(){
    return this.http.get<any>(`${this.APIurl}/api/Trabajador`);
  }
}
