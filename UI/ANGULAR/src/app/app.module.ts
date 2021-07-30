import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
//imports edificios
import { AppComponent } from './app.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { EdificiosComponent } from './edificios/edificios.component';
import { ManagmentService } from './services/managment.service';
import { VerBorrarComponent } from './edificios/ver-borrar/ver-borrar.component';
import { EditarAgregarComponent } from './edificios/editar-agregar/editar-agregar.component';

//imports asignaciones
import { ManagmentAsigService } from './services/managment-asig.service';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';




import { EditarAgregarAsignComponent } from './asignaciones/editar-agregar-asign/editar-agregar-asign.component';
import { VerBorrarAsignComponent } from './asignaciones/ver-borrar-asign/ver-borrar-asign.component';



import { TrabajadoresService } from './services/trabajadores.service';
import { EditarAgregarTrabajadorComponent } from './trabajadores/editar-agregar-trabajador/editar-agregar-trabajador.component';
import { VerBorrarTrabajadorComponent } from './trabajadores/ver-borrar-trabajador/ver-borrar-trabajador.component';
import { BarraBuscarComponent } from './barra-buscar/barra-buscar.component';
import {NgxPaginationModule} from 'ngx-pagination'; // <-- import the module


@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
    AsignacionesComponent,
    EditarAgregarTrabajadorComponent,
    VerBorrarTrabajadorComponent, 
    BarraBuscarComponent,
    EditarAgregarAsignComponent,
    VerBorrarAsignComponent

  ],
  exports:[
BarraBuscarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
    NgxPaginationModule
  ],
  providers: [
    ManagmentService,
    ManagmentAsigService,
    TrabajadoresService
  ],
    
  bootstrap: [AppComponent]
})
export class AppModule { }
