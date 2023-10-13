<template>

  <div>

    <!-- Grid action -->
    <div>

      <button @click="loadItems" class="border border-slate-500 text-white">Load items</button>

    </div>

    <!-- Grid items view -->
    <div>
      <div class="grid grid-cols-4">
        <div v-for="item in items">

          <div v-if="item.explorerItemType == ExplorerItemType.Drive">
            <drive-card :drive="item as DriveInfo"></drive-card>
          </div>

          <div v-else-if="item.explorerItemType == ExplorerItemType.Folder">
            <folder-card :drive="item as DriveInfo"></folder-card>
          </div>

          <div v-else-if="item.explorerItemType == ExplorerItemType.File">
            <flie-card :drive="item as DriveInfo"></flie-card>
          </div>

        </div>

      </div>
    </div>
  </div>

</template>

<script lang="ts" setup>

// write back method that queries parent folder
import { DriveService } from "@/services/driveService";
import type { IExplorerItem } from "@/models/entities/IExplorerItem";
import { ExplorerItemType } from "@/models/entities/ExplorerItemType";
import DriveCard from "@/components/DriveCard.vue";
import { reactive } from "vue";
import type { DriveInfo } from "@/models/entities/DriveInfo";
import FolderCard from "@/components/FolderCard.vue";
import FlieCard from "@/components/FlieCard.vue";

// services
const driveService = new DriveService();

const items = reactive<Array<IExplorerItem>>([]);

const loadItems = async () => {
  const result = await driveService.getDrivesAsync();
  console.log(result);
  if (result.response) {
    console.log('items', result.response);
    items.push(...result.response);
  }
};

</script>

