import { defineStore } from "pinia";

export const useExplorerStore = defineStore({
    id: "explorer",
    state: () => ({
        currentPath: null as string | null
    }),
    actions: {
        setCurrentPath(path: string) {
            if (!path) return;

            this.currentPath = path;
        },
        resetCurrentPath() {
            this.currentPath = null;
        }
    }
})