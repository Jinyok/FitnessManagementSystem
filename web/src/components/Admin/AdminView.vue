<template>
    <el-container>
        <el-aside class="grey" style="width: 240px">
            <asidebuttonlist @select="change" @exit="exit"></asidebuttonlist>
            <div style="width:2px; position:absolute; top:0; left:240px;
            height:100%; background:#cccccc"></div>
        </el-aside>

        <el-main  style="background: #E5E5E5">
            <pagehome v-show="showpage.showPageHome"></pagehome>
            <pageschedule v-show="showpage.showPageSchedule"></pageschedule>
            <pagecourses v-show="showpage.showPageCourses"></pagecourses>
        </el-main>
    </el-container>
</template>

<script>
import asidebuttonlist from './asidebuttonlist.vue'
import pagehome from './PageHome.vue'
import pageschedule from './PageSchedule'
import pagecourses from './PageCourses'

export default {
    name: 'AdminView',
    components: {
        asidebuttonlist,
        pagehome,
        pageschedule,
        pagecourses
    },
    data() {
        return {
            showpage: {
                showPageHome: true,
                showPageSchedule: false,
                showPageCourses: false
            }
        }
    },
    methods: {
        change: function (con) {
            if (con=='HOME') {
                this.$set(this.showpage, 'showPageHome', true)
                this.$set(this.showpage, 'showPageSchedule', false)
                this.$set(this.showpage, 'showPageCourses', false)
            }
            else if (con=='SCHEDULE') {
                this.$set(this.showpage, 'showPageHome', false)
                this.$set(this.showpage, 'showPageSchedule', true)
                this.$set(this.showpage, 'showPageCourses', false)
            }
            else if (con=='COURSES') {
                this.$set(this.showpage, 'showPageHome', false)
                this.$set(this.showpage, 'showPageSchedule', false)
                this.$set(this.showpage, 'showPageCourses', true)
            }
        },
        exit: function () {
            this.$router.push({ path: '/admin/login' })
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
.grey {
    background-color: #929292;
    color: #ffffff;
  }

</style>
