import { Component, OnInit } from '@angular/core';
import { PersonalService } from '../service/personal.service';
import { Personal } from '../models/Personal'
import { MatDialog } from "@angular/material";
import {MatTableDataSource} from '@angular/material/table';
import { DeleteDialogComponent, FormDialogComponent } from '../personal-dialog/personal-dialog.component';
import { DatePipe } from '@angular/common';
import { PersonalHijoDialogComponent } from '../personal-hijo-dialog/personal-hijo-dialog.component';

@Component({
  selector: 'app-personal',
  templateUrl: './personal.component.html',
  styleUrls: ['./personal.component.css']
})
export class PersonalComponent implements OnInit {

  personal: Personal[] = [];
  dataSource = new MatTableDataSource(this.personal);
  pipe: DatePipe;
  displayedColumns: string[] = ['idPersonal', 'nombreCompleto', 'fchNac', 'fchIngreso', 'action'];

  constructor(public personalService: PersonalService, private dialog: MatDialog) {
    this.pipe = new DatePipe('en');
    const defaultPredicate = this.dataSource.filterPredicate;
    this.dataSource.filterPredicate = (data, filter) => {
      const formatted = this.pipe.transform(data.fchNac, 'dd/MM/yyyy');
      return formatted.indexOf(filter) >= 0 || defaultPredicate(data, filter);
    }
  }

  ngOnInit() {
    this.getPersonal();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getPersonal() {
    this.personalService.getPersonal()
      .subscribe(
        personal => {
          this.personal = personal;
          this.dataSource.data = personal;
        },
        err => console.log(err)
     )
  }

  addPersonal(employee: Personal) {
    this.personalService.addPersonal(employee).subscribe(
      personal => {
        this.getPersonal();
      },
      err => console.log(err)
    )
  }
  
  editPersonal(employee) {
    this.personalService.editPersonal(employee).subscribe(
      personal => {
        this.getPersonal();
      },
      err => console.log(err)
    )
  }

  deletePersonal(id:number) {
    this.personalService.deletePersonal(id).subscribe(
      personal => {
        console.log(this.personal);
        this.getPersonal();
      },
      err => console.log(err)
    )
  }

  openDialogAdd() {
    const dialogRef = this.dialog.open(FormDialogComponent, {
      width: '500px',
      data: {}
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        this.addPersonal(result);
      }
    });
  }

  openDialogUpdate(data: Personal) {
    const dialogRef = this.dialog.open(FormDialogComponent, {
      width: '500px',
      data
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        console.log(result);
        this.editPersonal(result);
      }
    });
  }

  openDialogDelete(id:number) {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '300px',
      data: id
    });

    dialogRef.beforeClose().subscribe(result => {
      if (result != null) {
        this.deletePersonal(result);
      }
    });
  }

  openDialogHijos(id: number) {
    const dialogRef = this.dialog.open(PersonalHijoDialogComponent, {
      width: '800px',
      data: id
    });
    dialogRef.beforeClose();
  }

}
