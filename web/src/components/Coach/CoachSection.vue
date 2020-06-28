<template>
    <div class = "CoachSection">
        <div class = "card" style="cursor: pointer;" @click="goBack">
            <img src="../../assets/imgs/jumpD_Reverse.png" 
                style="max-width: 30px; float:left; margin-right: 12px">
            <div style="font-size: 25px; margin-top: -3px">返回</div>
        </div>
        <br>
        <div v-if="loaded">
        <div class = "card" style="flex-direction: column; align-items: flex-start">
            <div style="width: 80%">
                <p style="font-size: 40px; margin: 5px 5px">{{ sections.title }}</p>
            </div>
            <div style="display:flex; flex-direction: row; padding: 10px 0px; font-size: 20px">
                <div style="padding-left:7px; padding-right: 100px;">
                    课程总时长:&emsp;{{ sections.classHour }}
                </div>
                <div>参与时长:&emsp;{{ sections.attendedHours }}</div>
            </div>
        </div>
        <br>
        <div class="card" style="flex-direction: column; align-items: flex-start;">
            <div class='color_grey' style="font-size: 30px; padding-bottom: 5px">课程学员</div>
            <div v-for="member in sections.member" :key="member.memberId" 
            style="padding-top: 7px; display:flex; flex-direction: row; align-items: flex-end;">
                <div style="font-size:25px; min-width: 110px; padding-right: 30px">{{ member.name }}</div>
                <div class="color_grey" style="padding-right: 20px">ID:&emsp;{{ member.memberId }}</div>
                <div class="color_grey">Phone:&emsp;{{ member.phoneNo }}</div>
            </div>
        </div> 
        </div>
    </div>
</template>

<script>
import methods from '../../methods'

export default {
    name: 'coachsection',
    data () {
        return {
            sectionId: 1,
            sections: { 
                
            },
            loaded: false
        }
    },
    methods: {
        goBack: function () {
            javascript:history.back(-1);
        }
    },
    mounted: function() {
        var this_ = this
        methods.GetSectionBySectionId(this_.$route.query.SectionId, function (response) {
            this_.sections = response
        })
        /*
        methods.GetSectionMembers(this_.$route.query.SectionId, function (response) {
        this_.sections.member = response
        this_.loaded = true
        })
        */
        this_.sections.member = methods.GetSectionMembers(this_.$route.query.SectionId, function (res) {
            this_.sections.member = res
            this_.loaded = true
            console.log(this_.sections.member)
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
