<template>
    <div class="container-fluid">
        <div class="row p-2">
            <div class="col-auto lcars-border left accent"></div>
            <div class="col-auto lcars-border title"><span class="">USS Raven - Database 63-528</span></div>
            <div class="col lcars-border fill"></div>
            <div class="col-auto lcars-border right accent"></div>
        </div>
        <div class="row">
            <div class="col-auto"></div>
            <div class="col">
                <h1 class="h1">Hansen Diary</h1>
                <p>I don't know how to answer her question. I returned to the Bridge, where Erin explained to us her situation. The Bary Carter was still processing, heading directly for us. We confused our camera man then Mi-Chess phoned, hanging to glitch the Raven and pyramid a direct conforntation in space. As weapons power has been re-routed to the engines. Even now as I record these words, the plan is best laid twenty minutes away. The Cube is closing in. We're going to escape in reshort masony on best time, maybe we can buy a few minutes, long enouhg to reach the tmosphere and force the Collection to recalcuate, They're only a small ship, through body order. Surely I'd knot him then to continue - if the crew all assimilations is on away mission and persail so loud the surface of a photon.</p>
            </div>
            <div class="col-auto"></div>
        </div>
        <div class="row p-2">
            <div class="col-auto lcars-border left accent"></div>
            <div class="col lcars-border fill"></div>
            <div class="col-auto lcars-border title"><span class="">Systems Data 21-0071</span></div>
            <div class="col-auto lcars-border right accent"></div>
        </div>
    </div>
</template>

<style scoped>
    h1 {
        color: #DD6644;
    }

    p {
        color: #CC99CC;
        line-height: 1.6rem;
    }

    .lcars-border {
        background-color: #DD6644;
        height: 1.6rem;
        margin-left: .4rem;
    }

    .lcars-border.left {
        border-radius: 1.6rem 0 0 1.6rem;
        margin-left: 0;
    }

    .lcars-border.right {
        border-radius: 0 1.6rem 1.6rem 0;
        height: 1.6rem;
    }

        .lcars-border.accent {
            background-color: #CC99CC;
        }

        .lcars-border.title {
            color: #FFCC66;
            background-color: transparent;
            line-height: 1.6rem;
            font-size: 2.0rem;
            padding: 0;
        }

    .lcars-border.fill {
        border-radius: 0;
        height: 1.6rem;
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