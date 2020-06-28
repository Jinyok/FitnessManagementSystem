<template>
    <div class="login" style="with:100%; height: 100%">
        <div style="display: flex; flex-direction: column; height: 50%; background: #79c1e5; color: #ffffff; justify-content: flex-end;">
            <p style="margin: 0px; user-select: none; font-size: 40px; letter-spacing:18px">人事</p>
            <p style="margin: 0px; margin-bottom: 12px; user-select: none; font-size: 90px; letter-spacing:15px; line-height:84px"><strong>LOGIN</strong></p>
        </div>

        <div>
            <div style="margin-top: 40px;">
                <p><input placeholder="用户名" v-model="input_account" /></p>
                <p><input type="password" placeholder="密码" v-model="input_password" /></p>
            </div>
            <button @click="routeToView" style="background: #79c1e5">登录</button>
            <p style="position: absolute; margin: 0px auto; color: #aaaaaa; bottom: 50px; left: 0px; right: 0px;">
                <span @click="routeToCoach" style="cursor: pointer">教练登录 </span>
                <span> / </span>
                <span type="info" @click="routeToAdmin" style="cursor: pointer">管理员登录</span>
            </p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'ManagerLogin',
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
            this.$router.push({ path:'/manager' })
        },
        routeToAdmin: function() {
            this.$router.push({ path:'/admin/login' })
        },
        routeToCoach: function() {
            this.$router.push({ path:'/coach/login' })
        }
    }
};
</script>

<style>
@import url("../../assets/css/font.css");

html,body,#app {
    /*设置内部填充为0*/
    padding: 0px;
     /*外部间距为0*/
    margin: 0px;
    /*高度为100%*/
    height: 100%;
}

.login div {
    text-align: center;
    font-family: "Roboto", "SourceHan", Arial, Helvetica, sans-serif;
    user-select: none;
}

.login input {
    font-family: "Roboto", "SourceHan", Arial, Helvetica, sans-serif;
    font-size: 12px;
    width: 240px;
    padding: 8px 16px;
    border: 1px solid #b0b0b0;
    border-radius: 5px;
}

.login input:focus {
    outline: none;
    border: 1px solid #79c1e5;
}

.login button {
    font-family: "Roboto", "SourceHan", Arial, Helvetica, sans-serif;
    font-size: 12px;
    color: #ffffff;
    border: none;
    padding: 8px 24px;
    border-radius: 16px;
    cursor: pointer;
}
</style>
