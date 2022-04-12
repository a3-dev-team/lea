import { ElementRef } from '@angular/core';
import { SquareDirective } from './square.directive';

describe('SquareDirective', () => {
  let elementRefStub: ElementRef;
  elementRefStub = {
    nativeElement: {
      offsetWidth: "250",
      style: {
        height: ""
      }
    }
  };

  it('should create an instance', () => {
    const directive = new SquareDirective(elementRefStub);
    expect(directive).toBeTruthy();
  });
});
