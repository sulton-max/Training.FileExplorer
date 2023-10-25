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

                <div v-for="filterData in filesFilterData.filterData">

                    <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
                        <img :src="explorerLocationService.getFileUrl(explorerApiClient.baseUrl, filterData.imageUrl)" alt="Document icon" class="w-6 h-6">
<!--                        {{filterData.storageFileType.toString()}}-->

                        <span>{{filterData.displayName}}</span>
                        <span>{{filterData.count}}</span>
                        <span>{{filterData.size}}</span>
                    </div>

                </div>

<!--                <div class="p-2 flex text-slate-300 items-center justify-start gap-2">-->
<!--                    <img src="../../../assets/icons/document.svg" alt="Document icon" class="w-6 h-6">-->
<!--                    Documents-->
<!--                </div>-->

<!--                <div class="p-2 flex text-slate-300 items-center justify-start gap-2">-->
<!--                    <img src="../../../assets/icons/image.svg" alt="Document icon" class="w-6 h-6">-->
<!--                    Images-->
<!--                </div>-->

<!--                <div class="p-2 flex text-slate-300 items-center justify-start gap-2">-->
<!--                    <img src="../../../assets/icons/vscode.svg" alt="Document icon" class="w-6 h-6">-->
<!--                    Source code files-->
<!--                </div>-->

<!--                <div class="p-2 flex text-slate-300 items-center justify-start gap-2">-->
<!--                    <img src="../../../assets/icons/template.svg" alt="Document icon" class="w-6 h-6">-->
<!--                    Other files-->
<!--                </div>-->

            </div>

            <horizontal-divider/>

            <!-- Open folders assist -->
            <div class="p-3">

                <div class="p-2 flex text-slate-300 items-center justify-between rounded-lg transparent-shadow-off">
                    <div class="flex gap-2 items-center">
                        <img src="../../../assets/icons/folder.svg" alt="Models" class="w-6 h-6">
                        Other files
                    </div>
                    <i class="fas fa-chevron-right"></i>
                </div>

                <horizontal-divider class="m-1"/>

                <div class="p-2 flex text-slate-300 items-center justify-between rounded-lg transparent-shadow-off">
                    <div class="flex gap-2 items-center">
                        <img src="../../../assets/icons/folder.svg" alt="Models" class="w-6 h-6">
                        Other files
                    </div>
                    <i class="fas fa-chevron-right"></i>
                </div>

                <horizontal-divider class="m-1"/>

                <div class="p-2 flex text-slate-300 items-center justify-between rounded-lg transparent-shadow-off">
                    <div class="flex gap-2 items-center">
                        <img src="../../../assets/icons/folder.svg" alt="Models" class="w-6 h-6">
                        Other files
                    </div>
                    <i class="fas fa-chevron-right"></i>
                </div>

            </div>

            <horizontal-divider/>

        </div>

        <!-- My computer statistics -->
        <div class="p-3">

            <div v-for="drive in drives" :key="drive.path">
                <drive-card-compact :drive="drive"></drive-card-compact>
                <horizontal-divider class="m-1 w-[90%] place-self-center"/>
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
        console.log('filter data', filesSummary.response)
        filesFilterData.value = filesSummary.response;
    }
}

</script>