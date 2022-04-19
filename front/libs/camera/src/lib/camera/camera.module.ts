import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CameraComponent } from './components/camera.component';




@NgModule({
  declarations: [
    CameraComponent,
  ],
  imports: [
    CommonModule,
    SharedLibModule
  ],
  exports: [
    CameraComponent,
  ]
})
export class CameraModule { }
