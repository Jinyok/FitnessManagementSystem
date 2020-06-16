import Vue from 'vue';
import VueRouter from 'vue-router';
import CoachLogin from '../components/Coach/CoachLogin.vue';
import CoachView from '../components/Coach/CoachView.vue';

Vue.use(VueRouter);

const routes = [
    {
        path: '/',
        name: 'CoachLogin',
        component: CoachLogin
    },
    {
        path: '/CoachView',
        name: 'CoachView',
        component: CoachView
    }
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;