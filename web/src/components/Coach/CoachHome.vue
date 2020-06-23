<template>
    <div class="coachhome">
        <div class="card">
            <div style="float: left; margin-right:50px; margin-top: -14px">
                <h1 style="font-size: 35px ">Hi,&emsp;Mr.&emsp;{{ coachInfo.Name }}</h1>
            </div>
            <div class="info grey" style="margin: -18px 0px">
                <p>ID:&emsp;{{ coachInfo.ID }}
                    <br>Email:&emsp;{{ coachInfo.Email }}
                    <br>PhSone:&emsp;{{ coachInfo.PhoneNo }}
                </p>
            </div>
            <div style="float: right">
                <h1>{{ currentTime.hour }}:{{ currentTime.minute }}</h1>
            </div>
        </div>
        <br>
        <div class='grey' style="margin-top:-20px; margin-bottom: -10px"><h3>{{ sectionStatus }}</h3></div>
        <sectioncard v-if="sectionExists" :section="firstSection"></sectioncard>
    </div>
</template>

<script>
import sectioncard from './sectioncard.vue'

export default {
    name: 'coachhome',
    components: {
        sectioncard
    },
    data() {
        return {
            timer: '',
            currentTime: {
                timeStamp: '',
                hour: '',
                minute: ''
            },
            coachInfo: {
                ID: '',
                Name:'',
                Email:'',
                PhoneNo:''
            },
            firstSection: {
                SectionId : '',
                CourseId  : '',
                CoachId   : '',
                StartDate : '',
                EndDate   : '',
                SectionNumber : '',
                Title     : '',
                ClassHour : ''
            },
            sectionStatus: '近期无课程',
            sectionExists: false
        }
    },
    created: function() {
        var this_=this
        this.timer = setInterval(function () { 
            this_.currentTime.timeStamp=new Date().getTime()/1000
            this_.currentTime.hour=new Date().getHours()
            this_.currentTime.minute=new Date().getMinutes()
            if (this_.currentTime.minute < 10)
                this_.currentTime.minute = '0' + this_.currentTime.minute 
        })
        this_.currentTime.timeStamp=new Date().getTime()/1000
        this.coachInfo=this.$route.query.info
        this.firstSection=this.$route.query.firstSection
        if (this.firstSection != undefined) {
            this.sectionExists=true
            if (this.firstSection.StartDate <= this.currentTime.timeStamp)
                this.sectionStatus = '正在上课'
            else    {
                var tempDate = new Date(this.firstSection.StartDate*1000)
                this.sectionStatus = '下次课程' + (tempDate.getMonth()+1) + '月' + tempDate.getDate() + '日' + tempDate.getHours() + ' : ' + tempDate.getMinutes()
            }
        }
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
.card {
    overflow: hidden;
    padding: 23px;
    background:white;
    font-family: "Roboto-Medium", Arial, Helvetica, sans-serif;
}

.info {
    float: left;
    margin-top: -15px;
    margin-bottom: -15px;
    line-height: 30px;
    font-family: "Roboto", Arial, Helvetica, sans-serif;
}
.grey {
    color: #929292;
}
</style>