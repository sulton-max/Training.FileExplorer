<template>

  <grid-item-card @click="emit('onFetchDriveEntries', drive.label)">

    <div class="p-2 px-4 flex flex-col items-center justify-center">

      <!-- Drive header -->
      <div class="relative">
        <img src="../../../assets/icons/folder-admin.svg" alt="Drive icon" class="grid-icon">
        <h5 class="absolute top-1/2 left-1/3 transform -translate-x-1/2 -translate-y-1/2 text-slate-300">
          {{ drive.name }}</h5>
      </div>

      <!-- Drive Details -->
      <div class="w-full h-full">

        <!-- Drive space chart -->
        <canvas ref="chart" width="200" height="200"></canvas>

        <!-- Drive space details -->
        <p>Name : {{ drive.name }}</p>
        <p v-if="drive.usedSpace > 0">Used space : {{ drive.usedSpace }}</p>
        <p v-if="drive.freeSpace > 0">Free space : {{ drive.freeSpace }}</p>
        <p v-if="drive.unavailableSpace > 0">Unavailable space : {{ drive.unavailableSpace }}</p>
        <p>Drive type : {{ drive.type }}</p>
      </div>

    </div>

  </grid-item-card>

</template>

<script lang="ts" setup>

import GridItemCard from "@/components/GridItemCard.vue";
import { Chart, ChartItem, DoughnutController, ArcElement } from "chart.js";
import { onMounted, ref } from "vue";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";

const props = defineProps({
  drive: {
    type: Object as () => StorageDrive,
    required: true
  }
});

const emit = defineEmits<{
  onFetchDriveEntries: [driveName: string]
}>();

Chart.register(ArcElement);
Chart.register(DoughnutController);

const chart = ref<ChartItem>();

const chartData = {
  // Chart data goes here
};
const chartOptions = {
  // Chart options go here
};

onMounted(() => {
  renderChart();
})

const renderChart = () => {
  const test = new Chart(chart.value as ChartItem, {
    type: 'doughnut',
    data: data,
  });
}

const data = {
  labels: ['Red', 'Orange', 'Yellow', 'Green', 'Blue'],
  datasets: [
    {
      label: 'Dataset 1',
      data: [props.drive?.usedSpace, props.drive.freeSpace, props.drive?.unavailableSpace],
      backgroundColor: ['#629555', '#0475c9', '#5a5d61'],
      hoverOffset: 4,
      borderWidth: 0
    }
  ]
};



</script>