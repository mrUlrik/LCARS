<template>
    <div>
        <div class="row mb-1">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-2 top-x-axis bg-info ml-1"></div>
            <div class="col top-x-axis bg-secondary ml-1"></div>
            <div class="col-3 top-x-axis bg-primary ml-1"></div>
        </div>
        <div v-if="completed">
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-secondary"></div>
                <div class="col text-center">
                    <h1 class="header">Complete</h1>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-danger"></div>
                <div class="col bg-danger ml-1 button-wide" v-on:click="complete()">Back</div>
            </div>
        </div>
        <div v-else>
            <div v-if="loaded === 1">
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-secondary"></div>
                    <div class="col text-center">
                        <h1 class="header">Turbolift</h1>
                        <h1 class="header"><span class="text-primary">Select Destination</span></h1>
                    </div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-warning ml-1 button" v-on:click="getActions(bridge.locationId)">{{bridge.abbreviated}}</div>
                    <div class="col bg-warning ml-1 button" v-on:click="getActions(communications.locationId)">{{communications.abbreviated}}</div>
                    <div class="col bg-warning ml-1 button" v-on:click="getActions(engineering.locationId)">{{engineering.abbreviated}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="getActions(medical.locationId)">{{medical.abbreviated}}</div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="getActions(science.locationId)">{{science.abbreviated}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-secondary ml-1 button-wide" v-on:click="getActions(logistics.locationId)">{{logistics.abbreviated}}</div>
                    <div class="col bg-secondary ml-1 button-wide" v-on:click="getActions(security.locationId)">{{security.abbreviated}}</div>
                </div>
            </div>
            <div v-else-if="loaded === 2">
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-secondary"></div>
                    <div class="col text-center">
                        <h1 class="header"><span class="text-primary">Perform an Action</span></h1>
                    </div>
                </div>
                <div v-for="action in actions" class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="getOptions(action.attributeId, action.variableType)">{{action.name}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-danger"></div>
                    <div class="col bg-danger ml-1 button-wide" v-on:click="loaded = 1">Back</div>
                </div>
            </div>
            <div v-else-if="loaded === 3">
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-secondary"></div>
                    <div class="col text-center">
                        <h1 class="header"><span class="text-primary">Select Recipient</span></h1>
                    </div>
                </div>
                <div v-for="option in options" class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="performAction(option)">{{option}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-danger"></div>
                    <div class="col bg-danger ml-1 button-wide" v-on:click="loaded = 1">Back</div>
                </div>
            </div>
            <div v-else>
                <div v-for="action in actions" class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-danger ml-1 button-wide">Loading data...</div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .button, .button-wide {
        cursor: pointer;
    }
</style>

<script>
    import Axios from 'axios';

    export default {
        data() {
            return {
                locationId: null,
                loaded: 0,
                locations: [
                    {
                        "locationId": 0,
                        "name": "",
                        "abbreviated": "",
                        "attributes": [
                            {
                                "attributeId": 0,
                                "name": "",
                                "abbreviated": "",
                                "skillId": 0,
                                "status": null
                            }
                        ],
                        "teleports": null
                    }
                ],
                actions: [
                    {
                        "attributeId": 0,
                        "name": "",
                        "abbreviated": "",
                        "skillId": 0,
                        "locationId": 0,
                        "variableType": 0,
                        "statuses": null,
                        "skill": null
                    }
                ],
                options: [],
                attributeId: 0,
                action: '',
                completed: false
            }
        },
        props: ['game', 'player'],
        beforeMount: function () {
            this.getLocationData();
        },
        computed: {
            bridge: function () {
                return this.locations.find(function (obj) { return obj.locationId === 1; })
            },
            communications: function () {
                return this.locations.find(function (obj) { return obj.locationId === 2; })
            },
            engineering: function () {
                return this.locations.find(function (obj) { return obj.locationId === 3; })
            },
            medical: function () {
                return this.locations.find(function (obj) { return obj.locationId === 4; })
            },
            science: function () {
                return this.locations.find(function (obj) { return obj.locationId === 5; })
            },
            security: function () {
                return this.locations.find(function (obj) { return obj.locationId === 6; })
            },
            logistics: function () {
                return this.locations.find(function (obj) { return obj.locationId === 7; })
            }
        },
        methods: {
            getLocationData: function () {
                let uri = ['/api/status/locations'].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.locations = response.data;
                            this.loaded = 1;
                        }
                    })
                    .catch(error => { console.log(error); });
            },
            getActions: function (locationId) {
                let uri = ['/api/actions/character', this.player.character.characterId, 'location', locationId].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.actions = response.data;
                            this.locationId = locationId;
                            this.loaded = 2;
                        }
                    })
                    .catch(error => { console.log(error); });
            },
            getOptions: function (id, type) {
                let uri = ['/api/actions', type].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.options = response.data;
                            this.loaded = 3;
                            this.attributeId = id;
                            if (response.data.length === 0)
                                this.performAction(null);
                        }
                    })
                    .catch(error => { console.log(error); });
            },
            performAction: function (on) {
                let uri = '/api/actions/perform';
                let payload = {
                    "playerId": this.player.playerId,
                    "gameId": this.game.gameId,
                    "round": this.game.round,
                    "locationId": this.locationId,
                    "attributeId": this.attributeId,
                    "on": on
                };
                Axios.post(uri, payload)
                    .then(response => {
                        if (response.data) {
                            this.completed = true;
                        }
                    })
                    .catch(error => { console.log(error); });
            },
            complete: function () {
                this.completed = false;
                this.locationId = null;
                this.attributeId = null;
                this.loaded = 1;
            }
        }
    }
</script>