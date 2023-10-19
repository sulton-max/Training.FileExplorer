import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import { StorageEntryType } from "@/infrastructure/models/entities/StorageItemType";

export class StorageDirectory implements IStorageEntry {
    public name!: string;
    public path!: string;
    public itemsCount!: number;
    entryType: StorageEntryType = StorageEntryType.Directory;
}