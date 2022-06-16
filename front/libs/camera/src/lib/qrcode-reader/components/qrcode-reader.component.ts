import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { ModalComponent } from 'libs/common/src/lib/modal/components/modal/modal.component';
import { BehaviorSubject, first } from 'rxjs';

@Component({
  selector: 'a3-qrcode-reader',
  templateUrl: './qrcode-reader.component.html',
  styleUrls: ['./qrcode-reader.component.scss']
})
export class QrcodeReaderComponent {

  @Input() public buttonRightRem: Number = 2;
  @Input() public buttonBottomRem: Number = 3;
  @Input() public enable: boolean = true;
  @Output() stringScanned: EventEmitter<string> = new EventEmitter<string>()

  @ViewChild('qrcodeReaderModal') qrcodeReaderModal!: ModalComponent;

  private isVisibleSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isVisibleState$ = this.isVisibleSubject.asObservable();



  constructor() { }

  public cameraList: MediaDeviceInfo[] | undefined;
  public currentCamera: MediaDeviceInfo | undefined;
  public resultScan: string | null = null;

  public onChangeCameraClick() {
    this.changeCurrentCamera();
  }

  public onCamerasFound(cameraList: MediaDeviceInfo[] | undefined) {
    this.cameraList = cameraList;
  }

  public onScanSuccess(stringScanned: string): void {
    this.stringScanned.next(stringScanned);
    console.log("qrcode scanned : " + stringScanned)
  }

  private changeCurrentCamera() {
    if (this.cameraList) {
      let currentCameraIndex = this.cameraList.findIndex(c => c === this.currentCamera);
      let nextCurrentCameraIndex = currentCameraIndex + 1;
      if (nextCurrentCameraIndex > this.cameraList.length - 1) {
        nextCurrentCameraIndex = 0;
      }
      this.currentCamera = this.cameraList[nextCurrentCameraIndex];
    }
  }

  public onQrcodeButtonClick() {
    // this.updateIsVisible();
    this.qrcodeReaderModal.show();
  }

  private updateIsVisible(): void {
    this.isVisibleState$
      .pipe(
        first()
      )
      .subscribe((isVisible: Boolean) => {
        this.isVisibleSubject.next(!isVisible)
      });
  }


  public onCloseQrcodeReaderModalButtonClick() {
    this.qrcodeReaderModal.hide();
  }
}
