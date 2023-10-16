import type { IQueryConvertible } from "@/infrastructure/models/request/IQueryConvertible";

export class FilterPagination implements IQueryConvertible {
    pageSize: number = 10;
    pageToken: number = 1;

    constructor(pageSize: number, pageToken: number) {
        this.pageSize = pageSize;
        this.pageToken = pageToken;
    }

    convertToQueryParams(): URLSearchParams {
        const params = new URLSearchParams();
        params.append("pageSize", this.pageSize.toString());
        params.append("pageToken", this.pageToken.toString());

        return params;
    }
}