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

          <div v-if="item.itemType == StorageItemType.Drive">
            <drive-card @click="" :drive="item as StorageDrive" @onFetchDriveEntries="handleFetchDriveEntriesAsync"></drive-card>
          </div>

          <div v-else-if="item.itemType == StorageItemType.Directory">
            <directory-card :directory="item as StorageDirectory"></directory-card>
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

import { onMounted, ref } from "vue";
import type { IStorageItem } from "@/infrastructure/models/entities/iIExplorerItem";
import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import DriveCard from "@/modules/explorerGrid/components/DriveCard.vue";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import FolderCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import FileCard from "@/modules/explorerGrid/components/FileCard.vue";
import DirectoryCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";

// apiClients
const explorerApiClient = new ExplorerApiClient();

// const driveService = new DriveEndpoints();

const items = ref<Array<IStorageItem>>([]);

const loadItems = async () => {
  const result = await explorerApiClient.drives.getDrivesAsync();
  if (result.response) {
    items.value.length = 0;
    result.response.forEach((item: IStorageItem) => {
      items.value.push(item);
    });
  }
};

const handleFetchDriveEntriesAsync = async (driveLabel: string) => {
  const result = await explorerApiClient.drives.getDriveEntriesAsync(driveLabel);
  if (result.response) {
    items.value.length = 0;
    result.response.forEach((item: IStorageItem) => {
      items.value.push(item);
    });
  }
};

onMounted(() => {
  loadItems();
});

</script>