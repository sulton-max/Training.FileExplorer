<template>

    <div @click="emit('onLoadFiles', directory.path)" class="p-2 min-w-[200px] transparent-shadow-on card-round">

        <div class="flex">

            <!-- Directory icon -->
            <img src="../../../assets/icons/folder.svg" alt="Folder icon" class="w-16 h-16">

            <!-- Directory details -->
            <div class="p-2 text-slate-300 overflow-hidden">
                <p class="font-roboto truncate text-base">{{ directory.name }}</p>
                <span class="text-sm">{{ directory.itemsCount }} items</span>
            </div>
        </div>

    </div>

</template>

<script lang="ts" setup>

import type { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";

const emit = defineEmits<{
    onOpenDirectory: [directoryPath: string]
}>();

const props = defineProps({
    directory: {
        required: true,
        type: Object as () => StorageDirectory
    }
});

</script>