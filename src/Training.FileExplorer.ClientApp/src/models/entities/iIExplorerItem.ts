import type { ExplorerItemType } from "@/models/entities/ExplorerItemType";

export interface IExplorerItem {
    path: string;
    itemType: ExplorerItemType;
}