<template>
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
        <!-- Row 1 -->
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-danger"></div>
            <div class="col-4 ml-1 content">
                <div class="row bg-danger">
                    <div class="col-auto px-1">{{bridge.name}}</div>
                    <div class="col text-right px-1">5 LS | 1 XT</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row bg-danger">
                    <div class="col-auto px-1">{{science.abbreviated}}</div>
                    <div class="col text-right px-1">5 LS | 1 XT</div>
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
                    <div class="col-auto px-1">{{communications.name}}</div>
                    <div class="col text-right px-1">5 LS | 1 XT</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row bg-success">
                    <div class="col-auto px-1">SECURITY</div>
                    <div class="col text-right px-1">5 LS | 1 XT</div>
                </div>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary"></div>
            <div class="col-4 ml-1 content">
                <div class="row">
                    <div class="col px-2">SHORT S.</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
                <div class="row">
                    <div class="col px-2">LONG S.</div>
                    <div class="col-auto text-right px-1">1 DMG</div>
                </div>
                <div class="row">
                    <div class="col px-2">REQ. LINE</div>
                    <div class="col-auto text-right px-1">2 DMG</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row">
                    <div class="col px-2">LOCKDOWN</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
                <div class="row">
                    <div class="col px-2">SEC. REPORTS</div>
                    <div class="col-auto text-right px-1">2 DMG</div>
                </div>
                <div class="row">
                    <div class="col px-2">BEEPSKY CON</div>
                    <div class="col-auto text-right px-1">1 DMG</div>
                </div>
            </div>
        </div>
        <!-- Row 3/4 -->
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-secondary"></div>
            <div class="col-4 ml-1 content">
                <div class="row bg-secondary">
                    <div class="col-auto px-1">MEDICAL</div>
                    <div class="col text-right px-1">4 LS | 2 XT</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row bg-secondary">
                    <div class="col-auto px-1">ENGINEERING</div>
                    <div class="col text-right px-1">4 LS | 1 XT</div>
                </div>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary"></div>
            <div class="col-4 ml-1 content">
                <div class="row">
                    <div class="col px-2">AUTO DOC</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
                <div class="row">
                    <div class="col px-2">CREW RECORD</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row">
                    <div class="col px-2">MECH BAY</div>
                    <div class="col-auto text-right px-1">1 DMG</div>
                </div>
                <div class="row">
                    <div class="col px-2">R.DRN CON</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
            </div>
        </div>
        <!-- Row 3/4 -->
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col-4 ml-1 content">
                <div class="row bg-info">
                    <div class="col-auto px-1">LOGISTIC</div>
                    <div class="col text-right px-1">4 LS | 2 XT</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row">
                    <div class="col px-2">ATMO</div>
                    <div class="col-auto text-right px-1">OK</div>
                </div>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary"></div>
            <div class="col-4 ml-1 content">
                <div class="row">
                    <div class="col px-2">M.DRN CON</div>
                    <div class="col-auto text-right px-1">2 DMG</div>
                </div>
            </div>
            <div class="col-5 ml-1 content">
                <div class="row">
                    <div class="col px-2">SLIPDRIVE</div>
                    <div class="col-auto text-right px-1">20 DMG</div>
                </div>
            </div>
        </div>

        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info">Status</div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/drone">Drone</router-link></div>
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
                                "status": {
                                    "statusId": 0,
                                    "textValue1": "",
                                    "textValue2": "",
                                    "time": ""
                                }
                            }
                        ],
                        "teleports": [
                            {
                                "playerName": "",
                                "characterName": "",
                                "locationId": 0
                            }
                        ]
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
            medial: function () {
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
                        }
                    })
                    .catch(error => { console.log(error); });
            }
        }
    }
</script>