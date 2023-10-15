import type { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";

export interface IStorageItem {
    path: string;
    itemType: StorageItemType;
}