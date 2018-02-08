<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-auto bottom-y-axis bg-secondary"></div>
            <div class="col text-right">
                <h1 class="header">Current Action <span class="text-primary">Bridge</span></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-auto bottom bg-secondary"></div>
            <div class="col-2 bottom-x-axis bg-info"></div>
            <div class="col bottom-x-axis bg-secondary"></div>
            <div class="col-3 bottom-x-axis bg-primary"></div>
        </div>
        <hr />
        <div class="row">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-2 top-x-axis bg-info"></div>
            <div class="col top-x-axis bg-secondary"></div>
            <div class="col-3 top-x-axis bg-primary"></div>
        </div>
        <div class="row">
            <div class="col-auto top-y-axis bg-secondary"></div>
            <div class="col text-center">
                <h1 class="header">Crew <span class="text-primary">Will Branch</span></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-auto top-y-axis bg-secondary">
                    Personal
            </div>
            <div class="col text-center">
                <h1 class="header">Crew <span class="text-primary">Will Branch</span></h1>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .header {
        padding: 0;
        margin: 0;
        text-transform: uppercase;
    }

    .bottom {
        background-image: url('../images/bottom.png');
        background-repeat: no-repeat;
        background-size: cover;
        width: 100px;
        height: 38px;
    }

    .bottom-x-axis {
        margin-top: 24px;
        margin-left: 5px;
    }

    .bottom-y-axis {
        width: 77px;
        margin-bottom: 5px;
    }

    .top {
        background-image: url('../images/top.png');
        background-repeat: no-repeat;
        background-size: cover;
        width: 100px;
        height: 38px;
    }

    .top-x-axis {
        height: 14px;
        margin-left: 5px;
    }

    .top-y-axis {
        width: 77px;
        margin-top: 5px;
        vertical-align: text-bottom;
    }

    .menu-option {
        color: #000;
        padding: 5px;
    }


</style>

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