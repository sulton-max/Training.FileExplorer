import { ExplorerItemType } from "@/models/entities/ExplorerItemType";
import type { IExplorerItem } from "@/models/entities/iIExplorerItem";
import type { IMappable } from "@/models/entities/iMappable";

export class DriveInfo implements IExplorerItem, IMappable<DriveInfo> {
    name: string;
    format: string;
    type: string;
    volumeLabel: string;
    totalSize: number;
    availableFreeSpace: number;
    totalFreeSpace: number;
    itemType: ExplorerItemType;
    path: string;

    constructor(name: string, format: string, type: string, volumeLabel: string, totalSize: number, availableFreeSpace: number, totalFreeSpace: number) {
        console.log('ctor hit');

        this.name = name;
        this.format = format;
        this.type = type;
        this.volumeLabel = volumeLabel;
        this.totalSize = totalSize;
        this.availableFreeSpace = availableFreeSpace;
        this.totalFreeSpace = totalFreeSpace;
        this.path = name;

        this.itemType = ExplorerItemType.Drive;
    }

    map(value: any){
        this.name = value.name;
        this.format = value.format;
        this.type = value.type;
        this.volumeLabel = value.volumeLabel;
        this.totalSize = value.totalSize;
        this.availableFreeSpace = value.availableFreeSpace;
        this.totalFreeSpace = value.totalFreeSpace;
        this.path = value.name;

        this.itemType = ExplorerItemType.Drive;
    }
}