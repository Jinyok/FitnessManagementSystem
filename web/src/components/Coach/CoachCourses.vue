<template>
    <div class="pagecourses">
        <div v-for="sec in sections" :key="sec.SectionId">
            <sectioncard :section="sec"></sectioncard>
            <br>
        </div>
    </div>
</template>

<script>
import sectioncard from "./sectioncard.vue"

export default {
    name: 'pagecourses',
    components: {
        sectioncard
    },
    data() {
        return {
        sections: [
                {
                    SectionId   : 1,
                    Title       : '肌肉塑形',
                    ClassHour   : 15,
                    Progress    : 8
                },
                {
                    SectionId   : 2,
                    Title       : '快速减脂',
                    ClassHour   : 12,
                    Progress    : 7
                }
            ]
        }
    },
    created: function () {
        //获取section
        /*section*/
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
