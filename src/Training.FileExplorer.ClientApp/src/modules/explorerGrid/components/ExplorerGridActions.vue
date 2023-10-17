<template>

    <div class="flex">

        <!-- Primary actions -->
        <div>
            <!-- Breadcrumb -->
            <div class="flex">
            </div>

        </div>

        <!-- Secondary actions -->
        <div>

            <!-- Search bar -->

            <!-- Extra actions -->

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