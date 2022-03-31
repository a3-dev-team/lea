import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AuthenticationModule } from './authentication/authentication.module';
import { ErrorComponent } from './error/components/error/error.component';
import { ErrorInterceptor } from './error/interceptors/error.interceptor';
import { LoaderComponent } from './loader/components/loader/loader.component';
import { LoaderInterceptor } from './loader/interceptors/loader.interceptor';

@NgModule({
  declarations: [
    ErrorComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    AuthenticationModule
  ],
  exports: [
    ErrorComponent,
    LoaderComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  ]

})
export class CoreLibModule { }
