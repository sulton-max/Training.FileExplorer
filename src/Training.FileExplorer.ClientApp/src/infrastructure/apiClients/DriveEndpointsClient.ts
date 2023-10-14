import type { DriveInfo } from "@/infrastructure/models/entities/DriveInfo";
import ApiClientBase from "@/infrastructure/api/AxiosClient";

export class DriveEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getDrivesAsync() {
        return await this.client.getAsync<Array<DriveInfo>>("drives");
    }

    public async getDriveEntriesAsync(driveName: string) {
        return await this.client.getAsync<Array<DriveInfo>>(`drives/${driveName}`);
    }
}