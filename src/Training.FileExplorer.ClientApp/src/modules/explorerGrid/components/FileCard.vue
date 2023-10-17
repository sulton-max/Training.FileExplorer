<template>

    <div @click="emit('onPreviewFile', file.path)" class="p-2 min-w-[200px] card-shadow">

        <div class="flex">

            <!-- Directory icon -->
            <img src="../../../assets/icons/pdf.svg" alt="Folder icon" class="w-16 h-16">

            <!-- Directory details -->
            <div class="p-2 text-slate-300 overflow-hidden">
                <p class="font-roboto truncate text-base">{{ file.name }}</p>
            </div>
        </div>

    </div>

</template>

<script lang="ts" setup>

import type { StorageFile } from "@/infrastructure/models/entities/StorageFile";

const emit = defineEmits<{
    onPreviewFile: [directoryPath: string]
}>();

const props = defineProps({
    file: {
        required: true,
        type: Object as () => StorageFile
    }
});

</script>