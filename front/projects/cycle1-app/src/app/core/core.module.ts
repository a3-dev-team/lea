import { NgModule } from '@angular/core';
import { CoreLibModule } from 'projects/core-lib/src/public-api';



@NgModule({
  declarations: [],
  imports: [
    CoreLibModule,
  ],
  exports: [
    CoreLibModule
  ]
})
export class CoreModule { }
