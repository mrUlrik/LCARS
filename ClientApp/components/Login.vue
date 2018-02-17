<template>
    <div class="container">
        <div v-for="game in games">
            <p>{{game}}</p>
        </div>
        <div class="frame">
            <div class="left accent"></div>
            <div class="caption">
                <div class="left">Console 01</div>
            </div>
            <div class="right accent"></div>
            <div class="fill"></div>
        </div>
        <div class="row pb-3">
            <div class="col"></div>
            <div class="col-5"><input type="text" class="form-control" /></div>
            <div class="col"></div>
        </div>
        <div class="row">
            <div class="col"></div>
            <div class="col-1 p-0">
                <div class="num num-7 text-center m-1 p-1 mb-2">7</div>
                <div class="num num-4 text-center m-1 p-1 mb-2">4</div>
                <div class="num num-1 text-center m-1 p-1 mb-2">1</div>
            </div>
            <div class="col-1 p-0">
                <div class="num num-8 text-center m-1 p-1 mb-2">8</div>
                <div class="num num-5 text-center m-1 p-1 mb-2">5</div>
                <div class="num num-2 text-center m-1 p-1 mb-2">2</div>
                <div class="num num-0 text-center m-1 p-1 mb-2">0</div>
            </div>
            <div class="col-1 p-0">
                <div class="num num-9 text-center m-1 p-1 mb-2">9</div>
                <div class="num num-6 text-center m-1 p-1 mb-2">6</div>
                <div class="num num-3 text-center m-1 p-1 mb-2">3</div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</template>

<style scoped>
    .keypad {
        background-color: #DD6644;
    }

    .num {
        background-color: #DD6644;
    }

        .num.num-1 { border-radius: 0 0 0 1.6rem; }
        .num.num-3 { border-radius: 0 0 1.6rem 0; }
        .num.num-7 { border-radius: 1.6rem 0 0 0; }
        .num.num-9 { border-radius: 0 1.6rem 0 0; }
        .num.num-0 { border-radius: 0 0 1.6rem 1.6rem; }
        
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
</script>