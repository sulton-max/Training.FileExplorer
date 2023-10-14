import { createRouter, createWebHistory } from 'vue-router'
import HomeView from "@/views/HomeView.vue";
import ExplorerView from "@/modules/explorerContainer/views/ExplorerView.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView
        },
        {
            path: '/explorer',
            name: 'explorer',
            component: ExplorerView
        }
    ]
})

export default router
