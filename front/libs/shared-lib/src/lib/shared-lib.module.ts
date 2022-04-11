import { NgModule } from '@angular/core';
import { QrcodeModule } from './qrcode/qrcode.module';


@NgModule({
  declarations: [],
  imports: [
    QrcodeModule
    // MatIconModule,
    // MatButtonModule,
    // MatToolbarModule,
    // MatGridListModule,
    // MatTableModule,
    // MatCardModule,
  ],
  exports: [
    QrcodeModule
    // MatIconModule,
    // MatButtonModule,
    // MatToolbarModule,
    // MatGridListModule,
    // MatTableModule,
    // MatCardModule
  ]
})
export class SharedLibModule { }
