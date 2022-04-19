export class BlobHelper {

    public static convertBase64ToBlob(base64Image: string) {
        // split into two parts
        const parts = base64Image.split(";base64,")
        // hold the content type
        const imageType = parts[0].split(":")[1]
        // decode base64 string
        const decodedData = window.atob(parts[1])
        // create unit8array of size same as row data length
        const uInt8Array = new Uint8Array(decodedData.length)
        // insert all character code into uint8array
        for (let i = 0; i < decodedData.length; ++i) {
            uInt8Array[i] = decodedData.charCodeAt(i)
        }
        // return blob image after conversion
        return new Blob([uInt8Array], { type: imageType })
    }

}