import type { StorageEntryType } from "@/infrastructure/models/entities/StorageItemType";

export interface IStorageEntry {
    path: string;
    entryType: StorageEntryType;
}