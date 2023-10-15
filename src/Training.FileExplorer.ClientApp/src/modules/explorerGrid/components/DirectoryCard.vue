<template>

  <grid-item-card>

    <p>{{directory.name}}</p>

  </grid-item-card>

</template>

<script lang="ts" setup>


import GridItemCard from "@/components/GridItemCard.vue";
import type { StorageDirectory } from "@/infrastructure/models/entities/StorageDirectory";


const props = defineProps({
  directory: {
    required: true,
    type: Object as () => StorageDirectory
  }
});

console.log('directory', props.directory);

</script>