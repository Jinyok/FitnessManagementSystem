<template>
<div class = "AdminLogin">
<el-container>
    <el-header class="grey" style="height: 370px">
        <div class="div_content" style="top: 210px">
            <span style="font-size: 35px; letter-spacing:18px">ADMIN</span>
            <br>
            <strong style="font-size: 90px; letter-spacing:15px; line-height:84px">LOGIN</strong>
        </div>
    </el-header>

    <el-main>
        <div class="div_content" style="margin-top: 23px">
            <el-input placeholder="ACCOUNT" v-model="input_account" clearable>
            </el-input>
        </div>
        <div class="div_content" style="margin-top: 75px">
            <el-input placeholder="PASSWORD" v-model="input_password" show-password>
            </el-input>
        </div>
        <div class="div_content" style="margin-top: 140px" @click="routeToView">
            <el-button type="info" round>SIGN IN</el-button>
        </div>
        <div class="div_content" style="bottom: 50px">
            <el-link type="info" @click="routeToReception">Login as reception </el-link>
            <span style="color:#909399">/</span>
            <el-link type="info" @click="routeToManager">Login as manager </el-link>
            <span style="color:#909399">/</span>
            <el-link type="info" @click="routeToCoach">Login as coach</el-link>
        </div>
    </el-main>
</el-container>
</div>
</template>

<script>
export default {
    name: 'AdminLogin',
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
            this.$router.push({ path:'/admin' })
        },
        routeToReception: function() {
            this.$router.push({ path:'/reception/login' })
        },
        routeToManager: function() {
            this.$router.push({ path:'/manager/login' })
        },
        routeToCoach: function() {
            this.$router.push({ path:'/coach/login' })
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
  font-family: "Roboto-Medium", Arial, Helvetica, sans-serif;
}
html,body,#app,.el-container{
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
