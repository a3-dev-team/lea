
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApplicationStore } from './../core/application-store/application-store';

@Component({
  selector: 'app-validation',
  templateUrl: './validation.component.html',
  styleUrls: ['./validation.component.scss']
})
export class ValidationComponent implements OnInit, OnDestroy {

  constructor(private readonly applicationStore: ApplicationStore) {
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
  }

}
