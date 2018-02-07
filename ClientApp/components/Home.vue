<template>
    <div class="container">
        <div class="row">
            <div class="content-border left"></div>
            <div class="content-border text">USS Raven - Database 63-528</div>

            <div class="content-border right"></div>
            <div class="content-border fill"></div>
        </div>
        
    </div>
</template>

<style scoped>
    .container {
        font-family: "Helvetica Ultra Compressed";
    }

    .container {
        margin: 0 auto;
        padding: 0 10px;
        max-width: 1000px;
    }

    .row::before, .row::after {
        display: table;
        content: " ";
        clear: both;
    }

    .content-border {
        background-color: #DD6644;
        height: 1.6rem;
        margin-left: .4rem;
        float: left;
    }

    .content-border.left {
        border-radius: 1.6rem 0 0 1.6rem;
        width: 25px;
    }

    .content-border.right {
        border-radius: 0 1.6rem 1.6rem 0;
        width: 25px;
    }

    .content-border.fill {
        float: unset;
        width: 100%;
    }

    .content-border.text {
        background-color: transparent;
        color: #FFCC66;
        
    }
</style>