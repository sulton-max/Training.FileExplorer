<template>

  <div
      class="w-3/5 h-4/5 flex overflow-hidden bg-blue-800 bg-clip-padding backdrop-filter backdrop-blur-xl bg-opacity-10 border border-slate-600 rounded-3xl ">

    <!-- Action section -->
    <explorer-actions class="basis-1/3 bg-black opacity-20"/>

    <!-- Explorer Items section -->
    <explorer-grid class="basis-2/3"/>
    how
  </div>

</template>

<script setup lang="ts">

import ExplorerActions from "@/modules/explorerActions/components/ExplorerActions.vue";
import ExplorerGrid from "@/modules/explorerGrid/components/ExplorerGrid.vue";
</script>