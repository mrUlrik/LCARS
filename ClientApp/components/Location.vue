<template>
    <div>
        <div v-if="!locationId">
            <div class="row mb-1">
                <div class="col-auto top bg-secondary"></div>
                <div class="col-2 top-x-axis bg-info ml-1"></div>
                <div class="col top-x-axis bg-secondary ml-1"></div>
                <div class="col-3 top-x-axis bg-primary ml-1"></div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-secondary"></div>
                <div class="col text-center">
                    <h1 class="header">Turbolift</h1>
                    <h1 class="header"><span class="text-primary">Select Destination</span></h1>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-info"></div>
                <div class="col bg-warning ml-1 button">Bridge</div>
                <div class="col bg-warning ml-1 button">Comms</div>
                <div class="col bg-warning ml-1 button">Engineer</div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-info"></div>
                <div class="col bg-success ml-1 button-wide">Medical</div>
                <div class="col bg-success ml-1 button-wide">Science</div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-info"></div>
                <div class="col bg-secondary ml-1 button-wide">Logistics</div>
                <div class="col bg-secondary ml-1 button-wide">Security</div>
            </div>
        </div>
        
    </div>
</template>

<style scoped>
    .button, .button-wide {
        cursor: pointer;
    }
</style>

<script>
    export default {
        data() {
            return {
                locationId: null
            }
        }
    }
</script>