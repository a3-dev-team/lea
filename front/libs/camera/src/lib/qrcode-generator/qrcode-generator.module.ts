import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { QRCodeModule } from 'angularx-qrcode';
import { QrcodeGeneratorComponent } from './components/qrcode-generator.component';




@NgModule({
  declarations: [
    QrcodeGeneratorComponent
  ],
  imports: [
    CommonModule,
    QRCodeModule,
    SharedLibModule
  ],
  exports: [
    QrcodeGeneratorComponent
  ]
})
export class QrcodeGeneratorModule { }
