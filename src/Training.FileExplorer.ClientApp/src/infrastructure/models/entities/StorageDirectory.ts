import type { IStorageItem } from "@/infrastructure/models/entities/iIExplorerItem";
import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";

export class StorageDirectory implements IStorageItem {
    public name!: string;
    public path!: string;
    public itemsCount!: number;
    itemType: StorageItemType = StorageItemType.Directory;
}