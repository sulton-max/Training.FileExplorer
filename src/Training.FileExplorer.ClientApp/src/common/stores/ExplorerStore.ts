import { defineStore } from "pinia";
import type { StorageFileFilterModel } from "@/infrastructure/models/filtering/StorageFileFilterModel";

export const useExplorerStore = defineStore({
    id: "explorer",
    state: () => ({
        currentPath: null as string | null,
        currentFilesFilterModel : null as StorageFileFilterModel | null
    }),
    actions: {
        setCurrentPath(path: string) {
            if (!path) return;

            this.currentPath = path;
        },
        resetCurrentPath() {
            this.currentPath = null;
        },
        setCurrentFilesFilterModel(filterDataModel: StorageFileFilterModel) {
            if(!filterDataModel) return;

            this.currentFilesFilterModel = filterDataModel;
        },
        resetCurrentFilesFilterModel() {
            this.currentFilesFilterModel = null;
        }
    }
})