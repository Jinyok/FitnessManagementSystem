<template>
    <div class="AdminRegister">
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
                        <el-select v-model="input_role">
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
                <el-link :underline="false" style="font-size:20px;" @click="submit">创建账户</el-link>
            </div>
        </div>
    </div>
</template>

<script>
import methods from '../../methods.js'

export default {
    name: 'AdminRegister',
    data() {
        return {
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
        submit: function () {
            if ((this.input_role == '选项1' || this.input_role == '选项2')) {
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

            var Role
            switch (this.input_role) {
                case '选项1':
                    Role = 'Coach'
                    break;
                case '选项2':
                    Role = 'Member'
                    break;
                case '选项3':
                    Role = 'Clerk'
                    break;
                case '选项4':
                    Role = 'Admin'
                    break;
            }

            methods.AddUser({
                    userName: this.input_account,
                    password: this.input_password,
                    role: Role
                }, {
                    name: this.input_name,
                    phoneNo: this.input_phone,
                    email: this.input_email
                },function() { alert('完成创建') } )
        }
    },
    watch: {
        input_role(val) {
            switch(val) {
                case '选项1': this.showMore = true; this.showEmail = true; break;
                case '选项2': this.showMore = true; this.showEmail = false; break;
                default: this.showMore = false; this.showEmail = false; break;
            }
        }

    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>
