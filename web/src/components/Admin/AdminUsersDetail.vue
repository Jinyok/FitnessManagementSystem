<template>
    <div class="AdminUsersDetail">
        <div class = "card" style="cursor: pointer;" @click="goBack">
            <img src="../../assets/imgs/jumpI_Reverse.png" 
                style="max-width: 30px; float:left; margin-right: 12px">
            <div style="font-size: 25px; margin-top: -3px">返回</div>
        </div>
        <br>
        <div class="card font_light" style="justify-content: space-between; align-items: flex-start">
            <div>
                <div style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">用户名</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-input v-model="input_account"></el-input>
                    </div>
                </div>
                <br>
                <div style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">密码</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-input v-model="input_password" show-password></el-input>
                    </div>
                </div>
                <br>
                <div style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">身份</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-select v-model="input_role" disabled>
                            <el-option v-for="item in role_options" 
                            :key="item.value" :label="item.label" :value="item.value">
                            </el-option>
                        </el-select>
                    </div>
                </div>
                <br v-if="showMore">
                <div v-if="showMore" style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">姓名</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-input v-model="input_name"></el-input>
                    </div>
                </div>
                <br v-if="showMore">
                <div v-if="showMore" style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">电话号码</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-input v-model="input_phone"></el-input>
                    </div>
                </div>
                <br v-if="showEmail">
                <div v-if="showEmail" style="font-size:20px; display: flex; align-items: center">
                    <div style="min-width: 100px">Email</div>
                    <div style="width: 300px; margin-left: 10px">
                        <el-input v-model="input_email"></el-input>
                    </div>
                </div>
            </div>
            <div>
                <el-link :underline="false" style="font-size:20px;">提交修改</el-link>
                <br>
                <el-link :underline="false" style="font-size:20px;" @click="reset">重置修改</el-link>
            </div>
        </div>
    </div>
</template>

<script>
import methods from "../../methods.js"

export default {
    name: 'AdminUsersDetail',
    data() {
        return {
            UserInfo: { /*
                UserId: '',
                UserName: '',
                Password: '',
                Role: '',
                Number: '',
                Name: '',
                PhoneNo: '',
                Email: '' */
            },
            input_account: '',
            input_password: '',
            input_role: '',
            input_name: '',
            input_phone: '',
            input_email: '',
            role_options: [ {
                    value: '选项1',
                    label: '教练'
                }, {
                    value: '选项2',
                    label: '学员'
                },{
                    value: '选项3',
                    label: '经理'
                },{
                    value: '选项4',
                    label: '管理员'
                } ],
            showMore: false,
            showEmail: false
        }
    },
    methods: {
        goBack: function () {
            javascript:history.back(-1);
        },
        reset: function () {
            this.input_account = this.UserInfo.UserName
            this.input_password = this.UserInfo.Password
            this.input_role = this.UserInfo.Role

            if (this.input_role == '学员')  {
                this.showMore = true;
                this.input_name = this.UserInfo.Name
                this.input_phone = this.UserInfo.PhoneNo
            }
            else if (this.input_role == '教练') {
                this.showMore = true;
                this.showEmail = true;
                this.input_name = this.UserInfo.Name
                this.input_phone = this.UserInfo.PhoneNo
                this.input_email = this.UserInfo.Email
            }
        }
    },
    activated: function () {
        console.log(this.$route)
        this.UserInfo = methods.GetUserInfo(this.$route.query.UserId).Data
        
        this.reset()
    }
}
</script>

