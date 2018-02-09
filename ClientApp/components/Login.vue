<template>
    <div class="container">
        <div class="frame">
            <div class="left accent"></div>
            <div class="caption">
                <div class="left">Console 01</div>
            </div>
            <div class="right accent"></div>
            <div class="fill"></div>
        </div>
    </div>
</template>

<style scoped>
    .container {
        color: #FFCC66;
        font-family: 'Helvetica Ultra Compressed', 'Swiss911BT-UltraCompressed', 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        padding: 1rem;
    }

    h1 {
        font-weight: normal;
        text-transform: uppercase;
        margin-bottom: 0;
        padding-bottom: 0;
    }

    p {
        font-size: 1.2rem;
        line-height: 1.6rem;
    }

    .content {
        padding-left: 35px;
        padding-right: 35px;
    }

    .frame {
        overflow: hidden;
        height: 1.6rem;
        line-height: 1.6rem;
    }

        .frame > .left {
            background-color: #DD6644;
            border-radius: 1.6rem 0 0 1.6rem;
            float: left;
            height: inherit;
            width: 25px;
            margin-right: 10px;
        }

            .frame > .left.accent {
                background-color: #CC99CC;
            }

        .frame > .right {
            background-color: #DD6644;
            border-radius: 0 1.6rem 1.6rem 0;
            float: right;
            height: inherit;
            width: 25px;
            margin-left: 10px;
        }

            .frame > .right.accent {
                background-color: #CC99CC;
            }

        .frame > .caption {
            text-transform: uppercase;
            font-size: 2rem;
        }

            .frame > .caption > .left {
                float: left;
                margin-right: 10px;
            }

            .frame > .caption > .right {
                float: right;
                margin-left: 10px;
            }

        .frame > .fill {
            overflow: hidden;
            height: inherit;
            background-color: #DD6644;
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