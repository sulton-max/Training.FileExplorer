import { createRouter, createWebHistory } from 'vue-router'
import ExplorerView from "@/modules/explorerContainer/views/ExplorerView.vue";
import LockView from "@/common/views/LockView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: LockView
        },
        {
            path: '/explorer',
            name: 'explorer',
            component: ExplorerView
        }
    ]
})

export default router
