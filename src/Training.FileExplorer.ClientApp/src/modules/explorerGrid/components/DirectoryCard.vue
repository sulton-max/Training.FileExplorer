<template>

    <grid-item-card @click="emit('onOpenDirectory', directory.path)" class="p-2 min-w-[200px]">

        <div class="flex">

            <!-- Directory icon -->
            <img src="../../../assets/icons/folder.svg" alt="Folder icon" class="w-16 h-16">

            <!-- Directory details -->
            <div class="p-2 text-slate-300 overflow-hidden">
                <p class="font-roboto truncate text-base">{{ directory.name }}</p>
                <span class="text-sm">{{ directory.itemsCount }} items</span>
            </div>
        </div>

    </grid-item-card>

</template>

<script lang="ts" setup>


import GridItemCard from "@/components/GridItemCard.vue";
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

console.log('directory', props.directory);

</script>