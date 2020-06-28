<template>
    <div class="pageinstruct">
        <div v-for="mem in Members" :key="mem.MemberId">
            <instructcard :member="mem" :coachId="coachId"></instructcard>
            <br>
        </div>
    </div>
</template>

<script>
import instructcard from "./instructcard.vue"
import methods from "../../methods.js"

export default {
    name: 'pageinstruct',
    components: {
        instructcard
    },
    data() {
        return {
        coachId: '',
        Members: []
        }
    },
    created: function () {
        this.coachId = this.$route.query.coachId

        var this_ = this
        //获取section
        methods.GetInstructsByCoachId(this.coachId, function (response) {
            this_.Members = response.members
        })
    },
    activated: function () {
        var this_ = this
        this.$root.myEvent.$on('instructUpdate', function () {
            //获取section
            methods.GetInstructsByCoachId(this_.coachId, function (response) {
                this_.Members = response.members
            })
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
