<template>

    <div class="w-full p-2 flex text-slate-300 items-center justify-start gap-2">
        <img src="../../../assets/icons/document.svg" alt="Document icon" class="w-6 h-6">
        <div class="font-normal w-full flex justify-between">
            <span >{{drive.name}}</span>
            <span class="text-slate-400 ml-10">{{ explorerLocationService.getFileSizeString(drive.totalSpace) }}</span>
        </div>
    </div>

</template>

<script lang="ts" setup>

import { Chart, ChartItem, DoughnutController, ArcElement } from "chart.js";
import { onMounted, ref } from "vue";
import type { StorageDrive } from "@/infrastructure/models/entities/StorageDrive";
import { ExplorerLocationService } from "@/infrastructure/services/explorerLocationService";

const explorerLocationService = new ExplorerLocationService();

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