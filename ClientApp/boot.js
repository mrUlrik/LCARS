import './scss/fonts.scss';
import './scss/lcar.scss';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

import App from './App.vue';

import Home from './components/Home.vue';
import Login from './components/Login.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login }
];

const router = new VueRouter({
    mode: 'history',
    routes
});

const vm = new Vue({
    el: '#app',
    router,
    render: h => h(App)
});