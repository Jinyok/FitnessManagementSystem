<template>
    <div class="coachhome">
        <div class="card" style="justify-content: space-between">
            <div style="display:flex; align-items: center;">
            <div style="margin-right:50px;">
                <h1 style="font-size: 35px ">Hi,&emsp;Mr.&emsp;{{ coachInfo.name }}</h1>
            </div>
            <div class="info color_grey">
                <p>ID:&emsp;{{ coachInfo.coachId }}
                    <br>Email:&emsp;{{ coachInfo.email }}
                    <br>PhoneNo:&emsp;{{ coachInfo.phoneNo }}
                </p>
            </div>
            </div>
            <div style="float: right">
                <h1>{{ currentTime.hour }}:{{ currentTime.minute }}</h1>
            </div>
        </div>
        <br>
        <div class='color_grey' style="margin-top:-20px; margin-bottom: -10px"><h2>{{ lessonStatus }}</h2></div>
        <sectioncard v-if="lessonExists" :section="firstSection"></sectioncard>
    </div>
</template>

<script>
import sectioncard from './sectioncard.vue'
import methods from '../../methods'

export default {
    name: 'coachhome',
    components: {
        sectioncard
    },
    data() {
        return {
            coachId: '',
            timer: '',
            currentTime: {
                timeStamp: '',
                hour: '',
                minute: ''
            },
            //需要查
            coachInfo: {
            },
            firstSection: {
            },
            lessonStatus: '近期无课程',
            lessonExists: false
        }
    },
    created: function() {
        this.coachId = this.$route.query.coachId

        var this_=this
        //获取教练数据
        methods.getCoachesById(this.coachId, function(response) {
            //console.log(response)
            this_.coachInfo = response
        })

        //设置时间
        this.timer = setInterval(function () { 
            this_.currentTime.timeStamp=new Date().getTime()/1000
            this_.currentTime.hour=new Date().getHours()
            this_.currentTime.minute=new Date().getMinutes()
            if (this_.currentTime.minute < 10)
                this_.currentTime.minute = '0' + this_.currentTime.minute 
        })
        this_.currentTime.timeStamp=new Date().getTime()/1000

        //获取第一节课课程信息
        methods.GetFirstLessonByCoachId(this.coachId, function (response) {
            console.log(response)
            this_.firstSection = response
            if (this_.firstSection != undefined) {
                this_.lessonExists=true
                if (this_.firstSection.StartDate <= this_.currentTime.timeStamp)
                    this_.lessonStatus = '正在上课'
                else    {
                    var tempDate = new Date(this_.firstSection.startDate*1000)
                    var min = tempDate.getMinutes()
                    if (min < 10)
                        min = '0' + min
                    this_.lessonStatus = '下次课程' + (tempDate.getMonth()+1) + '月' + tempDate.getDate() + '日' + tempDate.getHours() + ' : ' + min
                }
        }
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
.card {
    overflow: hidden;
    padding: 23px 30px;
    background:white;
    font-family: "Roboto-Medium", "HW-Bold", Arial, Helvetica, sans-serif;
    display:flex;
    align-items: center;
}

.font_light {
    font-family: "Roboto", "HW-Regular", Arial, Helvetica, sans-serif;
}

.info {
    float: left;
    margin-top: -15px;
    margin-bottom: -15px;
    line-height: 30px;
    font-family: "Roboto", "HW-Regular", Arial, Helvetica, sans-serif;
}
.color_grey {
    color: #B0B0B0;
}
</style>