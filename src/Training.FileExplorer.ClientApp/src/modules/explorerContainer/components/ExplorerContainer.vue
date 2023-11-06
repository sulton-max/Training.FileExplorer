<template>

    <div
        class="w-3/5 h-4/5 overflow-hidden rounded-xl container-shadow border border-slate-700">

        <div v-if="isLoading">
            <p>loading ...</p>
        </div>
        <div v-else class="flex h-full w-full">
            <!-- Action section -->
            <explorer-actions class="basis-1/3 section-shadow"/>

            <div class="basis-2/3">

                <!-- Grid actions section -->
                <explorer-grid-actions/>

                <horizontal-divider/>

                <!-- Explorer Items section -->
                <explorer-grid :grid-items="gridItems"/>
            </div>
        </div>
    </div>

</template>

<script setup lang="ts">

import ExplorerActions from "@/modules/explorerActions/components/ExplorerActions.vue";
import ExplorerGrid from "@/modules/explorerGrid/components/ExplorerGrid.vue";
import ExplorerGridActions from "@/modules/explorerGrid/components/ExplorerGridActions.vue";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import { onBeforeMount, ref, toRefs, watch } from "vue";
import { StorageDriveEntryFilterModel } from "@/infrastructure/models/filtering/StorageDriveEntryFilterModel";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import HorizontalDivider from "@/common/components/HorizontalDivider.vue";
import { useExplorerStore } from "@/common/stores/ExplorerStore";
import { storeToRefs } from "pinia";
import { StorageFileFilterModel } from "@/infrastructure/models/filtering/StorageFileFilterModel";

const explorerApiClient = new ExplorerApiClient();
const explorerStore = useExplorerStore();
const {currentPath, currentFilesFilterModel} = storeToRefs(explorerStore);

onBeforeMount(() => {
    loadGridItemsAsync();
});

const gridItems = ref<Array<IStorageEntry>>([]);
const isLoading = ref<boolean>(true);

watch(currentPath, async () => {
    if (currentPath)
        await loadGridItemsAsync();
});

watch(currentFilesFilterModel, async () => {
    if (currentFilesFilterModel)
        await loadGridFilesAsync();
});

const loadGridItemsAsync = async () => {
    isLoading.value = true;

    const filterModel = new StorageDriveEntryFilterModel(20, 1, true, true);
    const entriesResponse = currentPath.value
        ? await explorerApiClient.directories.getEntriesAsync(currentPath.value, filterModel)
        : await explorerApiClient.directories.getRootEntriesAsync(filterModel);

    if (entriesResponse.response) {
        gridItems.value.length = 0;
        entriesResponse.response.forEach((item: IStorageEntry) => {
            gridItems.value.push(item);
        });
    }

    if (explorerStore.currentPath) {
        const pathSegments = explorerStore.currentPath?.split('\\');

        if (pathSegments[pathSegments.length - 1] === 'wwwroot')
            explorerStore.resetCurrentPath();
    }

    isLoading.value = false;
};

const loadGridFilesAsync = async () => {
    isLoading.value = true;

    const filterOptions = explorerStore.currentFilesFilterModel as StorageFileFilterModel;
    const filesResponse = await explorerApiClient.files.getFilesByFilterAsync(filterOptions);

    // const filterModel = new StorageDriveEntryFilterModel(20, 1, true, true);
    // const entriesResponse = currentPath.value
    //     ? await explorerApiClient.directories.getEntriesAsync(currentPath.value, filterModel)
    //     : await explorerApiClient.directories.getRootEntriesAsync(filterModel);

    if (filesResponse.response) {
        gridItems.value.length = 0;
        filesResponse.response.forEach((item: IStorageEntry) => {
            gridItems.value.push(item);
        });
    }

            explorerStore.resetCurrentPath();

    // if (explorerStore.currentPath) {
    //     const pathSegments = explorerStore.currentPath?.split('\\');
    //
    //     if (pathSegments[pathSegments.length - 1] === 'wwwroot')
    // }

    isLoading.value = false;
};

</script>