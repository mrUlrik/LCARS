<template>
    <div class="container">
        <div class="row">
            <div class="col-auto lcars-dn"></div>
            <div class="col lcars-content text-right">Welcome Crew Member Will</div>
        </div>
        <div class="row">
            <div class="col-auto lcars-dn"></div>
            <div class="col-auto lcars-caption">Content</div>
            <div class="col lcars-fill"></div>
            <div class="col-auto lcars-rt"></div>
        </div>
        <div class="row">
            <div class="col lcars-divider"></div>
        </div>
        <div class="row">
            <div class="col-auto lcars-dn"></div>
            <div class="col-auto lcars-caption">Content</div>
            <div class="col lcars-fill"></div>
            <div class="col-auto lcars-rt"></div>
        </div>
        <div class="row">
            <div class="col-auto lcars lcars-dn bg-normal"></div>
            <div class="col-auto lcars-content">Welcome Crew Member Will</div>
        </div>
        <div class="row">
            <div class="col lcars-divider"></div>
        </div>
        <div class="row">
            <div class="col-auto lcars-dn ">Info</div>
            <div class="col-auto lcars-content">Data</div>
        </div>
    </div>
</template>

<style scoped>

    .lcars.bg-alert {
        background-color: #ff0000;
    }

    .lcars.bg-normal {
        background-color: #00ff21;
    }

    .lcars-dn {
        width: 150px;
    }

    .lcars-rt {
        width: 15px;
        border-radius: 0 1.6rem 1.6rem 0;
    }

    .lcars-fill {
        margin-right: 15px;
    }

    .lcars-caption {
        line-height: 1.6rem;
        text-transform: uppercase;
    }

    .lcars-divider {
        height: 15px;
    }

    .lcars-content {

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