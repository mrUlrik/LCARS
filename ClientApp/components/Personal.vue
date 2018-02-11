<template>
    <div>
        <div class="row mb-1">
            <div class="col-auto top bg-secondary"></div>
            <div class="col-3 top-x-axis bg-secondary ml-1"></div>
            <div class="col bg-primary ml-1 text-right">SECTOR Omicron</div>
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
                        <div class="col-2"><span class="text-danger">Name</span></div>
                        <div class="col">George Melons</div>
                    </div>
                    <div class="row">
                        <div class="col-2"><span class="text-danger">Class</span></div>
                        <div class="col">2nd Generation Clone</div>
                    </div>
                    <div class="row">
                        <div class="col-2"><span class="text-danger">Skills</span></div>
                        <div class="col">Piloting &#0149; Engineering</div>
                    </div>
                    <div class="row">
                        <div class="col-auto"><span class="text-danger">Unique Action</span></div>
                        <div class="col">Slipgate Mechanic</div>
                    </div>
                    Repairs to the slipgate engine add +1 additional damage
                </div>
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
                    <li>Guide the ship to the slipgate</li>
                    <li>Survive the night without dying</li>
                    <li>Discover who killed the caption</li>
                    <li>Damage the science lab</li>
                    <li>Research <span class="text-info">Space Weed</span></li>
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