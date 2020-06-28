<template>
    <div class = "instructcard card" style="cursor: pointer; justify-content: space-between" 
    @click="jumpToDetail">
        <div style="width: calc(80% - 40px)">
            <h1 style="margin-top:5px; margin-bottom: 5px; font-size: 30px;">
                学员：{{ member.name }}
            </h1>
            <div class='color_grey'>
                课时：{{ member.attendedHours }}/{{ member.totalHours }}
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
    name: "instructcard",
    props: {
        member: {},
        coachId: ''
    },
    methods: {
        jumpToDetail: function () {
            this.$router.push({ path: '/coach/instructdetail', query: {member: this.member, coachId: this.coachId}})
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