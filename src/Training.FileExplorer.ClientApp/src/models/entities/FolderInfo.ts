import type { IExplorerItem } from "@/models/entities/IExplorerItem";

export class FolderInfo implements IExplorerItem {
    public name: string;
    public path: string;
    public explorerItemType: string;

    constructor(name: string, path: string, type: string) {
        this.name = name;
        this.path = path;
        this.explorerItemType = type;
    }
}