<template>

    <div class="p-5">

        <!-- Grid items view -->
        <div>
            <div class="grid grid-cols-3 gap-5">
                <div v-for="item in items" :key="item.path">

                    <div v-if="item.itemType == StorageItemType.Drive">
                        <drive-card @click="" :drive="item as StorageDrive"
                                    @onFetchDriveEntries="handleFetchDriveEntriesAsync"></drive-card>
                    </div>

                    <div v-else-if="item.itemType == StorageItemType.Directory">
                        <directory-card @onOpenDirectory="handleOpenDirectoryAsync"
                                        :directory="item as StorageDirectory"></directory-card>
                    </div>

                    <div v-else-if="item.itemType == StorageItemType.File">
                        <file-card :drive="item as StorageDrive"></file-card>
                    </div>

                    <div>

                    </div>

                </div>

            </div>
        </div>
    </div>

</template>

<script lang="ts" setup>

import { onMounted, onUnmounted, ref } from "vue";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import DriveCard from "@/modules/explorerGrid/components/DriveCard.vue";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import FolderCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import FileCard from "@/modules/explorerGrid/components/FileCard.vue";
import DirectoryCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";
import { FilterPagination } from "@/infrastructure/models/filtering/FilterPagination";
import { StorageDriveEntryFilterModel } from "@/infrastructure/models/filtering/StorageDriveEntryFilterModel";

// apiClients
const explorerApiClient = new ExplorerApiClient();

// const driveService = new DriveEndpoints();

const items = ref<Array<IStorageEntry>>([]);

const loadItems = async () => {
    const result = await explorerApiClient.drives.getDrivesAsync();
    if (result.response) {
        items.value.length = 0;
        result.response.forEach((item: IStorageEntry) => {
            items.value.push(item);
        });
    }
};

const handleFetchDriveEntriesAsync = (drivePath: string) => {
    fetchDriveEntriesAsync(drivePath);
};

const handleOpenDirectoryAsync = (directoryPath: string) => {
    fetchDriveEntriesAsync(directoryPath);
}

const fetchDriveEntriesAsync = async (directoryPath: string | null = null) => {
    const filterModel = new StorageDriveEntryFilterModel(20, 1, true, true);

    const result = directoryPath
        ? await explorerApiClient.directories.getEntriesAsync(directoryPath, filterModel)
        : await explorerApiClient.directories.getRootEntriesAsync(filterModel);

    if (result.response) {
        items.value.length = 0;
        result.response.forEach((item: IStorageEntry) => {
            items.value.push(item);
        });
    }
}

onMounted(() => {
    fetchDriveEntriesAsync();
    // loadItems();
});

</script>