<template>
    <div>
        <div class="card">
            <div style="cursor: pointer; display: flex; align-item: center;" @click="back()">
                <svg viewBox="0 0 512 512" width="28" height="28" style="transform: rotate(180deg);">
		            <path fill="#79C1E5" d="M423.386,248.299l-256-245.327c-4.208-4.021-10.833-3.958-14.927,0.167l-64,63.998c-2.042,2.042-3.167,4.812-3.125,7.687
		                c0.042,2.896,1.25,5.625,3.344,7.604l183.792,173.579L88.678,429.586c-2.094,1.979-3.302,4.708-3.344,7.604
		                c-0.042,2.875,1.083,5.646,3.125,7.687l64,63.998c2.083,2.083,4.813,3.125,7.542,3.125c2.656,0,5.313-0.979,7.385-2.958
		                l256-245.327c2.094-2.021,3.281-4.792,3.281-7.708C426.667,253.09,425.48,250.319,423.386,248.299z"/>
                </svg>
                <p class="list-text" style="margin: 0px 8px">返回</p>
            </div>
        </div>
        <div v-if="!infoEdit" class="card" style="justify-content: space-between">
            <div>
                <h1 class="title">{{ info.name }}</h1>
                <p class="info">个人 ID : {{ info.id }}</p>
                <p class="info">账号 : {{ info.account }}</p>
                <p class="info">联系电话 : {{ info.phone }}</p>
                <p class="info">电子邮箱 : {{ info.email }}</p>
            </div>
            <div>
                <p style="cursor: pointer; color: #79C1E5; margin: 12px 16px;"
                    @click="edit()"
                >
                    修改
                </p>
                <p style="cursor: pointer; color: #DE5757; margin: 12px 16px;"
                    @click="deleteCoach()"
                >
                    移除
                </p>
            </div>
        </div>
        <div v-if="infoEdit" class="card" style="justify-content: space-between">
            <form>
                <div>
                    <span class="info">姓名 :</span>
                    <input v-model="infoTemp.name" class="inputbox" style="margin-left: 16px">
                </div>
                <div>
                    <span class="info">联系电话 :</span>
                    <input v-model="infoTemp.phone" class="inputbox" style="margin-left: 16px">
                </div>
                <div>
                    <span class="info">电子邮箱 :</span>
                    <input v-model="infoTemp.email" class="inputbox" style="margin-left: 16px">
                </div>
            </form>
            <div>
                <p style="cursor: pointer; color: #79C1E5; margin: 0px 16px;"
                    @click="submitEdit()"
                >
                    确认
                </p>
                <p style="cursor: pointer; color: #b0b0b0; margin: 0px 16px;"
                    @click="discardEdit()"
                >
                    放弃
                </p>
            </div>
        </div>
        <h2 style="color: #b0b0b0; margin: 8px 16px">当前开设私教课程数 : {{ instructs.length }}</h2>
        <div v-for="member in instructs" :key="member.id">
            <div class="card" style="justify-content: space-between">
                <div>
                    <h2 class="list-title" style="cursor: pointer">{{ member.name }}</h2>
                    <p class="info">学员 ID: {{ member.id }}</p>
                </div>
                <p style="cursor: pointer; color: #de5757; margin: 0px 16px;"
                    @click="deleteInstruct(member.id)"
                >
                    移除
                </p>
            </div>
        </div>
        <h2 style="color: #b0b0b0; margin: 8px 16px">当前授课 : {{ sections.length }}</h2>
        <div class="card">
            <div v-if="!addingSection"
                style="display: flex; cursor: pointer"
                @click="addSection()"
            >
                <p class="list-text">新增排课</p>
            </div>
            <div v-if="addingSection">
                <form>
                    <div style="margin: 16px 0px;">
                        <span class="info">课程ID :</span>
                        <input v-model="sectionTemp.id" class="inputbox" style="margin: 0px 16px; width: 100px">
                    </div>
                    <div style="margin: 16px 0px;">
                        <span class="info">授课频率 :</span>
                        <input v-model="sectionTemp.lessonInterval"
                            type="radio" id="lesson-internal-day" name="lesson-internal"
                            value="day" style="margin-left: 16px;"
                        >
                        <label for="lesson-internal-day" class="radio">每天</label>
                        <input v-model="sectionTemp.lessonInterval"
                            type="radio" id="lesson-internal-week" name="lesson-internal"
                            value="week" style="margin-left: 16px;"
                        >
                        <label for="lesson-internal-week" class="radio">每周</label>
                    </div>
                    <div style="display: flex; margin: 16px 0px">
                        <span class="info">授课时间 :</span>
                        <input v-model="sectionTemp.startTime" class="inputbox"
                            style="margin: 0px 16px; width: 30px; text-align: center;"
                        >
                        <span class="info">至</span>
                        <input v-model="sectionTemp.endTime" class="inputbox"
                            style="margin: 0px 16px; width: 30px; text-align: center;"
                        >
                    </div>
                    <div style="display: flex; margin: 16px 0px">
                        <span class="info">开始日期 :</span>
                        <select v-model="sectionTemp.startDateY" class="select" style="margin: 0px 16px">
                            <option value="2020">2020</option>
                            <option value="2021">2021</option>
                            <option value="2022">2022</option>
                            <option value="2023">2023</option>
                        </select>
                        <span class="info">年</span>
                        <select v-model="sectionTemp.startDateM" class="select" style="margin: 0px 16px">
                            <option value="1">1</option><option value="2">2</option><option value="3">3</option>
                            <option value="4">4</option><option value="5">5</option><option value="6">6</option>
                            <option value="7">7</option><option value="8">8</option><option value="9">9</option>
                            <option value="10">10</option><option value="11">11</option><option value="12">12</option>
                        </select>
                        <span class="info">月</span>
                        <input v-model="sectionTemp.startDateD" class="inputbox"
                            style="margin: 0px 16px; width: 30px; text-align: center"
                        />
                        <span class="info">日</span>
                    </div>
                </form>
                <div style="display: flex; margin-top: 20px">
                    <p style="cursor: pointer; color: #79C1E5; margin: 0px 16px;"
                        @click="submitNewSection()"
                    >
                        确认
                    </p>
                    <p style="cursor: pointer; color: #b0b0b0; margin: 0px 16px;"
                        @click="discardNewSection()"
                    >
                        放弃
                    </p>
                </div>
            </div>
        </div>
        <div v-for="section in sections" :key="section.id">
            <div class="card" style="justify-content: space-between">
                <div>
                    <h2 class="list-title" style="cursor: pointer"
                        @click="jumpCourse(section.courseId)"
                    >
                        {{ section.title }}
                    </h2>
                    <p class="info">课时: {{ section.attendedHour }} / {{ section.classHour }}</p>
                </div>
                <p style="cursor: pointer; color: #DE5757; margin: 0px 16px;"
                    @click="deleteSection(section.id)"
                >
                    移除
                </p>
            </div>
        </div>
    </div>
