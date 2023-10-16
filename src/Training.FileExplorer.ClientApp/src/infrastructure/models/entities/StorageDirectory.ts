import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";

export class StorageDirectory implements IStorageEntry {
    public name!: string;
    public path!: string;
    public itemsCount!: number;
    itemType: StorageItemType = StorageItemType.Directory;
}