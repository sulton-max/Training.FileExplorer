import type { IExplorerItem } from "@/models/entities/IExplorerItem";
import type { ExplorerItemType } from "@/models/entities/ExplorerItemType";

export class DriveInfo implements IExplorerItem {
    name: string;
    format: string;
    type: string;
    volumeLabel: string;
    totalSize: number;
    availableFreeSpace: number;
    totalFreeSpace: number;
    explorerItemType: ExplorerItemType;

    constructor(name: string, format: string, type: string, volumeLabel: string, totalSize: number, availableFreeSpace: number, totalFreeSpace: number, explorerItemType: ExplorerItemType) {
        this.name = name;
        this.format = format;
        this.type = type;
        this.volumeLabel = volumeLabel;
        this.totalSize = totalSize;
        this.availableFreeSpace = availableFreeSpace;
        this.totalFreeSpace = totalFreeSpace;
        this.explorerItemType = explorerItemType;
    }
}