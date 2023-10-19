import { StorageEntryType } from "@/infrastructure/models/entities/StorageItemType";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";

export class StorageDrive implements IStorageEntry {
    name!: string;
    label!: string;
    format!: string;
    type!: string;
    totalSpace!: number;
    freeSpace!: number;
    unavailableSpace!: number;
    usedSpace!: number;
    entryType!: StorageEntryType;
    path!: string;
}