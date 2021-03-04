import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PersonalComponent } from './personal/personal.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from "@angular/material";
import { MatDatepickerModule, } from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormDialogComponent, DeleteDialogComponent } from './personal-dialog/personal-dialog.component';
import { DeleteHijoDialogComponent, FormHijoDialogComponent, PersonalHijoDialogComponent } from './personal-hijo-dialog/personal-hijo-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    PersonalComponent,
    FormDialogComponent,
    DeleteDialogComponent,
    PersonalHijoDialogComponent,
    FormHijoDialogComponent,
    DeleteHijoDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    FormsModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    RouterModule.forRoot([
      { path: 'personal', component: PersonalComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' }],
  bootstrap: [AppComponent],
  entryComponents: [FormDialogComponent, DeleteDialogComponent, PersonalHijoDialogComponent, FormHijoDialogComponent, DeleteHijoDialogComponent]
})
export class AppModule { }
