<template>
    <div class="container p-0">
        <div v-if="authorized">
            <div class="row">
                <div class="col-auto bottom-y-axis bg-info"></div>
                <div class="col text-right">
                    <h1 class="header">Round: <span class="text-primary">{{game.round}}</span></h1>
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
                <div class="col bg-danger text-center text-uppercase ml-1 px-2" v-on:click="logoff">
                    Logoff
                </div>
            </div>
            <div class="row mt-1 mb-1">
                <div class="col-auto bottom bg-secondary"></div>
                <div class="col-3 bottom-x-axis bg-info ml-1"></div>
                <div class="col bg-info ml-1 text-right">{{player.character.name}}</div>
            </div>
            <div v-if="status !== 4">
                <router-view :game="game" :player="player"></router-view>
            </div>
            <div v-else>
                <div class="divider p-5">
                    <div class="cell left">&nbsp;</div>
                    <div class="cell caption">Game Paused</div>
                    <div class="cell right"></div>
                    <div class="cell fill">&nbsp;</div>
                </div>
            </div>
        </div>
        <div v-else>
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
                <input id="password" class="form-control form-control-sm" readonly :value="password" />
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
    </div>
</template>

<style>
    body {
        text-transform: uppercase;
    }

    .container {
        color: #FFCC66;
        font-family: 'Helvetica Ultra Compressed', 'Swiss911BT-UltraCompressed', 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        padding: 1rem;
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

<script>
    import Axios from 'axios';
    //import saveState from 'vue-save-state';

    export default {
        data() {
            return {
                authorized: false,
                game: null,
                games: null,
                player: null,
                status: {
                    complete: null,
                    notFound: null
                },
                password: '',
                invalid: false,
                selectUsername: false,
                playerId: null,
                round: 0
            }
        },
        //mixins: [saveState],
        beforeMount: function () {
            if (!this.game)
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
                        this.games = null;
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
            },
            authorized: function (val) {
                if (val) setInterval(this.refreshGame, 1000);
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
            },
            logoff: function () {
                this.game = null;
                this.player = null;
                this.authorized = null;
                this.loadGames();
            },
            refreshGame: function () {
                let uri = ['/api/game', this.game.gameId].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.game = response.data;
                            if (this.round !== this.game.round) {
                                this.round = this.game.round;
                            }
                            if (this.status !== this.game.status) {
                                this.status = this.game.status;
                            }
                        }
                    })
                    .catch(error => { console.log(error); });
            }
            /*getSaveStateConfig() {
                return {
                    'cacheKey': 'App',
                };
            }, */
        }
    }
</script>