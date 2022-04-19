import { BlobHelper } from '@a3/shared-lib';
import { Component, Input, OnInit } from '@angular/core';
import { QRCodeComponent } from 'angularx-qrcode';

@Component({
  selector: 'a3-qrcode-generator',
  templateUrl: './qrcode-generator.component.html',
  styleUrls: ['./qrcode-generator.component.css']
})
export class QrcodeGeneratorComponent implements OnInit {

  @Input() stringToQrcode!: string;
  @Input() qrcodeFileName!: string;

  constructor() { }

  ngOnInit(): void {
  }

  public onGenererQrcodeClick(qrcodeComponent: QRCodeComponent): void {
    this.telechargerQrcode(qrcodeComponent);
  }

  private telechargerQrcode(qrcodeComponent: QRCodeComponent) {
    // fetches base 64 data from image
    // qrcodeElement contains the base64 encoded image src
    // you might use to store somewhere
    let qrcodeElement = qrcodeComponent.qrcElement.nativeElement
      .querySelector("canvas")
      .toDataURL("image/png")

    // converts base 64 encoded image to blobData
    let blobData = BlobHelper.convertBase64ToBlob(qrcodeElement)
    // saves as image
    const blob = new Blob([blobData], { type: "image/png" })
    const url = window.URL.createObjectURL(blob)
    const link = document.createElement("a")
    link.href = url
    // name of the file
    link.download = this.qrcodeFileName;
    link.click()
  }

}
