<template>
    <div class="pageschedule">
        <div v-for="daylist in lessonList" :key='daylist.Date'>
            <br>
            <div style="cursor: default; margin-left: 10px;">
                <div class="date" style="float: left; margin-right:30px;">{{ daylist.Week }}</div>
                <div class="date">{{ daylist.Date }}</div>
            </div>
            <br>
            <div v-for="les in daylist.Lessons" :key="les.LessonId">
                <lessoncard :lesson="les"></lessoncard>
                <br>
            </div>
        </div>
    </div>
</template>

<script>
import lessoncard from './lessoncard.vue'

export default {
    name: 'pageschedule',
    components: {
        lessoncard
        },
    data() {
        return {
            lessonList: [
                {
                Week: "周日",
                Date: "1月22日",
                Lessons: [
                        {
                            LessonId    : 1,
                            SectionId   : 1,
                            Title       : "这是课程1后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592614200,
                            EndDate     : 1592634200
                        },
                        {
                            LessonId    : 2,
                            SectionId   : 2,
                            Title       : "这是课程2后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592634200,
                            EndDate     : 1592674200
                        },
                        {
                            LessonId    : 3,
                            SectionId   : 3,
                            Title       : "这是课程3后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592674200,
                            EndDate     : 1592679200
                        },
                    ]
                },
                {
                Week: "周一",
                Date: "1月23日",
                Lessons: [
                        {
                            LessonId    : 4,
                            SectionId   : 2,
                            Title       : "这是课程2后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592614700,
                            EndDate     : 1592635200
                        },
                        {
                            LessonId    : 5,
                            SectionId   : 4,
                            Title       : "这是课程4后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592635200,
                            EndDate     : 1592685200
                        },
                    ]
                },
                {
                Week: "周二",
                Date: "1月24日",
                Lessons: [
                        {
                            LessonId    : 6,
                            SectionId   : 5,
                            Title       : "这是课程5后缀后缀",
                            StartDate   : 1592611200,
                            EndDate     : 1592634200
                        },
                        {
                            LessonId    : 7,
                            SectionId   : 6,
                            Title       : "这是课程6后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592634200,
                            EndDate     : 1592674200
                        },
                        {
                            LessonId    : 8,
                            SectionId   : 1,
                            Title       : "这是课程1后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592674200,
                            EndDate     : 1592679200
                        },
                        {
                            LessonId    : 9,
                            SectionId   : 3,
                            Title       : "这是课程3后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀后缀",
                            StartDate   : 1592679200,
                            EndDate     : 1592679800
                        },
                    ]
                },
            ]
        }
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
