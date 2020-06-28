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
                <h1 class="title">{{ info.title }}</h1>
                <p class="info">课程 ID : {{ info.id }}</p>
                <p class="info">课时 : {{ info.classHour }}</p>
                <p class="info">价格 : ￥{{ info.cost }}</p>
            </div>
            <div>
                <p style="cursor: pointer; color: #79C1E5; margin: 12px 16px;"
                    @click="edit()"
                >
                    修改
                </p>
                <p style="cursor: pointer; color: #DE5757; margin: 12px 16px;"
                    @click="deleteCourse()"
                >
                    移除
                </p>
            </div>
        </div>
        <div v-if="infoEdit" class="card" style="justify-content: space-between">
            <form>
                <div style="margin: 16px 0px">
                    <span class="info">标题 :</span>
                    <input v-model="infoTemp.title" class="inputbox" style="margin-left: 16px">
                </div>
                <div style="margin: 16px 0px">
                    <span class="info">课时 (小时) :</span>
                    <input v-model="infoTemp.classHour" class="inputbox" style="margin-left: 16px; width: 30px; text-align: center;">
                </div>
                <div style="margin: 16px 0px">
                    <span class="info">价格 (人民币) :</span>
                    <input v-model="infoTemp.cost" class="inputbox" style="margin-left: 16px; width: 30px; text-align: center;">
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
    </div>
</template>

<script>
import methods from '../../methods.js';

export default {
    name: 'ManagerCourseDetails',
    data: function () {
        // get course
        /*
        var courses = [
            { id: 1000, title: '这是零个课程名字大概有这——么长', classHour: 15, cost: 300 },
            { id: 1001, title: '这是一个课程名字大概有这——么长', classHour: 15, cost: 300 },
            { id: 1002, title: '这是两个课程名字大概有这——么长', classHour: 15, cost: 300 },
            { id: 1003, title: '这是一个课程名字大概有这——么长', classHour: 15, cost: 300 },
            { id: 1004, title: '这是一个课程名字大概有这——么长', classHour: 15, cost: 300 },
            { id: 1005, title: '这是一个课程名字大概有这——么长', classHour: 15, cost: 300 },
        ];
        for (var item of courses)
            if (item.id == this.$route.params.id) {
                course = item;
                break;
            }
            */
        var course = getCourse(this.$route.params.id);
        return {
            info: course,
            infoTemp: {
                title: '', classHour: undefined, cost: undefined
            },
            infoEdit: false
        };
    },
    methods: {
        getCourse(id) {
            var course = { id, title, classHour, cost };
            methods.getCourseById(id, (data) => {
                course.id = data.courseId;
                course.title = data.title;
                course.classHour = data.classHour;
                course.cost = data.cost;
            });
        },
        deleteCourse() {
            /* submit to server
             * if succeed:
             */
            this.$router.go(-1);
        },
        edit() {
            this.infoTemp.title = this.info.title;
            this.infoTemp.classHour = this.info.classHour;
            this.infoTemp.cost = this.info.cost;
            this.infoEdit = true;
        },
        submitEdit() {
            /* submit to server
             * if succeed:
             * this.info.name = this.infoTemp.name;
             * this.info.phone = this.infoTemp.phone;
             * this.info.email = this.infoTemp.email;
             */
            this.infoEdit = false;
        },
        discardEdit() {
            this.infoEdit = false;
        },
        back() {
            this.$router.go(-1);
        }
    }
}
</script>

<style>
</style>