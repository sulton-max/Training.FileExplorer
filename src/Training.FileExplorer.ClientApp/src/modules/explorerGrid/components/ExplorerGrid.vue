<template>

  <div class="p-10">

    <!-- Grid action -->
    <div>

      <button @click="loadItems" class="border border-slate-500 text-white">Load items</button>

    </div>

    <!-- Grid items view -->
    <div>
      <div class="grid grid-cols-4 gap-5">
        <div v-for="item in items" :key="item.path">

          <div v-if="item.itemType == ExplorerItemType.Drive">
            <drive-card @click="" :drive="item as DriveInfo" @onFetchDriveEntries="handleFetchDriveEntriesAsync"></drive-card>
          </div>

          <div v-else-if="item.itemType == ExplorerItemType.Folder">
            <folder-card :drive="item as DriveInfo"></folder-card>
          </div>

          <div v-else-if="item.itemType == ExplorerItemType.File">
            <file-card :drive="item as DriveInfo"></file-card>
          </div>

          <div>

          </div>

        </div>

      </div>
    </div>
  </div>

</template>

<script lang="ts" setup>

import { onMounted, ref } from "vue";
import type { IExplorerItem } from "@/infrastructure/models/entities/iIExplorerItem";
import { ExplorerItemType } from "@/infrastructure/models/entities/ExplorerItemType";
import type { DriveInfo } from "@/infrastructure/models/entities/DriveInfo";
import DriveCard from "@/modules/explorerGrid/components/DriveCard.vue";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import FolderCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import FileCard from "@/modules/explorerGrid/components/FileCard.vue";

// apiClients
const explorerApiClient = new ExplorerApiClient();

// const driveService = new DriveEndpoints();

const items = ref<Array<IExplorerItem>>([]);

const loadItems = async () => {
  const result = await explorerApiClient.drives.getDrivesAsync();
  if (result.response) {
    items.value.length = 0;
    result.response.forEach((item: IExplorerItem) => {
      items.value.push(item);
    });
  }
};

const handleFetchDriveEntriesAsync = async (drivePath: string) => {
  const result = await explorerApiClient.drives.getDriveEntriesAsync(drivePath);
  if (result.response) {
    items.value.length = 0;
    result.response.forEach((item: IExplorerItem) => {
      items.value.push(item);
    });
  }
};

onMounted(() => {
  loadItems();
});

</script>