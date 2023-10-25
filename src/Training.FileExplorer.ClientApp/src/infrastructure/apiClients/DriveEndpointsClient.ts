import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import ApiClientBase from "@/infrastructure/api/AxiosClient";
import type { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";

export class DriveEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getDrivesAsync() {
        return await this.client.getAsync<Array<StorageDrive>>("api/drives");
    }

    public async getDriveEntriesAsync(drivePath: string, paginationOptions: FilterPagination) {
        const encodedDrivePath = encodeURIComponent(drivePath);
        const queryString = paginationOptions.convertToQueryParams();

        return await this.client.getAsync<Array<StorageDrive>>(`api/drives/${encodedDrivePath}/entries?${queryString}`);
    }
}