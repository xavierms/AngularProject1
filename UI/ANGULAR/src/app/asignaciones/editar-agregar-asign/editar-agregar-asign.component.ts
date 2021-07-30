import { Component, Input, OnInit } from '@angular/core';
import { ManagmentAsigService } from '../../services/managment-asig.service';
import { VerBorrarAsignComponent } from '../ver-borrar-asign/ver-borrar-asign.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editar-agregar-asign',
  templateUrl: './editar-agregar-asign.component.html',
  styleUrls: ['./editar-agregar-asign.component.css']
})
export class EditarAgregarAsignComponent implements OnInit {

  @Input() asignacion: any;
  Asignacionid    : number = 0 ;
  AsigNum         : string = "" ;
  AsigFechIni     : string = "";
  AsigNumDias     : string = "";
  EdificioNum_fk  : number = 0;
  TrabajadorNum_fk: number = 0;
 
  // feedbackAlert: boolean = false;
 
   constructor(private managmentService: ManagmentAsigService, 
               private refresh : VerBorrarAsignComponent,
               private toastr:ToastrService) { }
 
   ngOnInit(): void {
     this.Asignacionid     = this.asignacion.asignacionid;
     this.AsigNum          = this.asignacion.asigNum;
     this.AsigFechIni      = this.asignacion.asigFechIni;
     this.AsigNumDias      = this.asignacion.asigNumDias;
     this.EdificioNum_fk   = this.asignacion.edificioNum_fk;
     this.TrabajadorNum_fk = this.asignacion.trabajadorNum_fk;
   }
 
   agregarAsignaciones(){
     var asignaciones = {
      Asignacionid     : this.Asignacionid,
      AsigNum          : this.AsigNum.toString(),
      AsigFechIni      : this.AsigFechIni.toString(),
      AsigNumDias      : this.AsigNumDias.toString(),
      EdificioNum_fk   : this.EdificioNum_fk.toString(),
      TrabajadorNum_fk : this.TrabajadorNum_fk.toString()
     }
     
     //console.log(asignaciones);
     this.managmentService.añadirAsignaciones(asignaciones)
                          .subscribe( res => {
           console.log(res)
         })
         setTimeout(() => {
           this.refresh.asignarDatosAsignaciones();
         }, 500);
         
       this.toastr.success("La asiganción se agregó correctamente", "Asganción agregada!");
   }
 
   actualizarAsignaciones(){
    var asignaciones = {
      asignacionid     : this.Asignacionid.toString(),
      AsigNum          : this.AsigNum.toString(),
      AsigFechIni      : this.AsigFechIni.toString(),
      AsigNumDias      : this.AsigNumDias.toString(),
      EdificioNum_fk   : this.EdificioNum_fk.toString(),
      TrabajadorNum_fk : this.TrabajadorNum_fk.toString()
    }

    this.managmentService.actualizarAsignaciones(asignaciones)
        .subscribe( res => {
          console.log(res)
        })

        setTimeout(() => {
          this.refresh.asignarDatosAsignaciones();
        }, 500);
        this.toastr.success("La asiganción se editó correctamente", "Asganción edita!");
   }

 }


