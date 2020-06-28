<template>
    <div class = "coachinstructdetail">
        <div class = "card" style="cursor: pointer;" @click="goBack">
            <img src="../../assets/imgs/jumpD_Reverse.png" 
                style="max-width: 30px; margin-right: 12px">
            <div style="font-size: 25px; margin-top: -3px">返回</div>
        </div>
        <br>
        <div class = 'card' style="flex-direction: column; align-items: flex-start;">
            <div style="font-size: 48px;">{{ member.name }}</div>
            <div class='color_grey font_light' style="font-size: 24px; display:flex; margin-top: 8px;">
                <div style="margin-right: 20px"> ID:&emsp;{{ member.memberId }}</div>
                <div>Phone:&emsp;{{ member.phoneNo }}</div>
            </div>
            <br><br>
            <div class='font_light' style="font-size: 30px">
                课程总学时:&emsp;<span style="font-size: 35px">{{ member.totalHours }}</span>
            </div>
            <div class='font_light' style="font-size: 30px; display: flex; align-items: center;">
                已完成学时:
                <div style = "margin:10px; width: 100px">
                    <el-input v-model="inputHours" style="font-size: 20px"></el-input>
                </div>
                <img src="../../assets/imgs/button_substract.png" style="width: 35px; padding-right: 10px; cursor: pointer;" @click="hourSub"> 
                <img src="../../assets/imgs/button_plus.png" style="width: 35px; padding-right: 10px; cursor: pointer;" @click="hourPlus"> 
                <el-button type="danger" size = "medium" style="margin-right: 10px" @click='checkIn'>确定</el-button>
                <div class="grey" id="valueChange"></div>
            </div>
        </div>
    </div>
</template>

<script>
import methods from '../../methods'

export default {
    name: 'coachinstructdetail',
    components: {
    },
    data () {
        return {
            coachId: '',
            inputHours: '',
            member: {}
        }
    },
    methods: {
        goBack: function () {
            javascript:history.back(-1);
        },
        hourPlus: function () {
            if (this.inputHours < this.member.totalHours)
                this.inputHours++
        },
        hourSub: function () {
            if (this.inputHours > 0)
                this.inputHours--
        },
        checkIn: function () {
            var this_ = this
            methods.UpdateInstruct({
                memberId: this_.member.memberId,
                coachId: this_.coachId,
                attendedHours: this_.inputHours,
                totalHours: this_.member.totalHours
            }, function (response) {
                console.log(this_.$router)
                this_.member.attendedHours = this_.inputHours
                document.getElementById('valueChange').innerHTML=''
                this_.$root.myEvent.$emit('instructUpdate')
            })
        }
    },
    created: function () {
        this.coachId = this.$route.query.coachId
        this.member = this.$route.query.member
        this.inputHours = this.member.attendedHours
    },
    watch: {
        inputHours(val, oldval) {
            if (val > this.member.attendedHours)
                document.getElementById('valueChange').innerHTML='+ ' + (val - this.member.attendedHours)
            else if (val < this.member.attendedHours)
                document.getElementById('valueChange').innerHTML='- ' + (this.member.attendedHours - val)
            else
                document.getElementById('valueChange').innerHTML=''
        }
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
