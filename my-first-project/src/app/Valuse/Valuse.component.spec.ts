/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ValuseComponent } from './Valuse.component';

describe('ValuseComponent', () => {
  let component: ValuseComponent;
  let fixture: ComponentFixture<ValuseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ValuseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ValuseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
