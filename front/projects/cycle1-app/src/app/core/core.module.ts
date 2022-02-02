import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CoreLibModule } from 'projects/core-lib/src/public-api';



@NgModule({
  declarations: [],
  imports: [
    CoreLibModule,
    CommonModule,
    HttpClientModule
  ],
  exports: [
    CoreLibModule
  ]
})
export class CoreModule { }
