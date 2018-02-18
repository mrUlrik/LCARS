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
import Ship from './components/Ship.vue';

const routes = [
    { path: '/', component: Home, props: true },
    { path: '/drone', component: Drone, props: true },
    { path: '/location', component: Location, props: true },
    { path: '/ship', component: Ship, props: true }
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