<template>
    <div class = "sectioncard card" style="cursor: pointer; justify-content: space-between" 
    @click="jumpToCourse">
        <div style="width: calc(80% - 40px)">
            <h1 style="margin-top:5px; margin-bottom: 5px; font-size: 30px;">
                {{ section.Title }}
            </h1>
            <div class='grey'>
                课时：{{ section.Progress }}/{{ section.ClassHour }}
            </div>
        </div>
        <div>
            <img src="../../assets/imgs/jumpD.png" 
            style="max-width: 45px; margin-top: 15px">
        </div>
    </div>
</template>

<script>
import methods from '../../methods'
export default {
    name: "sectioncard",
    props: {
        section: {
            SectionId   : '',
            Title       : '',
            ClassHour   : '',
            Progress    : ''
        }
    },
    methods: {
        jumpToCourse: function () {
            this.$router.push({ path: '/coach/section', query: {} })
        }
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
.grey {
    color: #929292;
}

</style>