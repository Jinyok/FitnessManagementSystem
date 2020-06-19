<template>
    <el-container>
        <el-aside class="green" style="width: 240px">
            <asidebuttonlist @select="change" @exit="exit"></asidebuttonlist>
            <div style="width:2px; position:absolute; top:0; left:240px;
            height:100%; background:#cccccc"></div>
        </el-aside>

        <el-main  style="background: #E5E5E5">
            <pagecoursemanager v-show="showpage.showPageCourseManager"></pagecoursemanager>
            <pagecourses v-show="showpage.showPageCourses"></pagecourses>
        </el-main>
    </el-container>
</template>

<script>
import asidebuttonlist from './asidebuttonlist.vue'
import pagecoursemanager from './PageCourseManager.vue'
import pagecourses from './PageCourses'

export default {
    name: 'ReceptionView',
    components: {
        asidebuttonlist,
        pagecoursemanager,
        pagecourses
    },
    data() {
        return {
            showpage: {
                showPageCourseManager: true,
                showPageCourses: false
            }
        }
    },
    methods: {
        change: function (con) {
            if (con=='COURSE MANAGER') {
                this.$set(this.showpage, 'showPageCourseManager', true)
                this.$set(this.showpage, 'showPageCourses', false)
            }
            else if (con=='COURSES') {
                this.$set(this.showpage, 'showPageCourseManager', false)
                this.$set(this.showpage, 'showPageCourses', true)
            }
        },
        exit: function () {
            this.$router.push({ path: '/reception/login' })
        }
    }
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
.green {
    background-color: #78D386;
    color: #ffffff;
  }

</style>
