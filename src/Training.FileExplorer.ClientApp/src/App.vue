<template>

    <div class="w-screen h-screen">
        <RouterView/>
    </div>

</template>

<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import { useExplorerStore } from "@/common/stores/ExplorerStore";
import { ExplorerApiClient } from "@/infrastructure/apiClients/ExplorerApiClient";
import { onBeforeMount } from "vue";

</script>
