import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { ManagmentService } from 'src/app/services/managment.service';

@Component({
  selector: 'app-ver-borrar',
  templateUrl: './ver-borrar.component.html',
  styleUrls: ['./ver-borrar.component.css']
})
export class VerBorrarComponent implements OnInit {

  edificios: any = [];
  edificio: any;
  tituloModal: string = "";
  modalActivo: boolean= false;
  verDetalleEdificio: boolean = true;
  detalleEdificio: any = [];
  parametroBusqueda: string = "";
  lastSearch: string = "";
  p:number =1;

  constructor(public managementService: ManagmentService) { }

  ngOnInit(): void {
    this.asignarDatosEdificios();
  }

  asignarDatosEdificios(){
      this.managementService.obtenerEdificios()
          .subscribe(edificios => this.edificios = edificios)
  }

  verEdificio(id: any){
    this.managementService.verEdificio(id)
        .subscribe( edificio => {
          this.detalleEdificio.push(edificio)
        })
    this.verDetalleEdificio = true;
    this.detalleEdificio=[];
    this.tituloModal ="Detalles de Edificio"
  }

  abrirModalAgregar(){
    this.edificio = {
      edificiosId : 0,
      edificioNum : "",
      edificioDireccion : "",
      tipoEdif: "",
      nivelCal: 0,
      categor: 0
    }
    this.tituloModal = "Agregar Edificio";
    this.modalActivo= true;
  }

  cerrarModalAgregar(){
    this.modalActivo = false;
    this.verDetalleEdificio = false;
    if(!this.lastSearch){
      this.asignarDatosEdificios();
    }
  }

  abrirModalEditar(edificio: any){
    this.edificio= edificio;
    this.tituloModal = "Editar Edificio"
    this.modalActivo = true;
  }

  eliminarEdificio(id: any){
      if(confirm("Seguro que quiere eliminar este registro?")){
        this.managementService.eliminarEdificio(id)
            .subscribe( res => console.log("Edificio elmininado"))
        setTimeout(() => {
          this.asignarDatosEdificios();
        }, 500); 
      }
  }



  buscar(parametroBusqueda: any){
    if(parametroBusqueda === this.lastSearch) return ;
    this.lastSearch = parametroBusqueda
    this.managementService.busqueda = parametroBusqueda
    this.managementService.buscarEdificio()
        .subscribe( edificios => {
           this.edificios = edificios.filter( (edificio:any) =>      
           edificio.edificioDireccion.toLowerCase().includes(this.managementService.busqueda.trim().toLowerCase())
          )
        })
  }

}