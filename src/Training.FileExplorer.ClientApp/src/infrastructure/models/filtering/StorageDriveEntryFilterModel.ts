import { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";

export class StorageDriveEntryFilterModel extends FilterPagination {
    includeDirectories: boolean;
    includeFiles: boolean;

    constructor(pageSize: number, pageToken: number, includeDirectories: boolean, includeFiles: boolean) {
        super(pageSize, pageToken);

        this.includeDirectories = includeDirectories;
        this.includeFiles = includeFiles;
    }

    override convertToQueryParams(): URLSearchParams {
        const params = super.convertToQueryParams();
        params.append("includeDirectories", this.includeDirectories.toString());
        params.append("includeFiles", this.includeFiles.toString());

        return params;
    }
}