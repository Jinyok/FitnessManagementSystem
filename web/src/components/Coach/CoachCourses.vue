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
        sections: []
        }
    },
    created: function () {
        this.sections = this.$route.query.sections;
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
