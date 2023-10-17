<template>

    <div class="h-[60px] w-full flex justify-between items-center px-5">

        <!-- Primary actions -->
        <div>
            <!-- Breadcrumb -->
            <div class="flex">
            </div>

        </div>

        <!-- Secondary actions -->
        <div class="flex gap-5">

            <!-- Search bar -->
            <div class="flex relative">
                <i class="fas fa-search text-slate-200 absolute top-1/2 left-[5%] transform -translate-y-1/2 "></i>
                <input type="text"
                       class="border h-[40px] border-blue-500 rounded-xl p-2 px-4 pl-10 transparent-shadow-on bg-transparent outline-none focus:border-blue-400 text-slate-200 " placeholder="Search">
            </div>

            <!-- Extra actions -->
            <div>

                <button class="rounded-xl h-[40px] flex items-center justify-center gap-4 px-4 bg-blue-600 text-white">
                    <i class="fas fa-plus"></i>
                    Create folder
                </button>

            </div>

        </div>

    </div>

</template>

<script setup lang="ts">

import { useExplorerStore } from "@/common/stores/ExplorerStore";
import { computed, onMounted } from "vue";

const explorerStore = useExplorerStore();

onMounted(() => {
    console.log('getting breadcrumbs');
    const test = getBreadCrumbElements.value;
    console.log('test', test);
});

const getBreadCrumbElements = computed(() => {
    const parts = explorerStore.path.split('/');
    const breadcrumbs = Array<{ text: string, path: string }>();
    let foundRootPath = false;

    for (let i = 0; i < parts.length; i++) {
        const part = parts[i];

        if (part === '')
            continue;

        if (part === 'wwwroot')
            foundRootPath = true;

        let text = part;
        let path = parts.slice(0, i + 1).join('/');

        if (part === 'wwwroot') {
            text = 'Explorer Root'
            path = path.replace('wwwroot', 'Explorer Root')
        }

        const breadcrumb = {
            text,
            path
        }

        breadcrumbs.push(breadcrumb);
    }

    console.log(breadcrumbs);

    return breadcrumbs;
});

</script>