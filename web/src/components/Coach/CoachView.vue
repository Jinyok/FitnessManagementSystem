<template>
    <el-container>
        <el-aside class="red" style="width: 240px">
            <asidebuttonlist @select="change" @exit="exit"></asidebuttonlist>
            <div style="width:2px; position:absolute; top:0; left:240px;
            height:100%; background:#cccccc"></div>
        </el-aside>

        <el-main  style="background: #E5E5E5">
            <keep-alive>
                <router-view v-if="$route.meta.keepAlive"></router-view>
            </keep-alive>
                <router-view v-if="!$route.meta.keepAlive"></router-view>
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
            coachId: 1
        }
    },
    methods: {
        change: function (con) {
            switch (con) {
                case '主页':
                    if (this.$router.history.current.fullPath != '/coach/home')
                        this.$router.push ({ path: '/coach/home', query:{ coachId: this.coachId } })
                    break;
                case '课程表':
                    this.$router.push ({ path: '/coach/schedule', query:{ coachId: this.coachId } });
                    break;
                case '我的课程':
                    this.$router.push ({ path: '/coach/courses', query:{ coachId: this.coachId } });
                    break;
                case '私人指导':
                    this.$router.push ({ path: '/coach/instruct', query:{ coachId: this.coachId } });
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
