import { AuthenticationModule, ErrorModule, LoaderModule } from '@a3/common';
import { NgModule } from '@angular/core';



@NgModule({
  declarations: [],
  imports: [
    AuthenticationModule,
    ErrorModule,
    LoaderModule
  ],
  exports: [
    AuthenticationModule,
    ErrorModule,
    LoaderModule
  ]
})
export class CoreModule { }
