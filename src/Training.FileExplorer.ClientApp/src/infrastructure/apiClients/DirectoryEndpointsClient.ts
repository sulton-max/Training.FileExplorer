import ApiClientBase from "@/infrastructure/api/AxiosClient";
import type { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import { StorageDriveEntryFilterModel } from "@/infrastructure/models/filtering/StorageDirectoryEntryFilterModel";

export class DirectoryEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getRootEntriesAsync(filterModel: StorageDriveEntryFilterModel) {
        const queryString = filterModel.convertToQueryParams();

        return await this.client.getAsync<Array<IStorageEntry>>(`api/directories/root/entries?${queryString}`);
    }

    public async getEntriesAsync(drivePath: string, paginationOptions: FilterPagination) {
        const encodedDrivePath = encodeURIComponent(drivePath);
        const queryString = paginationOptions.convertToQueryParams();

        return await this.client.getAsync<Array<IStorageEntry>>(`api/directories/${encodedDrivePath}/entries?${queryString}`);
    }
}