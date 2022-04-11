import { SharedLibModule } from '@a3/shared-lib';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ObjectifDetailComponent } from './components/objectif-detail/objectif-detail.component';
import { ObjectifListeComponent } from './components/objectif-liste/objectif-liste.component';

@NgModule({
  declarations: [ObjectifDetailComponent, ObjectifListeComponent],
  imports: [SharedLibModule, CommonModule],
  exports: [ObjectifDetailComponent, ObjectifListeComponent],
})
export class ObjectifModule { }
