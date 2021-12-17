import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccueilModule } from './accueil/accueil.module';

const routes: Routes = [
  {
    path:'', loadChildren:() => AccueilModule
  },
  {
    path:'validation', loadChildren:() => import('./validation/validation.module').then((module)=>module.ValidationModule)
  },
  {
    path:'appreciation', loadChildren:() => import('./appreciation/appreciation.module').then((module)=>module.AppreciationModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
