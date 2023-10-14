import type { ExplorerItemType } from "@/infrastructure/models/entities/ExplorerItemType";

export interface IExplorerItem {
    path: string;
    itemType: ExplorerItemType;
}