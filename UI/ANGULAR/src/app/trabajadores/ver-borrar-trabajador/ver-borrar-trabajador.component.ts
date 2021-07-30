import { Component, OnInit } from '@angular/core';
import { TrabajadoresService } from 'src/app/services/trabajadores.service';

@Component({
  selector: 'app-ver-borrar-trabajador',
  templateUrl: './ver-borrar-trabajador.component.html',
  styleUrls: ['./ver-borrar-trabajador.component.css']
})
export class VerBorrarTrabajadorComponent implements OnInit {

  employeeList:any=[];
  ModalTitle:string ='';
  ActivateAddEditEmpComp:Boolean = false;
  emp:any;
  detalleTrabajador: any [] = [];
  verDetalleTrabajador:Boolean = false;
  modalActivo: boolean= false;
  p:number =1;
  parametroBusqueda: string = "";
  lastSearch: string = "";

  constructor(private service:TrabajadoresService) { }
  ngOnInit(): void {
    this.refreshEmpList();

    
  }

  verTrabajador(id: any){
    this.service.getbyId(id)
        .subscribe( trabajador => {
          this.detalleTrabajador.push(trabajador)
        })
    this.verDetalleTrabajador = true;
    this.ModalTitle ="Detalles de Trabajador"
    this.detalleTrabajador=[];
  }

    
  addClick(){
    this.emp={
      trabajadorid: 0,
      trabajadorNum: "",
      trabajadorNomb: "",
      trabajadorTarif: "",
      oficio: "",
      trabajadorSuper:""

    }
    this.ModalTitle ="Añadir Trabajador";
    this.ActivateAddEditEmpComp=true;
  }
 
  eliminarClick(item: any){
   
      this.service.deleteEmp(item.trabajadorid).subscribe(data=>
        console.log(data));
    
    setTimeout(() => {
      this.refreshEmpList();

    }, 300);

  }
  closeClick(){
    this.ActivateAddEditEmpComp=false;
    window.location.reload();
    this.verDetalleTrabajador= false;
  }
  editClick(item:any){
    this.emp= item;
    this.ModalTitle="Editar Trabajador"
    this.ActivateAddEditEmpComp=true;

  }
  refreshEmpList(){
    this.service.getEmplist().subscribe(data=>{
      this.employeeList=data;
      console.log(data);
    })
  }
  buscar(parametroBusqueda: any){
    if(parametroBusqueda === this.lastSearch) return ;
    this.lastSearch = parametroBusqueda
    this.service.busqueda = parametroBusqueda
    this.service.buscartrabajador()
        .subscribe( trabajadores => {
           this.employeeList = trabajadores.filter( (trabajador:any) =>      
           trabajador.trabajadorNomb.toLowerCase().includes(this.service.busqueda.trim().toLowerCase())
          )
        })
  }

}
