import { QrcodeGeneratorModule, QrcodeReaderModule } from '@a3/camera';
import { CycleClasseLibModule } from '@a3/cycle-classe-lib';
import { NgModule } from '@angular/core';
import { WebcamModule } from 'ngx-webcam';
import { SharedModule } from '../shared/shared.module';
import { SelectionEleveComponent } from './pages/selection-eleve/selection-eleve.component';
import { SelectionObjectifComponent } from './pages/selection-objectif/selection-objectif.component';
import { ValidationObjectifComponent } from './pages/validation-objectif/validation-objectif.component';
import { ValidationRoutingModule } from './validation-routing.module';
import { ValidationComponent } from './validation.component';

@NgModule({
  declarations: [
    ValidationComponent,
    ValidationObjectifComponent,
    SelectionEleveComponent,
    SelectionObjectifComponent,
    SelectionObjectifComponent,
    ValidationObjectifComponent,
  ],
  imports: [
    SharedModule,
    ValidationRoutingModule,
    CycleClasseLibModule,
    QrcodeReaderModule,
    QrcodeGeneratorModule,
    WebcamModule,
  ]
})
export class ValidationModule { }
