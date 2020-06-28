<template>
    <div class="pageschedule">
        <div v-for="daylist in lessonList" :key='daylist.Date'>
            <br>
            <div style="cursor: default; margin-left: 10px;">
                <div class="date" style="float: left; margin-right:30px;">{{ daylist.week }}</div>
                <div class="date">{{ daylist.date }}</div>
            </div>
            <br>
            <div v-for="les in daylist.lessons" :key="les.lessonId">
                <lessoncard :lesson="les"></lessoncard>
                <br>
            </div>
        </div>
    </div>
</template>

<script>
import lessoncard from './lessoncard.vue'
import methods from '../../methods.js'

export default {
    name: 'pageschedule',
    components: {
        lessoncard
        },
    data() {
        return {
            coachId: '',
            lessonList: [ /*
                {
                Week: "周日",
                Date: "1月22日",
                Lessons: [
                        {
                            LessonId    : 1,
                            SectionId   : 1,
                            Title       : "这是课程1",
                            StartDate   : 1592614200,
                            EndDate     : 1592634200
                        }
                    ]
                },
                {
                Week: "周一",
                Date: "1月23日",
                Lessons: [
                        {
                            LessonId    : 4,
                            SectionId   : 2,
                            Title       : "这是课程2",
                            StartDate   : 1592614700,
                            EndDate     : 1592635200
                        },
                        {
                            LessonId    : 5,
                            SectionId   : 4,
                            Title       : "这是课程4",
                            StartDate   : 1592635200,
                            EndDate     : 1592685200
                        },
                    ]
                },*/
            ]
        }
    },
    created: function() {
        this.coachId = this.$route.query.coachId

        var currentTime = new Date()
        var this_=this;
        methods.GetCoachLessons(this.coachId, parseInt(currentTime.getTime()/1000), 100, function (response) {
            this_.lessonList = response
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
.pageschedule {
    background: white;
    padding: 16px 30px;
    font-family: "HW-Regular", Arial, Helvetica, sans-serif;
}
.date {
    color: #DE5757;
    font-size: 28px;
    letter-spacing: 5px;
}
</style>
