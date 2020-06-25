<template>
    <div class="pageinstruct">
        <div v-for="mem in Members" :key="mem.MemberId">
            <instructcard :member="mem"></instructcard>
            <br>
        </div>
    </div>
</template>

<script>
import instructcard from "./instructcard.vue"

export default {
    name: 'pageinstruct',
    components: {
        instructcard
    },
    data() {
        return {
        Members: [
                {
                    MemberId    : '00000000',
                    CoachId     : '00000001',
                    Name        : '亚历山大变石',
                    PhoneNo     : '000-0000-0000',
                    TotalHours  : 15,
                    AttendedHours : 7
                },
                {
                    MemberId    : '00000001',
                    CoachId     : '00000001',
                    Name        : '圆粒金刚石',
                    PhoneNo     : '000-0000-0000',
                    TotalHours  : 7,
                    AttendedHours : 1
                },
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
