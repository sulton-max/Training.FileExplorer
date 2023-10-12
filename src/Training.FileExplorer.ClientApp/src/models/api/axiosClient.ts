import type {AxiosInstance, AxiosRequestConfig, AxiosResponse} from "axios";
import axios, {AxiosError} from "axios";
import {ProblemDetails} from "@/models/response/problemDetails";
import {ApiResponse} from "@/models/response/apiResponse";

export default class ApiClientBase {
    public readonly client: AxiosInstance;

    constructor(config: AxiosRequestConfig) {
        this.client = axios.create(config);

        this.client.interceptors.response.use(
            (response: AxiosResponse) => {
                return new ApiResponse(response.status, response.data, null);
            },
            (error: AxiosError) => {
                return error.response
                    ? Promise.reject(new ApiResponse(error.response.status, null, error.response.data as ProblemDetails))
                    : Promise.reject(error);
            }
        );
    }

    public async getAsync<T>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return await this.handleResponseAsync(this.client.get<T>(url, config));
    }

    public async postAsync<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return await this.handleResponseAsync(this.client.post<T>(url, data, config));
    }

    public async putAsync<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return await this.handleResponseAsync(this.client.put<T>(url, data, config));
    }

    public async deleteAsync<T>(url: string, config?: AxiosRequestConfig): Promise<ApiResponse<T>> {
        return await this.handleResponseAsync(this.client.delete<T>(url, config));
    }

    private async handleResponseAsync<T>(request: Promise<AxiosResponse<T>>): Promise<ApiResponse<T>> {
        try {
            const response = await request;
            return new ApiResponse<T>(response.status, response.data, null);
        } catch (error) {
            return error as ApiResponse<T>;
        }
    }
}