import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthenticationInterceptor } from './authentication/interceptors/authentication.interceptor';
import { SignInComponent } from './authentication/pages/sign-in/sign-in.component';
import { CoreLibRoutingModule } from './core-lib-routing.module';
import { ErrorComponent } from './erreur/components/erreur/error.component';
import { ErrorInterceptor } from './erreur/interceptors/error.interceptor';
import { LoaderComponent } from './loader/components/loader/loader.component';
import { LoaderInterceptor } from './loader/interceptors/loader.interceptor';

@NgModule({
  declarations: [
    ErrorComponent,
    SignInComponent,
    LoaderComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    CoreLibRoutingModule
  ],
  exports: [
    ErrorComponent,
    LoaderComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }
  ]

})
export class CoreLibModule { }
