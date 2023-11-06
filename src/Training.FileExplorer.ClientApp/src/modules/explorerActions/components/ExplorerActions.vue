<template>

    <div class="h-full flex flex-col justify-between">

        <div>

            <!-- Explorer title -->
            <div class="h-[60px] flex items-center pl-5">
                <h2 class="text-slate-300 text-xl font-rubik">File Explorer</h2>
            </div>

            <horizontal-divider/>

            <!-- Files statistics -->
            <div class="p-3">
                <div v-for="filesSummary in filesFilterData.filterData" class="my-2">
                    <file-summary-card-compact @onLoadFiles="loadFilesAsync" :files-summary="filesSummary"></file-summary-card-compact>
                </div>
            </div>

        </div>

        <!-- My computer statistics -->
        <div class="p-3">

            <div v-for="(drive, index) in drives" :key="drive.path">
                <drive-card-compact :drive="drive"></drive-card-compact>
                <horizontal-divider v-if="index !== drives.length - 1" class="m-1 w-[90%] place-self-center"/>
            </div>

        </div>

    </div>

</template>

<script setup lang="ts">

import HorizontalDivider from "@/common/components/HorizontalDivider.vue";
import DriveCardCompact from "@/modules/explorerActions/components/DriveCardCompact.vue";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import { onMounted, ref } from "vue";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import type { StorageFileFilterDataModel } from "@/infrastructure/models/filtering/StorageFileFilterDataModel";
import { ExplorerLocationService } from "@/infrastructure/services/explorerLocationService";
import FileSummaryCardCompact from "@/modules/explorerActions/components/FileSummaryCardCompact.vue";
import type { StorageFileType } from "@/infrastructure/models/filtering/StorageFileType";
import { StorageFileFilterModel } from "@/infrastructure/models/filtering/StorageFileFilterModel";
import { useExplorerStore } from "@/common/stores/ExplorerStore";

const explorerStore = useExplorerStore();

const explorerApiClient = new ExplorerApiClient();
const explorerLocationService = new ExplorerLocationService();

const drives = ref<StorageDrive[]>([]);
const filesFilterData = ref<StorageFileFilterDataModel>([]);

onMounted(async () => {
    await loadDrivesAsync();
    await loadFilesFilterDataAsync();
});

const loadDrivesAsync = async () => {
    const drivesResponse = await explorerApiClient.drives.getDrivesAsync();
    if (drivesResponse.response) {
        drives.value = drivesResponse.response;
    }
}

const loadFilesFilterDataAsync = async () => {
    const filesSummary = await explorerApiClient.files.getRootFilesFilterDataAsync();
    if(filesSummary.response) {
        filesFilterData.value = filesSummary.response;
    }
}

const loadFilesAsync = async (fileType: StorageFileType) => {
    const filterOptions = new StorageFileFilterModel(10000, 1,  [fileType]);
    explorerStore.setCurrentFilesFilterModel(filterOptions);
}

const handleOpenDirectory = (directoryPath: string) => {
    explorerStore.setCurrentPath(directoryPath);
    explorerStore.setCurrentPath(directoryPath);
}

</script>