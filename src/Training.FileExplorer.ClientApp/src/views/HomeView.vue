<template>

  <header>
    <p class="text-slate-400 font-roboto text-3xl">File explorer</p>
  </header>

  <article>
    <explorer-grid>/</explorer-grid>
  </article>

</template>

<script setup lang="ts">
import TheWelcome from '../components/TheWelcome.vue'
import ExplorerGrid from "@/components/ExplorerGrid.vue";
</script>
