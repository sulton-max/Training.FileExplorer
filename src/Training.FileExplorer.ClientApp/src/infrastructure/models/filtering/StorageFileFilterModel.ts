import { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";
import type { StorageFileType } from "@/infrastructure/models/filtering/StorageFileType";

export class StorageFileFilterModel extends FilterPagination {
    filesType!: Array<StorageFileType>;

    constructor(pageSize: number, pageToken: number, filesType: Array<StorageFileType>) {
        super(pageSize, pageToken);

        console.log('file types', filesType);

        this.filesType = filesType;
    }

    override convertToQueryParams(): URLSearchParams {
        const params = super.convertToQueryParams();
        params.append("filesType", this.filesType.join(","));

        // console.log(this.filesType.map(x => x.toString()).join(","));
        // console.log(params.toString());

        return params;
    }
}