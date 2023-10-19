<template>

    <div class="relative h-full w-full flex items-center justify-center">

        <!-- Desktop screen background -->
        <img class="absolute top-0 left-0 z-0 h-screen object-cover w-full"
             src="../../../assets/images/desktop-background.jpg" alt="Windows 11 desktop screen background image">

        <!-- Explorer view and grid -->
        <explorer-container class="z-20 pos"/>

    </div>

</template>

<script setup lang="ts">

import ExplorerContainer from "@/modules/explorerContainer/components/ExplorerContainer.vue";

</script>