import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarAgregarTrabajadorComponent } from './editar-agregar-trabajador.component';

describe('EditarAgregarTrabajadorComponent', () => {
  let component: EditarAgregarTrabajadorComponent;
  let fixture: ComponentFixture<EditarAgregarTrabajadorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarAgregarTrabajadorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarAgregarTrabajadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