</template>

<script>
import methods from '../../methods.js';

export default {
    name: 'ManagerCourse',
    data: function () {
        // get coach info by id
        /*
        var coaches = [
            { id: 1000, account: 'coachaccount', name: '柳德米拉', phone: '000-0000-0000', email: 'unknown@fms.com'},
            { id: 1001, account: 'coachaccount', name: '亚历克斯', phone: '000-0000-0000', email: 'unknown@fms.com'},
            { id: 1002, account: 'coachaccount', name: '米莎', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1003, account: 'coachaccount', name: '叶莲娜', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1004, account: 'coachaccount', name: '萨沙', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1005, account: 'coachaccount', name: '伊诺', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1006, account: 'coachaccount', name: '博卓卡斯替', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1007, account: 'coachaccount', name: '大亚当', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1008, account: 'coachaccount', name: '大鲍勃', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1009, account: 'coachaccount', name: '萨卡兹百夫长', phone: '000-0000-0000', email: 'unknown@fms.com' },
            { id: 1010, account: 'coachaccount', name: '塔露拉', phone: '000-0000-0000', email: 'unknown@fms.com' },
        ];
        var coach;
        for (var item of coaches)
            if (item.id == this.$route.params.id) {
                coach = item;
                break;
            }
            */
        var coach = this.getCoach(this.$route.params.id);

        // get coach sections by coachId
        /*
        var sections = [
            { id: 1001, courseId: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, attendedHour: 8 },
            { id: 1002, courseId: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, attendedHour: 8 },
            { id: 1003, courseId: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, attendedHour: 8 },
            { id: 1004, courseId: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, attendedHour: 8 },
            { id: 1005, courseId: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, attendedHour: 8 },
        ];
        */
       var sections = this.getSections(coach.id);

        // get instructs by coachId
        /*
        var instructs = [
            { id: 1000, name: '某卡斯特'},
            { id: 1001, name: '某黎博利'},
            { id: 1002, name: '某瓦伊凡'},
        ];
        */
        var instructs = this.getInstructs(coach.id);
        return {
            info: coach,
            infoTemp: {
                name: '', phone: '', email: ''
            },
            infoEdit: false,
            sectionTemp: {
                id: undefined,
                lessonInterval: undefined,
                startTime: undefined,
                endTime: undefined,
                startDateY: undefined,
                startDateM: undefined,
                startDateD: undefined,
            },
            addingSection: false,
            instructs: instructs,
            sections: sections,
        };
    },
    methods: {
        getCoach(id) {
            var info = { id :'', name:'', phone:'', email:'' };
            methods.getCoachesById(id, (data) => {
                info.id = data.coachId;
                info.name = data.name;
                info.phone = data.phoneNo;
                info.email = data.email;
            });
            return info;
        },
        getSections(id) {
            var sections = [];
            methods.GetSectionByCoachId(id, (data) => {
                console.log(data)
                for (var item of data)
                    list.push({
                        id: item.sectionId,
                        title: item.title,
                        courseId: item.courseId,
                        classHour: item.classHour,
                        attendedHour: item.attendedHours
                    });
            });
            return sections;
        },
        getInstructs(id) {
            var instructs = [];
            methods.GetInstructsByCoachId(id, (data) => {
                for (var item of data)
                    list.push({
                        id: item.memberId,
                        name: item.name
                    });
            });
            return instructs;
        },
        deleteCoach() {
            // deleteCoach (this.info.id): code
            this.$router.go(-1);
        },
        edit() {
            this.infoTemp.name = this.info.name;
            this.infoTemp.phone = this.info.phone;
            this.infoTemp.email = this.info.email;
            this.infoEdit = true;
        },
        submitEdit() {
            // updateCoach (this.info.id, this.infoTemp.name, this.infoTemp.phone, this.infoTemp.email, 'InOffice'): code
            this.info.name = this.infoTemp.name;
            this.info.phone = this.infoTemp.phone;
            this.info.email = this.infoTemp.email;
            this.infoEdit = false;
        },
        discardEdit() {
            this.infoEdit = false;
        },
        addSection() {
            this.addingSection = true;
        },
        submitNewSection() {
            // addSection (this.info.id, this.sectionTemp.id): sectionId;
            var classHour; // get course classhour
            var interval = 0, lessonTime = (this.sectionTemp.endTime - this.sectionTemp.startTime) * 3600000,
                date = new Date(this.sectionTemp.startDateY, this.sectionTemp.startDateM, this.sectionTemp.startDateD,
                this.sectionTemp.startTime, 0, 0, 0).getTime ();
            if (this.sectionTemp.lessonInterval == 'day')
                interval = 86400000;
            else if (this.sectionTemp.lessonInterval == 'week')
                interval = 604800000;
            for (var i = 0; i < classHour; ++i) {
                // new lesson: (sectionId, info.id, date, date + lessonTime, 'NotFinish')
                date += interval;
            }
            this.addingSection = false;
            this.sectionTemp.id = undefined;
            this.sectionTemp.lessonInterval = undefined;
            this.sectionTemp.startTime = undefined;
            this.sectionTemp.endTime = undefined;
            this.sectionTemp.startDateY = undefined;
            this.sectionTemp.startDateM = undefined;
            this.sectionTemp.startDateD = undefined;
        },
        discardNewSection() {
            this.addingSection = false;
            this.sectionTemp.id = undefined;
            this.sectionTemp.lessonInterval = undefined;
            this.sectionTemp.startTime = undefined;
            this.sectionTemp.endTime = undefined;
            this.sectionTemp.startDateY = undefined;
            this.sectionTemp.startDateM = undefined;
            this.sectionTemp.startDateD = undefined;
        },
        deleteSection(id) {
            // deleteSection (id): code
            this.sections = this.sections.filter((value, index, arr) => { return value.id != id});
        },
        deleteInstruct(id) {
            this.instructs = this.instructs.filter((value, index, arr) => { return value.id != id});
        },
        jumpCourse(id) {
            this.$router.push ({ name: 'ManagerCourseDetails', params: { id: id }});
        },
        back() {
            this.$router.go(-1);
        }
    }
}
</script>