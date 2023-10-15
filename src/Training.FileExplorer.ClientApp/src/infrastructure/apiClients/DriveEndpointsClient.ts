import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import ApiClientBase from "@/infrastructure/api/AxiosClient";

export class DriveEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getDrivesAsync() {
        return await this.client.getAsync<Array<StorageDrive>>("drives");
    }

    public async getDriveEntriesAsync(driveLabel: string) {
        return await this.client.getAsync<Array<StorageDrive>>(`drives/${driveLabel}/entries`);
    }
}