<template>
    <div class="container">
        <select v-model="user.gameId">
            <option v-for="game in games" v-bind:value="game.gameId">{{game.name}}</option>
        </select>
        <div class="divider">
            <div class="cell left">&nbsp;</div>
            <div class="cell caption">Console 01</div>
            <div class="cell right"></div>
            <div class="cell fill">&nbsp;</div>

        </div>
        <div class="row pb-3">
            <div class="col"></div>
            <div class="col-5"><input type="text" class="form-control" /></div>
            <div class="col"></div>
        </div>
        <h1>{{user.gameId}}</h1>
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

<script>
    import Axios from 'axios';

    export default {
        data() {
            return {
                user: {
                    gameId: 0
                },
                games: [],
                status: {
                    complete: null,
                    notFound: null
                },
                errors: []
            }
        },
        beforeMount: function () {
            this.loadGames();
        },
        methods: {
            loadGames: function () {
                this.status.complete = false;
                let uri = '/api/game';
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.games = response.data;
                        }
                    })
                    .catch(error => { console.log(error); });
            }
        }
    }
</script>

<style scoped>
    .num {
        background-color: #DD6644;
    }

        .num.num-1 {
            border-radius: 0 0 0 1.6rem;
        }

        .num.num-3 {
            border-radius: 0 0 1.6rem 0;
        }

        .num.num-7 {
            border-radius: 1.6rem 0 0 0;
        }

        .num.num-9 {
            border-radius: 0 1.6rem 0 0;
        }

        .num.num-0 {
            border-radius: 0 0 1.6rem 1.6rem;
        }

    .divider {
        padding-bottom: 2rem;
    }

        .divider .cell {
            float: left;
            height: 1.6rem;
            line-height: 1.6rem;
        }

        .divider > .left {
            background-color: #CC99CC;
            border-radius: 1.6rem 0 0 1.6rem;
            margin-right: 10px;
            width: 25px;
        }

        .divider > .caption {
            font-size: 2rem;
            margin-right: 10px;
            text-transform: uppercase;
        }

        .divider > .fill {
            background-color: #DD6644;
            float: unset;
            overflow: hidden;
        }

        .divider > .right {
            background-color: #CC99CC;
            border-radius: 0 1.6rem 1.6rem 0;
            float: right;
            margin-left: 10px;
            width: 25px;
        }
</style>