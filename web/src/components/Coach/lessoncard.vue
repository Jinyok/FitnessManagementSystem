<template>
    <div class = 'lessoncard' @click="jumpToCourse">
        <div style="float: left; font-size: 23px; width: calc(80% - 100px)">{{ lesson.Title }}</div>
        <div style="float: right; font-size: 20px; padding-top:5px">{{ timeSlot }} </div>
    </div>
</template>

<script>
export default {
    name: 'lessoncard',
    props: {
        lesson: {
            LessonId    : '',
            SectionId   : '',
            Title       : '',
            StartDate   : '',
            EndDate     : ''
        },
    },
    data() {
        return {
            timeSlot: '',
        }
    },
    created: function() {
        var sHour = new Date(this.lesson.StartDate*1000).getHours()
        var sMin = new Date(this.lesson.StartDate*1000).getMinutes()
        var eHour = new Date(this.lesson.EndDate*1000).getHours()
        var eMin = new Date(this.lesson.EndDate*1000).getMinutes()
        if (sHour < 10)   sHour = '0' + sHour
        if (sMin < 10)    sMin = '0' + sMin
        if (eHour < 10)   eHour = '0' + eHour
        if (eMin < 10)    eMin = '0' + eMin
        this.timeSlot = sHour + ' : ' + sMin + ' - ' + eHour + ' : ' + eMin
    },
    methods: {
        jumpToCourse: function () {
            this.$router.push({ path: '/coach/section', query: {} })
        }
    }
}
</script>

<style>
.lessoncard {
    overflow: hidden;
    padding: 12px 16px;
    letter-spacing: 2px;
    font-family: "Roboto", "HW-Regular",Arial, Helvetica, sans-serif;
    background: #DE5757;
    color: white;
    border-style: solid;
	border-color:#CCCCCC;
    border-width: 1.5px;
    border-radius:5px;
    cursor: pointer;
}
</style>

<style>
@import url("../../assets/css/font.css");
</style>
