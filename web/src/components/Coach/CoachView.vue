<template>
    <el-container>
        <el-aside class="red" style="width: 240px">
            <asidebuttonlist @select="change" @exit="exit"></asidebuttonlist>
            <div style="width:2px; position:absolute; top:0; left:240px;
            height:100%; background:#cccccc"></div>
        </el-aside>

        <el-main  style="background: #E5E5E5">
            <router-view></router-view>
        </el-main>
    </el-container>
</template>

<script>
import methods from '../../methods.js'
import asidebuttonlist from './asidebuttonlist.vue'

export default {
    name: 'CoachView',
    components: {
        asidebuttonlist,
    },
    data() {
        return {
            showpage: {
                showPageHome: true,
                showPageSchedule: false,
                showPageCourses: false
            },
            //需要查
            coachInfo: {
                ID: '00000000',
                Name: '未命名',
                Email: 'unknown@email.com',
                PhoneNo: '000-0000-0000' 
            },
            //需要查
            sections:[
                {
                    SectionId : 1,
                    CourseId  : 1,
                    CoachId   : 1,
                    StartDate : 1592614200,
                    EndDate   : 1592626500,
                    SectionNumber : 10,
                    Title     : '肌肉塑形',
                    ClassHour : 15
                },
                {
                    SectionId : 2,
                    CourseId  : 1,
                    CoachId   : 1,
                    StartDate : 1592700600,
                    EndDate   : 1592712900,
                    SectionNumber : 6,
                    Title     : '快速减脂',
                    ClassHour : 8
                }
            
            ],
        }
    },
    methods: {
        change: function (con) {
            switch (con) {
                case 'HOME':
                    this.$router.push ({ name: 'CoachHome', 
                        query: { info: this.coachInfo, firstSection: this.sections[0] }
                        })
                    break;
                case 'SCHEDULE':
                    this.$router.push ('/coach/schedule');
                    break;
                case 'COURSES':
                    this.$router.push ({ name:'CoachCourses', 
                        query: { sections: this.sections }
                        });
                    break;
            }
        },
        exit: function () {
            this.$router.push({ path: '/coach/login' })
        }
    },
}

</script>

<style>
html,body,.el-container{
    /*设置内部填充为0*/
    padding: 0px;
     /*外部间距为0*/
    margin: 0px;
    /*高度为100%*/
    height: 100%;
  }
.red {
    background-color: #de5757;
    color: #ffffff;
  }

</style>
