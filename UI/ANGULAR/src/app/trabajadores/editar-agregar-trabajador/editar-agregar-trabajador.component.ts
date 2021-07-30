import { Component, Input, OnInit } from '@angular/core';
import { TrabajadoresService } from 'src/app/services/trabajadores.service';
import { VerBorrarTrabajadorComponent } from '../ver-borrar-trabajador/ver-borrar-trabajador.component';
@Component({
  selector: 'app-editar-agregar-trabajador',
  templateUrl: './editar-agregar-trabajador.component.html',
  styleUrls: ['./editar-agregar-trabajador.component.css']
})
export class EditarAgregarTrabajadorComponent implements OnInit {

  constructor( private service: TrabajadoresService, private modal: VerBorrarTrabajadorComponent ) { }

  @Input() 
  emp:any
  trabajadorid: string=''
  trabajadorNum: string=''
  trabajadorNomb: string=''
  trabajadorTarif: string=''
  oficio: string=''
  trabajadorSuper:string=''
  activarBoton:Boolean = true;

  ngOnInit(): void {
    this.trabajadorid=  this.emp.trabajadorid;
    this.trabajadorNum=  this.emp.trabajadorNum;
    this.trabajadorNomb=  this.emp.trabajadorNomb;
    this.trabajadorTarif=  this.emp.trabajadorTarif;
    this.oficio=  this.emp.oficio;
    this.trabajadorSuper=  this.emp.trabajadorSuper;

  }
  validarInputs(){
    if(this.trabajadorNomb==''){
      this.activarBoton=false;
    }

    else{
      this.activarBoton=true;

    }

  }

  agregarTrabajador(){
    console.log()
    let val = {
      trabajadorNum: this.trabajadorNum.toString(),
        trabajadorNomb: this.trabajadorNomb.toString(),
        trabajadorTarif: this.trabajadorTarif.toString(),
        oficio: this.oficio,
        trabajadorSuper: this.trabajadorSuper.toString()
    }

   this.service.addEmp(val).subscribe(res=>{
  console.log(res.toString());    });
  setTimeout(() => {
    this.modal.refreshEmpList();

  }, 500);




  }

  

  actualizarTrabajador(){

    console.log(this.trabajadorid);   
    let val = {
      trabajadorid: this.trabajadorid.toString(),
      trabajadorNum: this.trabajadorNum.toString(),
      trabajadorNomb: this.trabajadorNomb.toString(),
      trabajadorTarif: this.trabajadorTarif.toString(),
      oficio: this.oficio.toString(),
      trabajadorSuper: this.trabajadorSuper.toString()
  }
   this.service.updateEmp(val).subscribe(res=>{
  console.log(res);    });
  setTimeout(() => {
    this.modal.refreshEmpList();

  }, 500);


  }
}
