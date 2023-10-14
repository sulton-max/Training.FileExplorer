import { ExplorerItemType } from "@/infrastructure/models/entities/ExplorerItemType";
import type { IExplorerItem } from "@/infrastructure/models/entities/iIExplorerItem";
import type { IMappable } from "@/infrastructure/models/entities/iMappable";

export class DriveInfo implements IExplorerItem, IMappable<DriveInfo> {
    name: string;
    format: string;
    type: string;
    volumeLabel: string;
    totalSpace: number;
    freeSpace: number;
    unavailableSpace: number;
    usedSpace: number;
    itemType: ExplorerItemType;
    path: string;

    constructor(name: string, format: string, type: string, volumeLabel: string, totalSize: number, freeSpace: number, unavailableSpace: number, usedSpace: number) {
        this.name = name;
        this.format = format;
        this.type = type;
        this.volumeLabel = volumeLabel;
        this.totalSpace = totalSize;
        this.freeSpace = freeSpace;
        this.unavailableSpace = unavailableSpace;
        this.usedSpace = usedSpace;
        this.path = name;

        this.itemType = ExplorerItemType.Drive;
    }

    map(value: any){
        this.name = value.name;
        this.format = value.format;
        this.type = value.type;
        this.volumeLabel = value.volumeLabel;
        this.totalSpace = value.totalSpace;
        this.freeSpace = value.freeSpace;
        this.unavailableSpace = value.unavailableSpace;
        this.path = value.name;

        this.itemType = ExplorerItemType.Drive;
    }
}