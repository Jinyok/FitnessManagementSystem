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
                <el-link :underline="false" style="font-size:20px;" @click="submit">提交修改</el-link>
                <br>
                <el-link :underline="false" style="font-size:20px;" @click="reset">重置修改</el-link>
                <br>
                <el-link :underline="false" style="font-size:20px;" @click="dele">删除账号</el-link>
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
            UserInfo: {
            },
            ExtraInfo: {
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
                    label: '人事'
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
            this.showMore = false
            this.showEmail = false

            var this_ = this

            this.input_account = this.UserInfo.userName
            this.input_password = this.UserInfo.password
            this.input_role = this.UserInfo.role

            if (this.input_role == 'Member')  {
                methods.GetUserInfo(this_.UserInfo, function(res) {
                    this_.ExtraInfo = res
                    this_.showMore = true
                    this_.input_name = this_.ExtraInfo.name
                    console.log(this_.ExtraInfo.phoneNo)
                    this_.input_phone = this_.convertPhoneNo( this_.ExtraInfo.phoneNo )
                    console.log(this.UserInfo)
                    console.log(this.ExtraInfo)
                } )
            }
            else if (this.input_role == 'Coach') {
                methods.GetUserInfo(this_.UserInfo, function(res) {
                    this_.ExtraInfo = res
                    this_.showMore = true;
                    this_.showEmail = true;
                    this_.input_name = this_.ExtraInfo.name
                    this_.input_phone = this_.convertPhoneNo( this_.ExtraInfo.phoneNo )
                    this_.input_email = this_.ExtraInfo.email
                } )
            }
        },
        submit: function () {
            if ((this.UserInfo.role == 'Coach' || this.UserInfo.role == 'Member')) {
                if (this.input_phone.length != 11) {
                    alert ('请填写11位电话号码')
                    return
                }
                else for (var i=0; i<11; i++)
                    if (this.input_phone[i]<'0'||this.input_phone[i]>'9') {
                        alert ('请填写11位电话号码')
                        return
                    }
                
                if (this.input_name.length==0) {
                    alert ('请填写姓名')
                    return
                }
            }

            if (this.input_account.length == 0){
                    alert ('请填写用户名')
                    return
                }

            if (this.input_password.length == 0){
                    alert ('请填写密码')
                    return
                }
            
            this.UserInfo.userName = this.input_account
            this.UserInfo.password = this.input_password
            this.ExtraInfo.name = this.input_name
            this.ExtraInfo.phoneNo = this.input_phone
            this.ExtraInfo.email = this.input_email

            var this_ = this
            methods.SubmitUserInfo(this.UserInfo, this.ExtraInfo, function () {
                this_.reset()
            })
        },
        dele: function () {
            methods.DeleteUser(this.UserInfo, function() {alert('账号已删除')} )
            this.$router.push('users')
        },
        convertPhoneNo: function (phoneNo) {
            var tempNo = phoneNo[0]+phoneNo[1]+phoneNo[2]+phoneNo[4]+phoneNo[5]+phoneNo[6]+phoneNo[7]+phoneNo[9]+phoneNo[10]+phoneNo[11]+phoneNo[12]
            return tempNo
        }
    },
    created: function () {
        this.UserInfo = this.$route.query.User
        this.ExtraInfo = this.$route.query.ExtraInfo

        this.reset()
    }
}
</script>

