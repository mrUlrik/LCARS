<template>
    <div>
        <div class="row mb-1">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-3 top-x-axis bg-secondary ml-1"></div>
            <div class="col bg-primary ml-1 text-right">SECTOR Omicron</div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-info ml-1"><h1 class="header">Drone Status</h1></div>
        </div>

        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info">Status</div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/">Personal</router-link></div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/ship">Ship</router-link></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary fill"></div>
            <div class="col-4 ml-1"></div>
        </div>
    </div>
</template>

<style scoped>
    .value {
        text-align: right;
    }
</style>