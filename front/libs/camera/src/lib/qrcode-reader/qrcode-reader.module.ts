
import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ZXingScannerModule } from '@zxing/ngx-scanner';
import { ModalModule } from 'libs/common/src/lib/modal/modal.module';
import { QrcodeReaderComponent } from './components/qrcode-reader.component';




@NgModule({
  declarations: [
    QrcodeReaderComponent
  ],
  imports: [
    CommonModule,
    ZXingScannerModule,
    SharedLibModule,
    ModalModule
  ],
  exports: [
    QrcodeReaderComponent
  ]
})
export class QrcodeReaderModule { }
