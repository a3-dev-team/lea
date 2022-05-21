import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AuthenticationModule } from '../authentication/authentication.module';
import { ErrorComponent } from './components/error/error.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';



@NgModule({
  declarations: [
    ErrorComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthenticationModule
  ],
  exports: [
    ErrorComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ]
})
export class ErrorModule { }
