import './scss/fonts.scss';
import './scss/lcar.scss';
import 'normalize.css';
//import './scss/lcar-strapless.scss';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import App from './App.vue';

import Drone from './components/Drone.vue';
import Home from './components/Home.vue';
import Location from './components/Location.vue';
import Login from './components/Login.vue';
import Ship from './components/Ship.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/drone', component: Drone },
    { path: '/location', component: Location },
    { path: '/login', component: Login },
    { path: '/ship', component: Ship, props: { userId: 200 } }
];

const router = new VueRouter({
    mode: 'history',
    linkActiveClass: 'text-white',
    routes
});

const vm = new Vue({
    el: '#app',
    router,
    render: h => h(App)
});

