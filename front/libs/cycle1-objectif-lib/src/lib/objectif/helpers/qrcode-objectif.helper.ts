import { Objectif } from '../models/objectif.model';

export class QrcodeObjectifHelper {

    private static qrcodePrefix: string = 'LEA-CYCLE1-OBJECTIF-'

    public static obtenirQrcode(objectif: Objectif): string {
        return this.qrcodePrefix + objectif.id;
    }

    public static obtenirIdentifiant(qrcode: string): number {
        const prefixLength = this.qrcodePrefix.length;
        return +qrcode.substring(prefixLength);
    }
}