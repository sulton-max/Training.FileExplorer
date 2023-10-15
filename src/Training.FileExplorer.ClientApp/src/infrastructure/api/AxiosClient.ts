import type { AxiosInstance, AxiosRequestConfig, AxiosResponse } from "axios";
import axios, { AxiosError } from "axios";
import type { IMappable } from "@/infrastructure/models/entities/iMappable";
import { ApiResponse } from "@/infrastructure/api/ApiResponse";
import type { ProblemDetails } from "@/infrastructure/api/ProblemDetails";

export default class ApiClientBase {
    public readonly client: AxiosInstance;

    constructor(config: AxiosRequestConfig) {
        this.client = axios.create(config);

        this.client.interceptors.response.use(
            <TResponse>(response: AxiosResponse<TResponse>) => {
                return {
                    ...response,
                    data: new ApiResponse(response.data as TResponse, null, response.status)
                }
            },
            (error: AxiosError) => {
                return {
                    ...error,
                    data: new ApiResponse(null, error.response?.data as ProblemDetails, error.response?.status ?? 500)
                };
            }
        );
    }

    public async getAsync<TResponse extends IMappable<TResponse>>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<TResponse>> {
        return (await this.client.get<ApiResponse<TResponse>>(url, config)).data;
    }

    public async postAsync<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.post<ApiResponse<T>>(url, data, config)).data;
    }

    public async putAsync<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.put<ApiResponse<T>>(url, data, config)).data;
    }

    public async deleteAsync<T>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return (await this.client.delete<ApiResponse<T>>(url, config)).data;
    }
}