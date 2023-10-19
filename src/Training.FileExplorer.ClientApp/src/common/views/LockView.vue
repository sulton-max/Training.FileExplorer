<template>

    <div class="relative h-full w-full">

        <!-- Lock screen background -->
        <img class="absolute top-0 left-0 z-0 h-screen w-full object-cover "
             src="../../assets/images/lock-screen-background.jpg" alt="Windows 11 lock screen background image">

        <!-- Lock screen content -->
        <div class="container-shadow h-full w-full flex flex-col items-center justify-center gap-8">

            <!-- Profile image -->
            <div class="flex flex-col items-center justify-center gap-6">

                <img src="../../assets/images/profile-picture.jpg" alt="Profile picture"
                     class="h-[200px] w-[200px] object-cover rounded-full ring-4 ring-gray-400">
                <h5 class="text-gray-400 font-bold text-3xl">Sultonbek Rakhimov</h5>

            </div>

            <!-- Credentials view -->
            <div>

                <input type="text" v-model="input"
                       class="bg-transparent transparent-shadow-on bg-black bg-opacity-50 border border-blue-800 hover:border-blue-500 focus:hover-blue-500 outline-none w-[280px] text-gray-400 p-2 rounded-md"
                       placeholder="PIN">

            </div>

        </div>

    </div>

</template>

<script setup lang="ts">

import { ref, watch } from "vue";
import { useRouter } from "vue-router";

const router = useRouter();
const input = ref<string>('');

watch(() => input.value, (value) => {
    if (value.length == 6) {
        router.push('explorer');
    }
});

</script>
