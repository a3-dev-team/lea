import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { QrcodeReaderComponent } from './components/qrcode-reader/qrcode-reader.component';


@NgModule({
  declarations: [
    QrcodeReaderComponent
  ],
  imports: [
    CommonModule,
    ZXingScannerModule
  ],
  exports: [
    QrcodeReaderComponent
  ]
})
export class QrcodeModule { }
