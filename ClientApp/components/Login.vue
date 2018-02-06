<template>
    <div class="text-center">
        <div class="row py-5">
            <div class="col-auto border-left"></div>
            <div class="col-auto border-title">Console 01</div>
            <div class="col border-fill"></div>
            <div class="col-auto border-right-accent"></div>
        </div>
        <img src="images/United_Federation_of_Planets_002_by_Scharfshutze.jpg" height="300" />
        <div class="display-1">The LCARS Computer Network</div>
        <div class="h1">Authorized Access Only</div>
        <div class="h1">Please report malfunctions to engineering staff on duty</div>
        <div class="row py-5">
            <div class="col-auto border-left-accent"></div>
            <div class="col border-fill"></div>
            <div class="col-auto border-title">{{hours}}:{{minutes}}</div>
            <div class="col-auto border-right-accent"></div>
        </div>
    </div>
</template>

<style scoped>
    .display-1 {
        color: #FF9900;
    }

    .h1 {
        color: #9999CC;
    }

    .border-left {
        background-color: #9999CC;
        border-radius: 1.5rem 0 0 1.5rem;
        height: 1.5rem;
    }

    .border-left-accent {
        background-color: #FF9900;
        border-radius: 1.5rem 0 0 1.5rem;
        height: 1.5rem;
    }

    .border-title {
        color: #FF9900;
        line-height: 1.5rem;
        font-size: 1.9rem;
        padding: 0;
        margin-left: 1rem;
        margin-right: 1rem;
    }

    .border-fill {
        background-color: #9999CC;
        border-radius: 0;
        height: 1.5rem;
        margin-left: 1rem;
        margin-right: 1rem;
    }

    .border-right-accent {
        background-color: #FF9900;
        border-radius: 0 1.5rem 1.5rem 0;
        height: 1.5rem;
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