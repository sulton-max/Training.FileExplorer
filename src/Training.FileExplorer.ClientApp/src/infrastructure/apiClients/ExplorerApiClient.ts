import ApiClientBase from "@/infrastructure/api/AxiosClient";
import { DriveEndpointsClient } from "@/infrastructure/apiClients/DriveEndpointsClient";
import { DirectoryEndpointsClient } from "@/infrastructure/apiClients/DirectoryEndpointsClient";
import { FileEndpointsClient } from "@/infrastructure/apiClients/FileEndpointsClient";

export class ExplorerApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7195";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.drives = new DriveEndpointsClient(this.client);
        this.directories = new DirectoryEndpointsClient(this.client);
        this.files = new FileEndpointsClient(this.client);
    }

    public drives: DriveEndpointsClient;

    public directories: DirectoryEndpointsClient;

    public files: FileEndpointsClient;
}