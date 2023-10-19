import ApiClientBase from "@/infrastructure/api/AxiosClient";
import { DriveEndpointsClient } from "@/infrastructure/apiClients/DriveEndpointsClient";
import { DirectoryEndpointClient } from "@/infrastructure/apiClients/DirectoryEndpointsClient";

export class ExplorerApiClient {
    private readonly client: ApiClientBase;

    constructor() {
        this.client = new ApiClientBase({
            baseURL: "https://localhost:7124/api"
        });

        this.drives = new DriveEndpointsClient(this.client);
        this.directories = new DirectoryEndpointClient(this.client);
    }

    public drives: DriveEndpointsClient;

    public directories: DirectoryEndpointClient;
}