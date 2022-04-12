import { AfterViewInit, Directive, ElementRef } from '@angular/core';
import { fromEvent } from 'rxjs';

@Directive({
  selector: '[square]'
})
export class SquareDirective implements AfterViewInit {

  constructor(private readonly elementRef: ElementRef) {
    fromEvent(window, 'resize')
      .subscribe(() => {
        this.setHeightEqualWidth();
      })
  }

  ngAfterViewInit(): void {
    this.setHeightEqualWidth();
  }

  private setHeightEqualWidth() {
    this.elementRef.nativeElement.style.height = this.elementRef.nativeElement.offsetWidth + 'px';
  }

}
