﻿<template>
    <div>
        <div class="row mb-1">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-3 top-x-axis bg-secondary ml-1"></div>
            <div class="col bg-primary ml-1 text-right">Sector {{game.sector}}</div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-info ml-1"><h1 class="header">Ship Status</h1></div>
        </div>
        <div v-if="loaded">
            <!-- Row 1 -->
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-danger"></div>
                <div class="col-4 ml-1 content">
                    <div class="row bg-danger">
                        <div class="col-auto px-1">{{bridge.name}}</div>
                        <div class="col text-right px-1">{{bridge.status}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row bg-danger">
                        <div class="col-auto px-1">{{science.abbreviated}}</div>
                        <div class="col text-right px-1">{{science.status}}</div>
                    </div>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-primary"></div>
                <div class="col-4 ml-1 content">
                    <div class="row" v-for="attribute in bridge.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row" v-for="attribute in science.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
            </div>
            <!-- Row 2 -->
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-success"></div>
                <div class="col-4 ml-1 content">
                    <div class="row bg-success">
                        <div class="col-auto px-1">{{communications.abbreviated}}</div>
                        <div class="col text-right px-1">{{communications.status}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row bg-success">
                        <div class="col-auto px-1">{{security.abbreviated}}</div>
                        <div class="col text-right px-1">{{security.status}}</div>
                    </div>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-primary"></div>
                <div class="col-4 ml-1 content">
                    <div class="row" v-for="attribute in communications.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row" v-for="attribute in security.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
            </div>

            <!-- Row 3 -->
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-secondary"></div>
                <div class="col-4 ml-1 content">
                    <div class="row bg-secondary">
                        <div class="col-auto px-1">{{medical.abbreviated}}</div>
                        <div class="col text-right px-1">{{medical.status}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row bg-secondary">
                        <div class="col-auto px-1">{{logistics.abbreviated}}</div>
                        <div class="col text-right px-1">{{logistics.status}}</div>
                    </div>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-primary"></div>
                <div class="col-4 ml-1 content">
                    <div class="row" v-for="attribute in medical.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row" v-for="attribute in logistics.attributes">
                        <div class="col px-2">{{attribute.abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{attribute.status.textValue2}}</div>
                    </div>
                </div>
            </div>

            <!-- Row 4 -->
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-info"></div>
                <div class="col-4 ml-1 content">
                    <div class="row bg-info">
                        <div class="col-auto px-1">{{engineering.abbreviated}}</div>
                        <div class="col text-right px-1">{{engineering.status}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row bg-info">&nbsp;</div>
                </div>
            </div>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-primary"></div>
                <div class="col-4 ml-1 content">
                    <div class="row">
                        <div class="col px-2">{{engineering.attributes[0].abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{engineering.attributes[0].status.textValue2}}</div>
                    </div>
                    <div class="row">
                        <div class="col px-2">{{engineering.attributes[1].abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{engineering.attributes[1].status.textValue2}}</div>
                    </div>
                </div>
                <div class="col-5 ml-1 content">
                    <div class="row">
                        <div class="col px-2">{{engineering.attributes[2].abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{engineering.attributes[2].status.textValue2}}</div>
                    </div>
                    <div class="row">
                        <div class="col px-2">{{engineering.attributes[3].abbreviated}}</div>
                        <div class="col-auto text-right px-1">{{engineering.attributes[3].status.textValue2}}</div>
                    </div>
                </div>
            </div>
        </div>
        <div v-else>
            <div class="row mb-1">
                <div class="col-auto top-y-axis bg-danger"></div>
                <div class="col ml-1 content">
                    <div class="row bg-danger">
                        <div class="col-auto px-1">Loading data...</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info">Status</div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/">Personal</router-link></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary fill"></div>
            <div class="col-4 ml-1"></div>
        </div>
    </div>
</template>

<script>
    import Axios from 'axios';

    export default {
        data() {
            return {
                loaded: false,
                locations: [
                    {
                        "locationId": 0,
                        "name": "",
                        "abbreviated": "",
                        "status": "",
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
                ]
            }
        },
        props: ['game', 'player'],
        beforeMount: function () {
            setInterval(this.getLocationData, 1000);
        },
        computed: {
            bridge: function () {
                return this.locations.find(function (obj) { return obj.name === 'Bridge';})
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
                let uri = ['/api/status/locations', this.game.gameId].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.locations = response.data;
                            this.loaded = true;
                        }
                    })
                    .catch(error => { console.log(error); });
            }
        }
    }
</script>