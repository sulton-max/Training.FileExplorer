import type { ProblemDetails } from "@/infrastructure/api/ProblemDetails";

export class ApiResponse<T> {
    public response: T | null;
    public error: ProblemDetails | null;
    public status: number;

    constructor(response: T | null, error: ProblemDetails | null, status: number) {
        this.response = response;
        this.error = error;
        this.status = status;
    }
}