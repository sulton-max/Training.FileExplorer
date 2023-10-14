import type { IExplorerItem } from "@/infrastructure/models/entities/iIExplorerItem";

export class FolderInfo implements IExplorearItem {
    public name: string;
    public path: string;
    public explorerItemType: string;

    constructor(name: string, path: string, type: string) {
        this.name = name;
        this.path = path;
        this.explorerItemType = type;
    }
}