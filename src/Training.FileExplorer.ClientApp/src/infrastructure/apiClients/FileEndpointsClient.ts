import type ApiClientBase from "@/infrastructure/api/AxiosClient";
import { StorageFileFilterDataModel } from "@/infrastructure/models/filtering/StorageFileFilterDataModel";

export class FileEndpointsClient {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getRootFilesFilterDataAsync() {
        return await this.client.getAsync<StorageFileFilterDataModel>("api/files/root/files/filter");
    }
}