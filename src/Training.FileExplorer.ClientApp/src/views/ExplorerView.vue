<template>

  <div class="relative w-full h-full">

    <!-- Main background -->
    <img class="absolute top-0 left-0 z-20 object-cover" src="@/assets/images/background.jpg" alt="Background image">

    <!-- Explorer view and grid -->
    <explorer-container/>

  </div>

</template>

<script setup lang="ts">

import ExplorerContainer from "@/components/ExplorerContainer.vue";

</script>