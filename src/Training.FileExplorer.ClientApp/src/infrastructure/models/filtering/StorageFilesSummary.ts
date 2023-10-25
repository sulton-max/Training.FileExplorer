import type { StorageFileType } from "@/infrastructure/models/filtering/StorageFileType";

export class StorageFilesSummary {
    storageFileType!: StorageFileType;
    displayName!: string;
    count!: number;
    size!: number;
    imageUrl!: string;
}