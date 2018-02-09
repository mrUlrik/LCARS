import './scss/fonts.scss';
import './scss/lcar.scss';
import 'normalize.css';
//import './scss/lcar-strapless.scss';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import App from './App.vue';

import Home from './components/Home.vue';
import Login from './components/Login.vue';
import Location from './components/Location.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },
    { path: '/location', component: Location }
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