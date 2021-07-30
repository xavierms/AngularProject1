import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ManagmentService } from 'src/app/services/managment.service';
import { VerBorrarComponent } from '../ver-borrar/ver-borrar.component';

@Component({
  selector: 'app-editar-agregar',
  templateUrl: './editar-agregar.component.html',
  styleUrls: ['./editar-agregar.component.css']
})
export class EditarAgregarComponent implements OnInit {


 @Output() evntoLista= new EventEmitter<string>();
 @Output() eventoBuscar= new EventEmitter<string>();


 @Input() edificio: any;
 edificiosId: number = 0 ;
 edificioNum: string= "" ;
 edificioDireccion: string = "";
 tipoEdif: string = "";
 nivelCal: string = "";
 categor: string = "";



  constructor(private managmentService: ManagmentService, private parent: VerBorrarComponent) { }

  ngOnInit(): void {
    this.edificiosId = this.edificio.edificiosId;
    this.edificioNum = this.edificio.edificioNum;
    this.edificioDireccion = this.edificio.edificioDireccion;
    this.tipoEdif = this.edificio.tipoEdif;
    this.nivelCal = this.edificio.nivelCal;
    this.categor = this.edificio.categor;
  }

  agregarEdificio(){
    var edificio = {
      edificiosId : this.edificiosId.toString(),
      edificioNum : this.edificioNum.toString(),
      edificioDireccion : this.edificioDireccion.toString(),
      tipoEdif : this.tipoEdif.toString(),
      nivelCal : this.nivelCal.toString(),
      categor : this.categor.toString()
    }

    this.managmentService.añadirEdificio(edificio)
        .subscribe( res => {
          console.log(res)
          this.evntoLista.emit();
          this.eventoBuscar.emit();

        })
    this.resetForm();
  }

  actualizarEdificio(){
    var edificio = {
      edificiosId : this.edificiosId.toString(),
      edificioNum : this.edificioNum.toString(),
      edificioDireccion : this.edificioDireccion.toString(),
      tipoEdif : this.tipoEdif.toString(),
      nivelCal : this.nivelCal.toString(),
      categor : this.categor.toString()
    }


    this.managmentService.actualizarEdificio(edificio)
        .subscribe( res => {
          console.log(res)
          this.evntoLista.emit();
          this.eventoBuscar.emit();

        })
  }

  resetForm(){
    this.edificiosId = 0;
    this.edificioNum = "";
    this.edificioDireccion = "";
    this.tipoEdif = "";
    this.nivelCal = "";
    this.categor = "";
  }

}
