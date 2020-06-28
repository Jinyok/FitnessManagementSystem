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
import methods from '../../methods'

export default {
    name: 'pagecourses',
    components: {
        sectioncard
    },
    data() {
        return {
        coachId: '',
        sections: [/*
                {
                    SectionId   : 1,
                    Title       : '肌肉塑形',
                    ClassHour   : 15,
                    AttendedHours    : 8
                },
                {
                    SectionId   : 2,
                    Title       : '快速减脂',
                    ClassHour   : 12,
                    AttendedHours    : 7
                }*/
            ]
        }
    },
    created: function () {
        this.coachId = this.$route.query.coachId

        var this_ = this
        methods.GetSectionByCoachId(this.coachId, function (response) {
            this_.sections = response
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
