import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ANGULAR';
  @Output() onEnter:EventEmitter<string> = new EventEmitter();

  parametroBusqueda: string = "";
  @Input() placeholder: string = "";

  buscar(){
    this.onEnter.emit(this.parametroBusqueda);
  }
}
