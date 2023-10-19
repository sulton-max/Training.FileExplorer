<template>

    <div class="p-5">

        <!-- Grid items view -->
        <div>
            <div class="grid grid-cols-3 gap-5">

                <!-- Grid Items -->
                <div v-for="item in gridItems" :key="item.path">

                    <div v-if="item.itemType === StorageItemType.Drive">
                        <drive-card :drive="item as StorageDrive"></drive-card>
                    </div>

                    <div v-else-if="item.itemType === StorageItemType.Directory">
                        <directory-card :directory="item as StorageDirectory" @onOpenDirectory="handleOpenDirectory"></directory-card>
                    </div>

                    <div v-else-if="item.itemType === StorageItemType.File">
                        <file-card :file="item as StorageFile"></file-card>
                    </div>

                </div>

            </div>
        </div>
    </div>

</template>

<script lang="ts" setup>

import type { PropType } from "vue";
import DriveCard from "@/modules/explorerGrid/components/DriveCard.vue";
import FileCard from "@/modules/explorerGrid/components/FileCard.vue";
import DirectoryCard from "@/modules/explorerGrid/components/DirectoryCard.vue";
import type { IStorageEntry } from "@/infrastructure/models/entities/IStorageEntry";
import { StorageItemType } from "@/infrastructure/models/entities/StorageItemType";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";
import type { StorageFile } from "@/infrastructure/models/entities/StorageFile";
import { ExplorerLocationService } from "@/infrastructure/services/explorerLocationService";

const explorerService = new ExplorerLocationService();

const props = defineProps({
    gridItems: {
        type: Array as PropType<Array<IStorageEntry>>,
        required: true
    }
});

const handleOpenDirectory = (directoryPath: string) => {
    explorerService.setCurrentPath(directoryPath);
}

</script>