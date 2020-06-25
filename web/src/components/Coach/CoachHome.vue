<template>
    <div class="coachhome">
        <div class="card" style="justify-content: space-between">
            <div style="display:flex; align-items: center;">
            <div style="margin-right:50px;">
                <h1 style="font-size: 35px ">Hi,&emsp;Mr.&emsp;{{ coachInfo.Name }}</h1>
            </div>
            <div class="info grey">
                <p>ID:&emsp;{{ coachInfo.ID }}
                    <br>Email:&emsp;{{ coachInfo.Email }}
                    <br>PhoneNo:&emsp;{{ coachInfo.PhoneNo }}
                </p>
            </div>
            </div>
            <div style="float: right">
                <h1>{{ currentTime.hour }}:{{ currentTime.minute }}</h1>
            </div>
        </div>
        <br>
        <div class='grey' style="margin-top:-20px; margin-bottom: -10px"><h2>{{ lessonStatus }}</h2></div>
        <sectioncard v-if="lessonExists" :section="firstSection"></sectioncard>
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
            //需要查
            coachInfo: {
                ID: '00000000',
                Name: '未命名',
                Email: 'unknown@email.com',
                PhoneNo: '000-0000-0000' 
            },
            //需要查
            firstSection: {
                SectionId   : 1,
                Title       : '肌肉塑形后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀',
                ClassHour   : 15,
                Progress    : 8,
                StartDate   : 1592614200
            },
            lessonStatus: '近期无课程',
            lessonExists: false
        }
    },
    created: function() {
        console.log(this.$route)
        //获取教练数据
        /*coachInfo*/

        //设置时间
        var this_=this
        this.timer = setInterval(function () { 
            this_.currentTime.timeStamp=new Date().getTime()/1000
            this_.currentTime.hour=new Date().getHours()
            this_.currentTime.minute=new Date().getMinutes()
            if (this_.currentTime.minute < 10)
                this_.currentTime.minute = '0' + this_.currentTime.minute 
        })

        //获取第一节课课程信息
        /*firstSection*/
        this_.currentTime.timeStamp=new Date().getTime()/1000
        if (this.firstSection != undefined) {
            this.lessonExists=true
            if (this.firstSection.StartDate <= this.currentTime.timeStamp)
                this.lessonStatus = '正在上课'
            else    {
                var tempDate = new Date(this.firstSection.StartDate*1000)
                this.lessonStatus = '下次课程' + (tempDate.getMonth()+1) + '月' + tempDate.getDate() + '日' + tempDate.getHours() + ' : ' + tempDate.getMinutes()
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
.grey {
    color: #B0B0B0;
}
</style>