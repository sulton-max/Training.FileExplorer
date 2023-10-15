import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";
import type { IStorageItem } from "@/infrastructure/models/entities/iIExplorerItem";
import type { IMappable } from "@/infrastructure/models/entities/iMappable";

export class StorageDrive implements IStorageItem {
    name!: string;
    label!: string;
    format!: string;
    type!: string;
    totalSpace!: number;
    freeSpace!: number;
    unavailableSpace!: number;
    usedSpace!: number;
    itemType!: StorageItemType;
    path!: string;
}