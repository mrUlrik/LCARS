<template>
    <div>
        <div v-if="loaded">
            <div v-if="!locationName">
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
                    <div class="col bg-warning ml-1 button" v-on:click="locationId = bridge.locationId">{{bridge.name}}</div>
                    <div class="col bg-warning ml-1 button" v-on:click="locationId = communications.locationId">{{communications.name}}</div>
                    <div class="col bg-warning ml-1 button" v-on:click="locationId = engineering.locationId">{{engineering.name}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-info"></div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="locationId = medical.locationId">{{medical.name}}</div>
                    <div class="col bg-success ml-1 button-wide" v-on:click="locationId = science.locationId">{{science.name}}</div>
                </div>
                <div class="row mb-1">
                    <div class="col-auto top-y-axis bg-info" v-on:click="locationId = logistics.locationId"></div>
                    <div class="col bg-secondary ml-1 button-wide" v-on:click="locationId = logistics.locationId">{{logistics.name}}</div>
                    <div class="col bg-secondary ml-1 button-wide" v-on:click="locationId = security.locationId">{{security.name}}</div>
                </div>
            </div>
            <div v-if="locationName">

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
                loaded: false,
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
                actions: {
                    "character": {
                        "characterId": player.character.characterId
                    },
                    "location": {
                        "locationId": null;
                    }
                }
            }
        },
        props: ['game', 'player'],
        beforeMount: function () {
            setInterval(this.getLocationData, 1000);
        },
        computed: {
            bridge: function () {
                return this.locations.find(function (obj) { return obj.name === 'Bridge'; })
            },
            communications: function () {
                return this.locations.find(function (obj) { return obj.name === 'Communications'; })
            },
            engineering: function () {
                return this.locations.find(function (obj) { return obj.name === 'Engineering Bay'; })
            },
            medical: function () {
                return this.locations.find(function (obj) { return obj.name === 'Medical Bay'; })
            },
            science: function () {
                return this.locations.find(function (obj) { return obj.name === 'Science Wing'; })
            },
            security: function () {
                return this.locations.find(function (obj) { return obj.name === 'Security Wing'; })
            },
            logistics: function () {
                return this.locations.find(function (obj) { return obj.name === 'Logistics'; })
            }
        },
        methods: {
            getLocationData: function () {
                let uri = ['/api/status/locations'].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.locations = response.data;
                            this.loaded = true;
                        }
                    })
                    .catch(error => { console.log(error); });
            },
            getActions: function () {

            }
        }
    }
</script>