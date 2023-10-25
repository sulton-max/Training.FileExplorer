import { useExplorerStore } from "@/common/stores/ExplorerStore";

export class ExplorerLocationService {

    getCurrentPath(): string | null {
        const store = useExplorerStore();
        return store.currentPath;
    }

    setCurrentPath(path: string): void {
        if (!path) return;

        const store = useExplorerStore();
        store.setCurrentPath(path);
    }

    getFileUrl(baseUrl: string, fileUrl: string) {
        return `${baseUrl}/${fileUrl}`;
    }
}