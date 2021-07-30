import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-barra-buscar',
  templateUrl: './barra-buscar.component.html',
  styleUrls: ['./barra-buscar.component.css']
})
export class BarraBuscarComponent implements OnInit {

  @Output() onEnter:EventEmitter<string> = new EventEmitter();

  parametroBusqueda: string = "";
  @Input() placeholder: string = "";
  
  constructor() { }

  ngOnInit(): void {
  }

  buscar(){
    this.onEnter.emit(this.parametroBusqueda);
  }

}
