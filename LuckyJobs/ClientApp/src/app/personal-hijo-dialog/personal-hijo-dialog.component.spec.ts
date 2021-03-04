import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalHijoDialogComponent } from './personal-hijo-dialog.component';

describe('PersonalHijoDialogComponent', () => {
  let component: PersonalHijoDialogComponent;
  let fixture: ComponentFixture<PersonalHijoDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonalHijoDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalHijoDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
