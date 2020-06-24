<template>
<div class = "CoachLogin">
<el-container>
    <el-header class="red" style="height: 370px">
        <div class="div_content" style="top: 210px">
            <span style="font-size: 40px; letter-spacing:18px">教练</span>
            <br>
            <strong style="font-size: 90px; letter-spacing:15px; line-height:84px">LOGIN</strong>
        </div>
    </el-header>

    <el-main>
        <div class="div_content" style="margin-top: 23px">
            <el-input placeholder="用户名" v-model="input_account" clearable>
            </el-input>
        </div>
        <div class="div_content" style="margin-top: 75px">
            <el-input placeholder="密码" v-model="input_password" show-password>
            </el-input>
        </div>
        <div class="div_content" style="margin-top: 140px" @click="routeToView">
            <el-button type="danger" round>登 录</el-button>
        </div>
        <div class="div_content" style="bottom: 50px">
            <el-link type="info" @click="routeToReception">会员登陆</el-link>
            <span style="color:#909399;">&emsp;/&emsp;</span>
            <el-link type="info" @click="routeToManager">教练登录</el-link>
            <span style="color:#909399">&emsp;/&emsp;</span>
            <el-link type="info" @click="routeToAdmin">管理员登录</el-link>
        </div>
    </el-main>
</el-container>
</div>
</template>

<script>
export default {
    name: 'CoachLogin',
    data () {
        return {
            input_account: '',
            input_password: ''
        }
    },
    methods: {
        login: function() {
            // code here
        },
        routeToView: function() {
            this.$router.push({ path:'/coach' })
        },
        routeToReception: function() {
            this.$router.push({ path:'/reception/login' })
        },
        routeToManager: function() {
            this.$router.push({ path:'/manager/login' })
        },
        routeToAdmin: function() {
            this.$router.push({ path:'/admin/login' })
        }
    }
};

</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
.div_content{
  width: 400px;
  position: absolute;
  left: 50%;
  margin-left: -200px;
  text-align:center;
  font-family: "HW-Bold", Arial, Helvetica, sans-serif;
}
html,body,#app,.el-container{
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
