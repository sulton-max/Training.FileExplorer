<template>

    <div>

        <!-- Explorer title -->
        <div class="p-5">
            <h2 class="text-slate-300 text-xl font-rubik">File Explorer</h2>
        </div>

        <actions-divider/>

        <!-- Files statistics -->
        <div class="p-5">

            <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
                <img src="../../../assets/icons/document.svg" alt="Document icon" class="w-6 h-6">
                Documents
            </div>

            <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
                <img src="../../../assets/icons/image.svg" alt="Document icon" class="w-6 h-6">
                Images
            </div>

            <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
                <img src="../../../assets/icons/vscode.svg" alt="Document icon" class="w-6 h-6">
                Source code files
            </div>

            <div class="p-2 flex text-slate-300 items-center justify-start gap-2">
                <img src="../../../assets/icons/template.svg" alt="Document icon" class="w-6 h-6">
                Other files
            </div>

        </div>

    </div>

</template>

<script setup lang="ts">

import ActionsDivider from "@/modules/explorerActions/components/ActionsDivider.vue";
</script>