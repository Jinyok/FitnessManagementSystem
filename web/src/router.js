import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

/*example
const routes = [
    {
        path: '/coach',
        name: 'Coach',
        component: () => import ('./components/Coach/CoachView.vue'),
        meta: {
            title: 'PageTitle'
        },
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
        path: '/manager',
        name: 'Manager',
        component: () => import ('./components/Manager/ManagerView.vue'),
        meta: {
            title: '人事 - 健身管理系统'
        },
        children: [
            {
                path: 'coach',
                name: 'ManagerCoach',
                component: () => import ('./components/Manager/ManagerCoach.vue'),
            },
            {
                path: 'coach/:id',
                name: 'ManagerCoachDetails',
                component: () => import ('./components/Manager/ManagerCoachDetails.vue'),
            },
            {
                path: 'course',
                name: 'ManagerCourse',
                component: () => import ('./components/Manager/ManagerCourse.vue'),
            },
            {
                path: 'course/:id',
                name: 'ManagerCourseDetails',
                component: () => import ('./components/Manager/ManagerCourseDetails.vue'),
            },
        ],
        beforeEnter: (to, from, next) => {
            // check login
            if (to.path == '/manager')
                next ('/manager/coach');
            else
                next ();
        }
    },
    {
        path: '/manager/login',
        name: 'ManagerLogin',
        component: () => import ('./components/Manager/ManagerLogin.vue'),
    },
    {
        path: '/admin',
        name: 'Admin',
        component: () => import ('./components/Admin/AdminView.vue'),
        children: [
            {
                path: 'users',
                name: 'AdminUsers',
                component: () => import ('./components/Admin/AdminUsers.vue')
            },
            {
                path: 'register',
                name: 'AdminRegister',
                component: () => import ('./components/Admin/AdminRegister.vue')
            },
            {
                path: 'usersdetail',
                name: 'AdminUsersDetail',
                component: () => import ('./components/Admin/AdminUsersDetail.vue')
            },
        ]
    },
    {
        path: '/admin/login',
        name: 'AdminLogin',
        component: () => import ('./components/Admin/AdminLogin.vue'),
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