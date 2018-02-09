<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-auto bottom-y-axis bg-info"></div>
            <div class="col text-right">
                <h1 class="header">Location <span class="text-primary">Turbolift</span></h1>
            </div>
        </div>
        <div class="row mt-1">
            <div class="col-auto bottom-y-axis bg-secondary"></div>
            <div class="col"></div>
            <div class="col-auto left-bumper"></div>
            <div class="col-auto bg-secondary text-right text-uppercase ml-1">
                Actions
            </div>
            <div class="col-auto bg-secondary text-right text-uppercase ml-1">
                Status
            </div>
            <div class="col-auto bg-secondary text-right text-uppercase ml-1">
                Log Off
            </div>
        </div>
        <div class="row">
            <div class="col-auto bottom-y-axis bg-secondary"></div>
            <div class="col text-right">
                <h5 class="header">Welcome <span class="text-primary">Will Branch</span></h5>
            </div>
        </div>
        <div class="row mt-1">
            <div class="col-auto bottom bg-secondary"></div>
            <div class="col-2 bottom-x-axis bg-info ml-1"></div>
            <div class="col bottom-x-axis bg-secondary ml-1"></div>
            <div class="col-3 bottom-x-axis bg-primary ml-1"></div>
        </div>
        <hr />
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
            <div class="col-auto bg-warning ml-1 button">Bridge</div>
            <div class="col-auto bg-warning ml-1 button">Comms</div>
            <div class="col-auto bg-warning ml-1 button">Engineer</div>
            <div class="col-auto bg-info ml-1 right-bumper"></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col-auto bg-success ml-1 button">Medical</div>
            <div class="col-auto bg-success ml-1 button">Science</div>
            <div class="col-auto bg-success ml-1 button">Security</div>
            <div class="col-auto bg-info ml-1 right-bumper"></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col-auto bg-secondary ml-1 button-wide">Logistics</div>
            <div class="col-auto bg-secondary ml-1 button-wide">Bar</div>
            <div class="col-auto bg-info ml-1 right-bumper"></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary fill"><br/><br/></div>
        </div>
    </div>
</template>

<style scoped>
    .header {
        padding: 0;
        margin: 0;
        text-transform: uppercase;
        line-height: 3.0rem;
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
        background-image: url('../images/bottom.png');
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
        background-image: url('../images/top.png');
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
        vertical-align: text-bottom;
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