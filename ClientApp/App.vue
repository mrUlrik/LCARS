<template>
    <div class="container">
        <div class="row">
            <div class="col-auto bottom-y-axis bg-info"></div>
            <div class="col text-right">
                <h1 class="header">ACTION: <span class="text-primary">Turbolift</span></h1>
            </div>
        </div>
        <div class="row mt-1">
            <div class="col-auto bottom-y-axis bg-secondary"></div>
            <div class="col"></div>
            <div class="col-auto left-bumper"></div>
            <div class="col bg-secondary text-center text-uppercase ml-1 px-2">
                <router-link to="/location">Action</router-link>
            </div>
            <div class="col bg-secondary text-center text-uppercase ml-1 px-2">
                <router-link to="/">Status</router-link>
            </div>
            <div class="col bg-danger text-center text-uppercase ml-1 px-2">
                Logoff
            </div>
        </div>
        <div class="row mt-1 mb-1">
            <div class="col-auto bottom bg-secondary"></div>
            <div class="col-3 bottom-x-axis bg-info ml-1"></div>
            <div class="col bg-info ml-1 text-right">Orry Deason</div>
        </div>
        <router-view></router-view>
    </div>
</template>

<style>
    body {
        text-transform: uppercase;
    }
    a, a:active, a:hover {
        color: #fff;
        text-decoration: none;
    }

    .header {
        padding: 0;
        margin: 0;
        text-transform: uppercase;
        line-height: 2.0rem;
        font-size: 1.8rem;
    }

    .button {
        text-align: center;
        text-transform: uppercase;
        width: 100px;
    }

    .button-wide {
        text-align: center;
        text-transform: uppercase;
        width: 152px;
    }

    .bottom {
        background-image: url('images/bottom.png');
        background-repeat: no-repeat;
        background-size: cover;
        width: 100px;
        height: 38px;
    }

    .bottom-x-axis {
        margin-top: 24px;
    }

    .bottom-y-axis {
        width: 77px;
    }

    .top {
        background-image: url('images/top.png');
        background-repeat: no-repeat;
        background-size: cover;
        width: 100px;
        height: 38px;
    }

    .top-x-axis {
        height: 14px;
    }

    .top-y-axis {
        width: 77px;
    }

    .menu-option {
        color: #000;
        padding: 5px;
    }

    .left-bumper {
        background-color: #DD6644;
        border-radius: 1.6rem 0 0 1.6rem;
    }

    .right-bumper {
        background-color: #DD6644;
        border-radius: 0 1.6rem 1.6rem 0;
    }

    .fill {
        height: 100px;
    }

    .content {
        font-size: 1.2rem;
        line-height: 1.4rem;
    }

    ol {
        padding-left: 1rem;
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