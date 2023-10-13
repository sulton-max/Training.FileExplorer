<template>

  <div class="">

    <!-- Drive header -->

    <img src="../assets/icons/folder-admin.svg" alt="Drive icon" class="h-20 w-20">

    <h5>{{ drive.name }}</h5>

    <p class="text-white">hiiiii</p>

  </div>

</template>

<script lang="ts" setup>

import type { DriveInfo } from "@/models/entities/DriveInfo";

const props = defineProps({
  drive: {
    type: Object as () => DriveInfo,
    required: true
  }
});

</script>