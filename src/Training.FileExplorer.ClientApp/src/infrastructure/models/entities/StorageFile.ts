import { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import type { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";

export class StorageFile implements IStorageEntry {
     name!: string;
     path!: string;
     directoryPath!: string;
     size!: number;
     extension!: string;
     itemType!: StorageItemType;
}