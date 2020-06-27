<template>
    <div class = "CoachSection">
        <div class = "card" style="cursor: pointer;" @click="goBack">
            <img src="../../assets/imgs/jumpD_Reverse.png" 
                style="max-width: 30px; float:left; margin-right: 12px">
            <div style="font-size: 25px; margin-top: -3px">返回</div>
        </div>
        <br>
        <div class = "card" style="flex-direction: column; align-items: flex-start">
            <div style="width: 80%">
                <p style="font-size: 40px; margin: 5px 5px">{{ sections.Title }}</p>
            </div>
            <div style="display:flex; flex-direction: row; padding: 10px 0px; font-size: 20px">
                <div style="padding-left:7px; padding-right: 100px;">
                    课程总时长:&emsp;{{ sections.ClassHour }}
                </div>
                <div>参与时长:&emsp;{{ sections.AttendedHours }}</div>
            </div>
        </div>
        <br>
        <div class="card" style="flex-direction: column; align-items: flex-start;">
            <div class='color_grey' style="font-size: 30px; padding-bottom: 5px">课程学员</div>
            <div v-for="member in sections.Member" :key="member.MemberId" 
            style="padding-top: 7px; display:flex; flex-direction: row; align-items: flex-end;">
                <div style="font-size:25px; min-width: 110px; padding-right: 30px">{{ member.Name }}</div>
                <div class="color_grey" style="padding-right: 20px">ID:&emsp;{{ member.MemberId }}</div>
                <div class="color_grey">Phone:&emsp;{{ member.PhoneNo }}</div>
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
            sections: { /*
                SectionId   : 1,
                Title       : '三个月瘦身速成不瘦不要钱后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀',
                ClassHour   : 15,
                AttendedHours    : 12,
                Member      : [
                    {
                        MemberId    : '01222010',
                        Name        : '爱丽丝',
                        PhoneNo     : '180-1072-1101'
                    },
                    {
                        MemberId    : '01222011',
                        Name        : '比尔',
                        PhoneNo     : '138-1232-2132'
                    },
                    {
                        MemberId    : '01222012',
                        Name        : '莱纳',
                        PhoneNo     : '180-1013-3242'
                    },
                    {
                        MemberId    : '01222013',
                        Name        : '阿亮',
                        PhoneNo     : '180-4657-9435'
                    },
                    {
                        MemberId    : '01222014',
                        Name        : '布朗',
                        PhoneNo     : '131-1455-1762'
                    },
                    {
                        MemberId    : '01222015',
                        Name        : '爱因斯坦',
                        PhoneNo     : '139-3425-9335'
                    },
                ] */
            }
        }
    },
    methods: {
        goBack: function () {
            javascript:history.back(-1);
        }
    },
    created: function() {
        this.sections = methods.GetSectionBySectionId(this.sectionId).Data
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
