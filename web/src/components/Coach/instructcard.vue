<template>
    <div class = "instructcard card" style="cursor: pointer; justify-content: space-between" 
    @click="jumpToDetail">
        <div style="width: calc(80% - 40px)">
            <h1 style="margin-top:5px; margin-bottom: 5px; font-size: 30px;">
                学员：{{ member.Name }}
            </h1>
            <div class='grey'>
                课时：{{ member.AttendedHours }}/{{ member.TotalHours }}
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
        member: {
            MemberId    : '00000000',
            CoachId     : '00000001',
            Name        : '亚历山大变石',
            PhoneNo     : '000-0000-0000',
            TotalHours  : 15,
            AttendedHours : 7
            },
    },
    methods: {
        jumpToDetail: function () {
            this.$router.push({ path: '/coach/instructdetail', query: {member: this.member}})
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