<template>
    <div class="container">
        <div class="divider">
            <div class="cell left">&nbsp;</div>
            <div class="cell caption">Authorization</div>
            <div class="cell right"></div>
            <div class="cell fill">&nbsp;</div>
        </div>
        <div v-if="!game">
            <div class="row">
                <div class="col">&nbsp;</div>
                <div class="col-auto"><h1>Select Mission</h1></div>
                <div class="col">&nbsp;</div>
            </div>
            <div class="divider pb-4" v-for="game in games">
                <div class="cell left" style="background-color: #9999ff">&nbsp;</div>
                <div class="cell caption" v-on:click="storeGame(game)" style="cursor: pointer">{{game.name}}</div>
                <div class="cell right"></div>
                <div class="cell fill">&nbsp;</div>
            </div>
        </div>
        <div v-else-if="!authorized">
            <h1 class="text-center">Welcome Recruit</h1>
            <select class="custom-select custom-select-sm mb-3" v-model="playerId">
                <option v-for="player in game.players" v-bind:value="player.playerId">{{player.name}}</option>
            </select>
            <input id="password" class="form-control form-control-sm" :value="password" />
            <div class="row">
                <div class="col"></div>
                <div class="">
                    <div class="num num-7" v-on:click="addNumber('7')">7</div>
                    <div class="num num-4" v-on:click="addNumber('4')">4</div>
                    <div class="num num-1" v-on:click="addNumber('1')">1</div>
                </div>
                <div class="">
                    <div class="num num-8" v-on:click="addNumber('8')">8</div>
                    <div class="num num-5" v-on:click="addNumber('5')">5</div>
                    <div class="num num-2" v-on:click="addNumber('2')">2</div>
                    <div class="num num-0" v-on:click="addNumber('0')">0</div>
                </div>
                <div class="">
                    <div class="num num-9" v-on:click="addNumber('9')">9</div>
                    <div class="num num-6" v-on:click="addNumber('6')">6</div>
                    <div class="num num-3" v-on:click="addNumber('3')">3</div>
                    <div class="num num-clr" v-on:click="password = ''">CLR</div>
                </div>
                <div class="col"></div>
            </div>
            <div class="alert alert-danger p-1 m-3" v-if="invalid">You entered the incorrect pincode.</div>
            <div class="alert alert-warning p-1 m-3" v-if="selectUsername">Select your name.</div>
        </div>

    </div>
</template>

<script>
    import Axios from 'axios';

    export default {
        data() {
            return {
                authorized: false,
                player: null,
                game: null,
                games: [],
                status: {
                    complete: null,
                    notFound: null
                },
                password: '',
                errors: [],
                invalid: false,
                selectUsername: false,
                playerId: null
            }
        },
        beforeMount: function () {
            this.loadGames();
        },
        watch: {
            password: function (val) {
                if (!this.player || !this.player.character.password) {
                    this.selectUsername = true;
                    return;
                }
                if (val.length === 4) {
                    if (val === this.player.character.password) {
                        this.authorized = true;
                        this.$emit('authorized', '1');
                    } else {
                        this.invalid = true;
                    }
                } else {
                    this.invalid = false;
                }
            },
            playerId: function (val) {
                if (val === 0) {
                    this.selectUsername = true;
                } else {
                    this.player = this.game.players.find(this.selectPlayer);
                    this.selectUsername = false;
                }
            }
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
            },
            storeGame: function (game) {
                this.game = game;
            },
            storePlayer: function (player) {
                this.player = player;
            },
            addNumber: function (number) {
                if (this.player) {
                    if (this.password.length < 4)
                        this.password = this.password + number;
                }
                else this.selectUsername = true;
            },
            selectPlayer: function (player) {
                return player.playerId === this.playerId;
            }
        }
    }
</script>

<style scoped>
    .num {
        background-color: #DD6644;
        cursor: pointer;
        margin-top: 1rem;
        height: 3rem;
        line-height: 3rem;
        text-align: center;
        width: 3rem;
    }

        .num.num-1 {
            border-radius: 0 0 0 1.6rem;
            margin-right: 1rem;
        }

        .num.num-3 {
            
        }

        .num.num-7 {
            border-radius: 1.6rem 0 0 0;
        }

        .num.num-9 {
            border-radius: 0 1.6rem 0 0;
        }

        .num.num-0 {
            border-radius: 0 0 0 1.6rem;
            margin-right: 1rem;
        }

        .num.num-clr {
            border-radius: 0 0 1.6rem 0;
        }

    .divider {
        padding-bottom: 0rem;
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

    .button {
        border-radius: 1.6rem 1.6rem 1.6rem 1.6rem;
        cursor: pointer;
    }
</style>