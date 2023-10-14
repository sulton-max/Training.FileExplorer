<template>

  <div>

    <!-- Grid action -->
    <div>

      <button @click="loadItems" class="border border-slate-500 text-white">Load items</button>

    </div>

    <!-- Grid items view -->
    <div>
      <div class="grid grid-cols-4">
        <div v-for="item in items" :key="item.path">

<!--          <p class="text-white">hii</p>-->

          <div v-if="item.itemType == ExplorerItemType.Drive">
            <p class="text-white">hii</p>
            <drive-card :drive="item as DriveInfo"></drive-card>
          </div>

          <div v-else-if="item.itemType == ExplorerItemType.Folder">
            <folder-card :drive="item as DriveInfo"></folder-card>
          </div>

          <div v-else-if="item.itemType == ExplorerItemType.File">
            <file-card :drive="item as DriveInfo"></file-card>
          </div>

        </div>

      </div>
    </div>
  </div>

</template>

<script lang="ts" setup>

// write back method that queries parent folder
import { DriveService } from "@/services/driveService";
import type { IExplorerItem } from "@/models/entities/iIExplorerItem";
import { ExplorerItemType } from "@/models/entities/ExplorerItemType";
import DriveCard from "@/components/DriveCard.vue";
import { onMounted, reactive, ref } from "vue";
import { DriveInfo } from "@/models/entities/DriveInfo";
import FolderCard from "@/components/FolderCard.vue";
import FileCard from "@/components/FlieCard.vue";

// services
const driveService = new DriveService();

const items = ref<Array<IExplorerItem>>([]);

const loadItems = async () => {
  const result = await driveService.getDrivesAsync();
  if (result.response) {
    items.value.length = 0;
    result.response.forEach((item) => {
      items.value.push(item);
    });

    console.log(items.value);
  }
};

onMounted(() => {
  loadItems();
});

</script>