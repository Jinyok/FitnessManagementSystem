<template>
    <div>
            <!--div class="card" style="flex-grow: 1; margin-right: 16px;">
                <div style="cursor: pointer; display: flex; align-item: center;" @click="addCourse()">
                    <svg viewBox="0 0 448 448" width="28" height="28" style="transform: rotate(180deg);">
                        <path fill="#79c1e5" d="m408 184h-136c-4.417969 0-8-3.582031-8-8v-136c0-22.089844-17.910156-40-40-40s-40 17.910156-40 40v136c0
                            4.417969-3.582031 8-8 8h-136c-22.089844 0-40 17.910156-40 40s17.910156 40 40 40h136c4.417969 0 8 3.582031 8
                            8v136c0 22.089844 17.910156 40 40 40s40-17.910156 40-40v-136c0-4.417969 3.582031-8 8-8h136c22.089844 0
                            40-17.910156 40-40s-17.910156-40-40-40zm0 0"/>
                    </svg>
                    <p class="list-text" style="margin: 0px 8px">增添课程</p>
                </div>
            </div-->
        <div class="card">
            <svg viewBox='0 0 136 136' width="28" height="28"
                style="cursor: pointer" @click="search(searchType, searchContent)"
            >
                <path fill="#79c1e5" d="M 93.148438 80.832031 C 109.5 57.742188 104.03125 25.769531 80.941406 9.421875 C 57.851562 -6.925781 25.878906 -1.460938
                    9.53125 21.632812 C -6.816406 44.722656 -1.351562 76.691406 21.742188 93.039062 C 38.222656 104.707031 60.011719 105.605469
                    77.394531 95.339844 L 115.164062 132.882812 C 119.242188 137.175781 126.027344 137.347656 130.320312 133.269531 C 134.613281
                    129.195312 134.785156 122.410156 130.710938 118.117188 C 130.582031 117.980469 130.457031 117.855469 130.320312 117.726562 Z
                    M 51.308594 84.332031 C 33.0625 84.335938 18.269531 69.554688 18.257812 51.308594 C 18.253906 33.0625 33.035156 18.269531
                    51.285156 18.261719 C 69.507812 18.253906 84.292969 33.011719 84.328125 51.234375 C 84.359375 69.484375 69.585938 84.300781
                    51.332031 84.332031 C 51.324219 84.332031 51.320312 84.332031 51.308594 84.332031 Z M 51.308594 84.332031" />
            </svg>
            <div style="margin: 0px 16px">
                <select v-model="searchType" class="select">
                    <option value="id">课程 ID</option>
                    <option value="name">标题</option>
                </select>
            </div>
            <div style="width: 100%; margin: 0px 16px">
                <input v-model="searchContent" class="inputbox" style="width: 100%; margin-right: 16px"
                    @keypress.enter="search(searchType, searchContent)"
                />
            </div>
        </div>
        <div v-for="course in courseList" :key="course.id">
            <div class="card"
                style="cursor: pointer; justify-content: space-between"
                @click="jump(course.id)"
            >
                <div>
                    <h2 class="list-title">{{ course.title }}</h2>
                </div>
                <svg viewBox="0 0 512 512" width="32" height="32">
		            <path fill="#79C1E5" d="M423.386,248.299l-256-245.327c-4.208-4.021-10.833-3.958-14.927,0.167l-64,63.998c-2.042,2.042-3.167,4.812-3.125,7.687
		                c0.042,2.896,1.25,5.625,3.344,7.604l183.792,173.579L88.678,429.586c-2.094,1.979-3.302,4.708-3.344,7.604
		                c-0.042,2.875,1.083,5.646,3.125,7.687l64,63.998c2.083,2.083,4.813,3.125,7.542,3.125c2.656,0,5.313-0.979,7.385-2.958
		                l256-245.327c2.094-2.021,3.281-4.792,3.281-7.708C426.667,253.09,425.48,250.319,423.386,248.299z"/>
                </svg>
            </div>
        </div>
    </div>
</template>

<script>
import methods from '../../methods.js';

export default {
    name: 'ManagerCourse',
    data: function () {
        /*
        var courses = [
            { id: 1000, title: '这是零个课程名字大概有这——么长' },
            { id: 1001, title: '这是一个课程名字大概有这——么长' },
            { id: 1002, title: '这是两个课程名字大概有这——么长' },
            { id: 1003, title: '这是一个课程名字大概有这——么长' },
            { id: 1004, title: '这是一个课程名字大概有这——么长' },
            { id: 1005, title: '这是一个课程名字大概有这——么长' },
        ];
        */
        var courses = this.getCourses();
        return {
            courses: courses,
            courseList: courses,
            searchType: 'id',
            searchContent: ''
        };
    },
    methods: {
        getCourses() {
            var list = [];
            methods.getCourses((data) => {
                for (var item of data)
                    list.push({
                        id: item.courseId,
                        title: item.title
                    });
            });
        },
        addCourse() {
        },
        search(type, content) {
            this.courses = this.getCourses();
            if (type == 'id') {
                var flag = true;
                for (var course of this.courses)
                    if (course.id == content)
                    {
                        flag = false;
                        this.$router.push({ name: 'ManagerCourseDetails', params: { id: course.id }});
                    }
                if (flag)
                    window.alert('No result');
            }
            else if (type == 'name') {
                var list = [];
                for (var course of this.courses)
                    if (course.title.includes(content))
                        list.push(course);
                this.courseList = list;
            }
        },
        jump(id) {
            this.$router.push({ name: 'ManagerCourseDetails', params: { id: id }});
        }
    }
}
</script>