import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedLibModule } from '@shared-lib';
import { ObjectifDetailComponent } from './components/objectif-detail/objectif-detail.component';
import { ObjectifListeComponent } from './components/objectif-liste/objectif-liste.component';

@NgModule({
  declarations: [ObjectifDetailComponent, ObjectifListeComponent],
  imports: [SharedLibModule, CommonModule],
  exports: [ObjectifDetailComponent, ObjectifListeComponent],
})
export class ObjectifModule {}
