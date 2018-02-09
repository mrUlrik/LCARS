<template>
    <div>
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
            <div class="col bg-success ml-1 button">Medical</div>
            <div class="col bg-success ml-1 button">Science</div>
            <div class="col bg-success ml-1 button">Security</div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-secondary ml-1 button-wide">Logistics</div>
            <div class="col bg-secondary ml-1 button-wide">Bar</div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                hours: '',
                minutes: ''
            }
        },
        beforeMount() {
            this.updateDateTime();
        },
        mounted() {
            setInterval(this.updateDateTime, 1000);
        },
        methods: {
            updateDateTime() {
                let now = new Date();

                this.hours = this.getZeroPad(now.getHours());
                this.minutes = this.getZeroPad(now.getMinutes());
            },
            getZeroPad(n) {
                return (parseInt(n, 10) >= 10 ? '' : '0') + n;
            }
        }
    }
</script>