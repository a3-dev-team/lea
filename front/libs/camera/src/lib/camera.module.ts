import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { CameraComponent } from './components/camera/camera.component';
import { QrcodeGeneratorComponent } from './components/qrcode-generator/qrcode-generator.component';
import { QrcodeReaderComponent } from './components/qrcode-reader/qrcode-reader.component';




@NgModule({
  declarations: [
    CameraComponent,
    QrcodeReaderComponent,
    QrcodeGeneratorComponent
  ],
  imports: [
    CommonModule,
    ZXingScannerModule,
    SharedLibModule
  ],
  exports: [
    CameraComponent,
    QrcodeReaderComponent,
    QrcodeGeneratorComponent
  ]
})
export class CameraModule { }
