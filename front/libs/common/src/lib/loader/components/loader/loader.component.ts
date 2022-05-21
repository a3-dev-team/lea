import { Component, OnInit } from '@angular/core';
import { LoaderManager } from '../../services/loader-manager.service';

@Component({
  selector: 'a3-loader',
  templateUrl: './loader.component.html'
})
export class LoaderComponent implements OnInit {

  constructor(public readonly loaderManager: LoaderManager) { }

  ngOnInit(): void {
  }

}
