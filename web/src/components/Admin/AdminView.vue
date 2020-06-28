<template>
    <el-container>
        <el-aside class="grey" style="width: 240px">
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
import asidebuttonlist from './asidebuttonlist.vue'

export default {
    name: 'AdminView',
    components: {
        asidebuttonlist
    },
    data() {
        return {
        }
    },
    methods: {
        change: function (con) {
            switch (con) {
                case '账户管理': 
                    this.$router.push({ path:'/admin/users' }); break;
                case '注册账户':
                    this.$router.push({ path:'/admin/register' }); break;
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
    background: #929292;
    color: #ffffff;
  }

.card {
    overflow: hidden;
    padding: 23px 30px;
    background:white;
    font-family: "Roboto", "SourceHan", Arial, Helvetica, sans-serif;
    display:flex;
    align-items: center;
}

</style>
