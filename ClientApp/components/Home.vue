<template>
    <div>
        <div class="row mb-1">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-3 top-x-axis bg-secondary ml-1"></div>
            <div class="col bg-primary ml-1 text-right">Sector {{game.sector}}</div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-info ml-1"><h1 class="header">Personal Status</h1></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary"></div>
            <div class="col ml-1 m-0" style="line-height: 1.6rem;">
                <div class="ml-1 content">
                    <div class="row">
                        <div class="col-4 text-right"><span class="text-danger">Name</span></div>
                        <div class="col">{{character.name}}</div>
                    </div>
                    <div class="row">
                        <div class="col-4 text-right"><span class="text-danger">Role</span></div>
                        <div class="col">{{character.role}}</div>
                    </div>
                    <div class="row">
                        <div class="col-4 text-right"><span class="text-danger">Skills</span></div>
                        <div class="col">
                            <ul class="list-inline">
                                <li class="list-inline-item" v-for="characterSkill in character.characterSkills">{{characterSkill.skill.name}}</li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4 text-right"><span class="text-danger">Unique Action</span></div>
                        <div class="col">{{character.traitName}}</div>
                    </div>
                    {{character.traitDescription}}
                </div>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-info ml-1"><h1 class="header">Story</h1></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-secondary"></div>
            <div class="col ml-1 m-0 content" style="text-transform: unset;">
                {{character.story}}
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info"></div>
            <div class="col bg-info ml-1"><h1 class="header">Victory Conditions</h1></div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-primary"></div>
            <div class="col ml-1 m-0 content">
                <ol>
                    <li v-for="characterObjective in character.characterObjectives">{{characterObjective.objective.description}}</li>
                </ol>
            </div>
        </div>
        <div class="row mb-1">
            <div class="col-auto top-y-axis bg-info">Status</div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/drone">Drone</router-link></div>
            <div class="col bg-success ml-1 button px-2"><router-link to="/ship">Ship</router-link></div>
        </div>
    </div>
</template>

<script>
    import Axios from 'axios';

    export default {
        data() {
            return {
                character: {
                    'characterId': 0,
                    'name': '',
                    'password': '',
                    'role': '',
                    'story': '',
                    'traitName': 'Drone Nut',
                    'traitDescription': '',
                    'tips': '',
                    'characterSkills': [
                        {
                            'characterSkillId': 0,
                            'characterId': 0,
                            'skillId': 0,
                            'skill': {
                                'skillId': 0,
                                'name': ''
                            }
                        }
                    ],
                    'characterObjectives': [
                        {
                            'characterObjectiveId': 0,
                            'characterId': 0,
                            'objectiveId': 0,
                            'objective': {
                                'objectiveId': 0,
                                'title': '',
                                'description': ''
                            }
                        }
                    ]
                }
            }
        },
        props: ['game', 'player'],
        beforeMount: function () {
            this.getCharacterData();
        },
        methods: {
            getCharacterData: function () {
                let uri = ['/api/status/character', this.player.characterId].join('/');
                Axios.get(uri)
                    .then(response => {
                        if (response.data) {
                            this.character = response.data;
                        }
                    })
                    .catch(error => { console.log(error); });
            }
        }
    }
</script>