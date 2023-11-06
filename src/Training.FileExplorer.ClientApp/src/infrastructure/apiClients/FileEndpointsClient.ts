import type ApiClientBase from "@/infrastructure/api/AxiosClient";
import { StorageFileFilterDataModel } from "@/infrastructure/models/filtering/StorageFileFilterDataModel";
import type { StorageFile } from "@/infrastructure/models/entities/StorageFile";
import type { StorageFileFilterModel } from "@/infrastructure/models/filtering/StorageFileFilterModel";

export class FileEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getRootFilesFilterDataAsync() {
        return await this.client.getAsync<StorageFileFilterDataModel>("api/files/root/files/filter");
    }

    public async getFilesByFilterAsync(filterOptions: StorageFileFilterModel) {
        const queryString = filterOptions.convertToQueryParams();
        return await this.client.getAsync<Array<StorageFile>>(`api/files/root/files/by-filter?${queryString}`);
    }
}