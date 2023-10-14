import ApiClientBase from "@/infrastructure/api/AxiosClient";
import { DriveEndpointsClient } from "@/infrastructure/apiClients/DriveEndpointsClient";

export class ExplorerApiClient {
    private readonly client: ApiClientBase;

    constructor() {
        this.client = new ApiClientBase({
            baseURL: "https://localhost:7195/api/"
        });

        this.drives = new DriveEndpointsClient(this.client);
    }

    public drives: DriveEndpointsClient;
}