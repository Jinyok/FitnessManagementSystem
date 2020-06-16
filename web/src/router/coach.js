import Vue from 'vue';
import VueRouter from 'vue-router';
import CoachView from '../components/Coach/CoachView.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'Coach',
        component: CoachView
    }
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;