<template>

    <div class="p-2 flex text-slate-300 items-center justify-start gap-2 transparent-shadow-off rounded-lg cursor-pointer">
        <img :src="explorerLocationService.getFileUrl(explorerApiClient.baseUrl, filesSummary.imageUrl)" alt="File icon" class="w-6 h-6">

        <div class="flex w-full">
            <span class="basis-3/5">{{filesSummary.displayName}}</span>
            <span class="basis-1/5 text-slate-400">{{filesSummary.count}}</span>
            <span class="basis-2/5 text-slate-400">{{explorerLocationService.getFileSizeString(filesSummary.size)}}</span>
        </div>
    </div>

</template>

<script setup lang="ts">

import { ExplorerLocationService } from "@/infrastructure/services/explorerLocationService";
import { StorageFilesSummary } from "@/infrastructure/models/filtering/StorageFilesSummary";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";

const explorerApiClient = new ExplorerApiClient();
const explorerLocationService = new ExplorerLocationService();

const emit = defineEmits<{
    onLoadFiles: [directoryPath: string]
}>();

const props = defineProps({
    filesSummary: {
        type: Object as () => StorageFilesSummary,
        required: true
    }
});

</script>