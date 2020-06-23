<template>
    <div class = "sectioncard card" style="cursor: pointer">
        <div style="float:left">
            <h1 style="margin-top:5px; margin-bottom: 5px; font-size: 30px">{{ section.Title }}</h1>
            <div class='grey'>
                课时：{{ section.SectionNumber }}/{{ section.ClassHour }}
            </div>
        </div>
        <img src="../../assets/imgs/jumpD.png" style="max-width: 45px; float: right; margin-top: 15px">
    </div>
</template>

<script>
export default {
    name: "sectioncard",
    props: {
        section: {
            CourseId: '',
            Title: '',
            ClassHour: '',
            SectionNumber: ''
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
.grey {
    color: #929292;
}

</style>