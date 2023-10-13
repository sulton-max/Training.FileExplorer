<template>
  <p>{{text}}</p>
</template>

<script setup lang="ts">

const props = defineProps({
  text: {
    type: String,
    required: true
  }
});

</script>