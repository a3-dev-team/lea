import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SquareDirective } from './directives/square.directive';


@NgModule({
  declarations: [
    SquareDirective
  ],
  imports: [
    CommonModule,
    // MatIconModule,
    // MatButtonModule,
    // MatToolbarModule,
    // MatGridListModule,
    // MatTableModule,
    // MatCardModule,
  ],
  exports: [
    CommonModule,
    SquareDirective
    // MatIconModule,
    // MatButtonModule,
    // MatToolbarModule,
    // MatGridListModule,
    // MatTableModule,
    // MatCardModule
  ]
})
export class SharedLibModule { }
