import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { FormBuilder, Validators, FormGroup } from "@angular/forms";

@Component({
  selector: 'app-personal-form-dialog',
  templateUrl: './form-dialog.component.html',
  styleUrls: ['./form-dialog.component.css']
})
export class FormDialogComponent implements OnInit {

  form: FormGroup;
  private IdUpdateEmployee: number;
  formTitle: string;
  minDate = new Date();
  maxDate = new Date();

  constructor(
    private dialogRef: MatDialogRef<FormDialogComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data?
  ) {
    this.IdUpdateEmployee = (data != null) ? data.idPersonal : null;
    this.form = this.fb.group({
      ApPaterno: [data.apPaterno || '', Validators.compose([Validators.required, Validators.pattern("^[^0-9]+$")])],
      ApMaterno: [data.apMaterno || '', Validators.compose([Validators.required, Validators.pattern("^[^0-9]+$")])],
      Nombre1: [data.nombre1 || '', Validators.compose([Validators.required, Validators.pattern("^[^0-9]+$")])],
      Nombre2: [data.nombre2 || '', Validators.pattern("^[^0-9]+$")],
      FchNac: [data.fchNac || '', Validators.required]
    })
    if (this.IdUpdateEmployee) {
      this.formTitle = "Actualizar empleado"
    }
    else {
      this.formTitle = "Agregar empleado"
    }
    this.minDate.setFullYear(new Date().getFullYear() - 60);
    this.maxDate.setFullYear(new Date().getFullYear() - 18);
  }

  ngOnInit(): void {

  }

  onSubmit() {
    console.log(this.IdUpdateEmployee);
    if (this.IdUpdateEmployee) {
      this.form.value.idPersonal = this.IdUpdateEmployee;
    }
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'app-personal-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent {

  IdPersonal: number;

  constructor(
    private dialogRef: MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data
  ) {
    this.IdPersonal = data;
  }

  ngOnInit(): void {

  }

  onDelete() {
    this.dialogRef.close(this.IdPersonal);
  }

  close() {
    this.dialogRef.close();
  }

}
