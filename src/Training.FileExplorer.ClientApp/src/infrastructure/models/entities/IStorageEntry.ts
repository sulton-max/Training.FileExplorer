import type { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";

export interface IStorageEntry {
    path: string;
    itemType: StorageItemType;
}