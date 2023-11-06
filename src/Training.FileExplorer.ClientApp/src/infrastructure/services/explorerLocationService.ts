import { useExplorerStore } from "@/common/stores/ExplorerStore";

export class ExplorerLocationService {

    public getFileUrl(baseUrl: string, fileUrl: string) {
        return `${baseUrl}/${fileUrl}`;
    }

    public getFileSizeString (fileSizeInBytes: number) {
        const byteConversion = 1024;
        let bytes = fileSizeInBytes;

        if (bytes >= Math.pow(byteConversion, 4)) { // Terabytes
            return `${(bytes / Math.pow(byteConversion, 4)).toFixed(2)} TB`;
        } else if (bytes >= Math.pow(byteConversion, 3)) { // Gigabytes
            return `${(bytes / Math.pow(byteConversion, 3)).toFixed(2)} GB`;
        } else if (bytes >= Math.pow(byteConversion, 2)) { // Megabytes
            return `${(bytes / Math.pow(byteConversion, 2)).toFixed(2)} MB`;
        } else if (bytes >= byteConversion) { // Kilobytes
            return `${(bytes / byteConversion).toFixed(2)} KB`;
        } else { // Bytes
            return `${bytes.toFixed(2)} Bytes`;
        }
    }

}