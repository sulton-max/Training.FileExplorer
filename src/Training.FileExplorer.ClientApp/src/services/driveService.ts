import ApiClientBase from "@/infrastructure/api/AxiosClient";
import type { DriveInfo } from "@/models/entities/DriveInfo";

export class DriveService extends ApiClientBase {

    constructor() {
        super({
            baseURL: "https://localhost:7195/api/"
        });
    }

    public async getDrivesAsync() {
        return await this.getAsync<Array<DriveInfo>>("drives");
    }
}