<template>

    <div
        class="w-3/5 h-4/5 overflow-hidden rounded-3xl container-shadow border border-slate-700">

        <div v-if="isLoading">
            <p>loading ...</p>
        </div>
        <div v-else class="flex h-full w-full">
            <!-- Action section -->
            <explorer-actions class="basis-1/3 section-shadow"/>

            <div class="basis-2/3">
                <!-- Grid actions section -->
                <explorer-grid-actions/>

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
import { onBeforeMount, ref } from "vue";
import { StorageDriveEntryFilterModel } from "@/infrastructure/models/filtering/StorageDriveEntryFilterModel";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";

const explorerApiClient = new ExplorerApiClient();

onBeforeMount(() => {
    loadGridItemsAsync();
});

const gridItems = ref<Array<IStorageEntry>>([]);
const isLoading = ref<boolean>(true);

const loadGridItemsAsync = async () => {
    isLoading.value = true;

    const filterModel = new StorageDriveEntryFilterModel(20, 1, true, true);
    const entriesResponse = await explorerApiClient.directories.getRootEntriesAsync(filterModel);

    if (entriesResponse.response) {
        gridItems.value.length = 0;
        entriesResponse.response.forEach((item: IStorageEntry) => {
            gridItems.value.push(item);
        });
    }

    isLoading.value = false;
};

</script>