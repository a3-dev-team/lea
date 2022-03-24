import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';


@NgModule({
  declarations: [
  ],
  imports: [
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatGridListModule,
    MatTableModule,
    MatCardModule
  ],
  exports: [
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatGridListModule,
    MatTableModule,
    MatCardModule
  ]
})
export class SharedLibModule { }
