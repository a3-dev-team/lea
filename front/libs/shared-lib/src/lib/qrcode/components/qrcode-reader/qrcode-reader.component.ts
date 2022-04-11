import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'a3-qrcode-reader',
  templateUrl: './qrcode-reader.component.html',
  styleUrls: ['./qrcode-reader.component.css']
})
export class QrcodeReaderComponent {

  @Output() stringScanned: EventEmitter<string> = new EventEmitter<string>()

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
    this.resultScan = stringScanned;
  }

  private changeCurrentCamera() {
    if (this.cameraList && this.currentCamera) {
      let currentCameraIndex = this.cameraList.findIndex(c => c === this.currentCamera);
      let nextCurrentCameraIndex = currentCameraIndex + 1;
      if (nextCurrentCameraIndex > this.cameraList.length - 1) {
        nextCurrentCameraIndex = 0;
      }
      this.currentCamera = this.cameraList[nextCurrentCameraIndex];
    }
  }
}
