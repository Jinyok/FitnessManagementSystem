import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
    {
        path: '/coach',
        name: 'Coach',
        component: () => import ('./components/Coach/CoachView.vue'),
        children:[ // sub pages
/* Example
            {
                path: '/home',
                name: 'CoachHome',
                component: CoachHome
            }
*/
        ],
        beforeEnter: (to, from, next) => {
/* Check login status
            if haven't logined
                next ('/coach/login');
            else
                next ('/coach/home');
*/
            next ();
        }
    },
    {
        path: '/coach/login',
        name: 'CoachLogin',
        component: () => import ('./components/Coach/CoachLogin.vue'),
    },
/* Other pages
    {
        path: '/reception',
        name: 'Reception',
        component: ReceptionView // Required import
    },
    // and so on
    {
        path: '/',
        name: 'Navigation',
        component: Navigation
    }
*/
];

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
});

export default router;