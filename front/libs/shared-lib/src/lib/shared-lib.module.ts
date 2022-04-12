import { NgModule } from '@angular/core';
import { SquareDirective } from './directives/square.directive';


@NgModule({
  declarations: [
    SquareDirective
  ],
  imports: [
    // MatIconModule,
    // MatButtonModule,
    // MatToolbarModule,
    // MatGridListModule,
    // MatTableModule,
    // MatCardModule,
  ],
  exports: [
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
