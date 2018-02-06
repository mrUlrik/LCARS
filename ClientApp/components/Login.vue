<template>
    <div class="container-fluid d-flex h-100 flex-column" style="background-color: #FFF">

        <div class="row bg-faded fill d-flex justify-content-start">
            <div class="col portlet-container portlet-dropzone">
                <img src="images/ufop.png" height="300" />
                <div class="display-1">The LCARS Computer Network</div>
                <div class="h1">Authorized Access Only</div>
                <div class="h1">Please report malfunctions to engineering staff on duty</div>
            </div>
        </div>

    </div>
</template>

<style scoped>
    .display-1 {
        color: #FF9900;
    }

    .h1 {
        color: #9999CD;
    }

    .lcars-border {
        background-color: #9999CD;
        height: 1.5rem;
        margin-left: .3rem;
    }

    .lcars-border.left {
        border-radius: 1.5rem 0 0 1.5rem;
        margin-left: 0;
    }

    .lcars-border.right {
        border-radius: 0 1.5rem 1.5rem 0;
        height: 1.5rem;
    }

        .lcars-border.accent {
            background-color: #FF9900;
        }

        .lcars-border.title {
            color: #FF9900;
            background-color: transparent;
            line-height: 1.5rem;
            font-size: 1.9rem;
            padding: 0;
        }

    .lcars-border.fill {
        border-radius: 0;
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