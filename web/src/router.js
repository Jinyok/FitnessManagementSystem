import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

/*example
const routes = [
    {
        path: '/coach',
        name: 'Coach',
        component: () => import ('./components/Coach/CoachView.vue'),
        children:[ // sub pages
            {
                path: 'home',
                name: 'CoachHome',
                component: CoachHome
            }
        ],
        beforeEnter: (to, from, next) => {
        // Check login status
            if haven't logined
                next ('/coach/login');
            else
                next ('/coach/home');
            next ();
        }
    },
    { 
        //other pages 
    }
];*/

const routes = [
    {
        path: '/coach',
        name: 'Coach',
        component: () => import ('./components/Coach/CoachView.vue'),
        children:[
            {
                path: 'home',
                name: 'CoachHome',
                component: () => import ('./components/Coach/CoachHome.vue')
            },
            {
                path: 'schedule',
                name: 'CoachSchedule',
                component: () => import ('./components/Coach/CoachSchedule.vue')
            },
            {
                path: 'courses',
                name: 'CoachCourses',
                component: () => import ('./components/Coach/CoachCourses.vue')
            },
            {
                path: 'section',
                name: 'CoachSection',
                component: () => import ('./components/Coach/CoachSection.vue')
            },
            {
                path: 'instruct',
                name: 'CoachInstruct',
                component: () => import ('./components/Coach/CoachInstruct.vue')
            },
            {
                path: 'instructdetail',
                name: 'CoachInstructDetail',
                component: () => import ('./components/Coach/CoachInstructDetail.vue')
            }
        ],
    },
    {
        path: '/coach/login',
        name: 'CoachLogin',
        component: () => import ('./components/Coach/CoachLogin.vue'),
    },
    {
        path: '/admin',
        name: 'Admin',
        component: () => import ('./components/Admin/AdminView.vue'),
    },
    {
        path: '/admin/login',
        name: 'AdminLogin',
        component: () => import ('./components/Admin/AdminLogin.vue'),
    },
    {
        path: '/manager',
        name: 'Manager',
        component: () => import ('./components/Manager/ManagerView.vue'),
    },
    {
        path: '/manager/login',
        name: 'ManagerLogin',
        component: () => import ('./components/Manager/ManagerLogin.vue'),
    },
    {
        path: '/reception',
        name: 'Reception',
        component: () => import ('./components/Reception/ReceptionView.vue'),
    },
    {
        path: '/reception/login',
        name: 'ReceptionLogin',
        component: () => import ('./components/Reception/ReceptionLogin.vue'),
    },
    {
        path: '/',
        redirect: '/coach'
    }
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;