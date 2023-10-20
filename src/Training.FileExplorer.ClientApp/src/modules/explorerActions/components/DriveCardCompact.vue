<template>

    <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
        <img src="../../../assets/icons/document.svg" alt="Document icon" class="w-6 h-6">
        <h5 class="font-normal">
            {{drive.name}} <span class="text-slate-400 ml-10">{{ getFileSizeString(drive.totalSpace) }}</span>
        </h5>
    </div>

<!--  <div class="transparent-shadow-on card-round" @click="emit('onFetchDriveEntries', drive.path)">-->

<!--    <div class="p-2 px-4 flex flex-col items-center justify-center">-->

<!--      &lt;!&ndash; Drive header &ndash;&gt;-->
<!--      <div class="relative">-->
<!--        <img src="../../../assets/icons/folder-admin.svg" alt="Drive icon" class="grid-icon">-->
<!--        <h5 class="absolute top-1/2 left-1/3 transform -translate-x-1/2 -translate-y-1/2 text-slate-300">-->
<!--          {{ drive.name }}</h5>-->
<!--      </div>-->

<!--      &lt;!&ndash; Drive Details &ndash;&gt;-->
<!--      <div class="w-full h-full">-->

<!--        &lt;!&ndash; Drive space chart &ndash;&gt;-->
<!--        <canvas ref="chart" width="200" height="200"></canvas>-->

<!--        &lt;!&ndash; Drive space details &ndash;&gt;-->
<!--        <p>Name : {{ drive.name }}</p>-->
<!--        <p v-if="drive.usedSpace > 0">Used space : {{ drive.usedSpace }}</p>-->
<!--        <p v-if="drive.freeSpace > 0">Free space : {{ drive.freeSpace }}</p>-->
<!--        <p v-if="drive.unavailableSpace > 0">Unavailable space : {{ drive.unavailableSpace }}</p>-->
<!--        <p>Drive type : {{ drive.type }}</p>-->
<!--      </div>-->

<!--    </div>-->

<!--  </div>-->

</template>

<script lang="ts" setup>

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

const getFileSizeString = (fileSizeInBytes: number): string => {
    const byteConversion = 1024;
    let bytes = fileSizeInBytes;

    if (bytes >= Math.pow(byteConversion, 4)) { // Terabytes
        return `${(bytes / Math.pow(byteConversion, 4)).toFixed(2)} TB`;
    } else if (bytes >= Math.pow(byteConversion, 3)) { // Gigabytes
        return `${(bytes / Math.pow(byteConversion, 3)).toFixed(2)} GB`;
    } else if (bytes >= Math.pow(byteConversion, 2)) { // Megabytes
        return `${(bytes / Math.pow(byteConversion, 2)).toFixed(2)} MB`;
    } else if (bytes >= byteConversion) { // Kilobytes
        return `${(bytes / byteConversion).toFixed(2)} KB`;
    } else { // Bytes
        return `${bytes.toFixed(2)} Bytes`;
    }
}



</script>