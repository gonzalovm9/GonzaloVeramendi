import { DatePipe } from '@angular/common';
import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog } from "@angular/material/dialog";
import { MatTableDataSource } from '@angular/material/table';
import { Hijo } from '../models/Hijo'
import { HijoService } from '../service/hijos.service';

@Component({
  selector: 'app-personal-hijo-dialog',
  templateUrl: './personal-hijo-dialog.component.html',
  styleUrls: ['./personal-hijo-dialog.component.css']
})
export class PersonalHijoDialogComponent implements OnInit {

  hijos: Hijo[] = [];
  dataSourceHijo = new MatTableDataSource(this.hijos);
  pipe: DatePipe;
  displayedColumns: string[] = ['idDerHab', 'nombreCompleto', 'fchNac', 'action'];
  IdPersonal: number;

  constructor(
    public hijoService: HijoService, private dialog: MatDialog,
    private dialogRef: MatDialogRef<PersonalHijoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data
  ) {
    this.pipe = new DatePipe('en');
    const defaultPredicate = this.dataSourceHijo.filterPredicate;
    this.dataSourceHijo.filterPredicate = (data, filter) => {
      const formatted = this.pipe.transform(data.fchNac, 'dd/MM/yyyy');
      return formatted.indexOf(filter) >= 0 || defaultPredicate(data, filter);
    }
    this.IdPersonal = data;
  }

  ngOnInit() {
    this.getHijos();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSourceHijo.filter = filterValue.trim().toLowerCase();
  }

  getHijos() {
    this.hijoService.getHijosByPersonal(this.IdPersonal)
      .subscribe(
        hijos => {
          
          this.hijos = hijos;
          this.dataSourceHijo.data = hijos;
          console.log(this.dataSourceHijo);
        },
        err => console.log(err)
      )
  }

  addHijo(hijo: Hijo) {
    this.hijoService.addHijo(hijo).subscribe(
      personal => {
        this.getHijos();
      },
      err => console.log(err)
    )
  }

  editHijo(hijo:Hijo) {
    this.hijoService.editHijo(hijo).subscribe(
      personal => {
        this.getHijos();
      },
      err => console.log(err)
    )
  }

  deleteHijo(id: number) {
    this.hijoService.deleteHijo(id).subscribe(
      personal => {
        this.getHijos();
      },
      err => console.log(err)
    )
  }

  openDialogAdd() {
    const dialogRef = this.dialog.open(FormHijoDialogComponent, {
      width: '500px',
      data: {}
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        result.padre = {idPersonal: this.IdPersonal};
        this.addHijo(result);
      }
    });
  }

  openDialogUpdate(data: Hijo) {
    const dialogRef = this.dialog.open(FormHijoDialogComponent, {
      width: '500px',
      data
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        this.editHijo(result);
      }
    });
  }

  openDialogDelete(id: number) {
    const dialogRef = this.dialog.open(DeleteHijoDialogComponent, {
      width: '300px',
      data: id
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        this.deleteHijo(result);
      }
    });
  }

  close() {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'app-personal-hijo-dialog',
  templateUrl: './form-hijo-dialog.component.html',
  styleUrls: ['./form-hijo-dialog.component.css']
})
export class FormHijoDialogComponent implements OnInit {

  form: FormGroup;
  private IdUpdateHijo: number;
  formTitle: string;

  constructor(
    private dialogRef: MatDialogRef<FormHijoDialogComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data?
  ) {
    this.IdUpdateHijo = (data != null) ? data.idDerHab : null;
    this.form = this.fb.group({
      ApPaterno: [data.apPaterno || '', Validators.required],
      ApMaterno: [data.apMaterno || '', Validators.required],
      Nombre1: [data.nombre1 || '', Validators.required],
      Nombre2: data.nombre2 || '',
      FchNac: [data.fchNac || '', Validators.required]
    })
    if (this.IdUpdateHijo) {
      this.formTitle = "Actualizar datos de hijo"
    }
    else {
      this.formTitle = "Agregar hijo"
    }
  }

  ngOnInit(): void {

  }

  onSubmit() {
    if (this.IdUpdateHijo) {
      this.form.value.idDerHab = this.IdUpdateHijo;
    }
    this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }

}


@Component({
  selector: 'app-personal-hijo-dialog',
  templateUrl: './delete-hijo-dialog.component.html',
  styleUrls: ['./delete-hijo-dialog.component.css']
})
export class DeleteHijoDialogComponent implements OnInit {

  IdPersonal: number;

  constructor(
    private dialogRef: MatDialogRef<DeleteHijoDialogComponent>,
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
