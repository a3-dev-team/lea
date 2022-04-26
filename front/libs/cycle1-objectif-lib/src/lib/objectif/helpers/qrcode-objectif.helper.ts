import { Objectif } from '../models/objectif.model';

export class QrcodeObjectifHelper {

    private static qrcodePrefix: string = 'LEA-CYCLE1-OBJECTIF-'

    public static obtenirQrcodeObjectif(objectif: Objectif): string {
        return this.qrcodePrefix + objectif.id;
    }

    public static obtenirObjectifIdDepuisQrcode(qrcode: string): number | null {
        let objectifId: number | null = null;

        if (qrcode.startsWith(this.qrcodePrefix)) {
            const prefixLength = this.qrcodePrefix.length;
            objectifId = +qrcode.substring(prefixLength);
        }

        return objectifId;
    }
}