import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import ApiClientBase from "@/infrastructure/api/AxiosClient";
import type { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import type { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";
import { StorageDriveEntryFilterModel } from "@/infrastructure/models/filtering/StorageDirectoryEntryFilterModel";

export class DirectoryEndpointClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getRootEntriesAsync(filterModel: StorageDriveEntryFilterModel) {
        const queryString = filterModel.convertToQueryParams();

        return await this.client.getAsync<Array<IStorageEntry>>(`directories?${queryString}`);
    }

    public async getEntriesAsync(drivePath: string, paginationOptions: FilterPagination) {
        const encodedDrivePath = encodeURIComponent(drivePath);
        const queryString = paginationOptions.convertToQueryParams();

        console.log(queryString.toString());
        return await this.client.getAsync<Array<IStorageEntry>>(`drives/${encodedDrivePath}/entries?${queryString}`);
    }
}