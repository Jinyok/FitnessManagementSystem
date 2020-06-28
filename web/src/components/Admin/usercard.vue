<template>
    <div class='usercard card' style="justify-content: space-between; cursor: pointer;" @click="goToDetail">
        <div style="font-size: 25px">{{ User.userName }}</div>
        <div style="color: #929292; display: flex; align-items:center;">
            <div style="padding-right: 20px; font-size: 18px">{{ role_text }}</div>
            <img src="../../assets/imgs/jumpI.png" style="max-width: 40px">
        </div>
    </div>
</template>

<script>
import methods from '../../methods'
export default {
    name: 'usercard',
    props: {
        User: {
            userId: '',
            userName: '',
            role: '',
            number: ''
        }
    },
    data() {
        return {
            role_text: ''
        }
    },
    methods: {
        goToDetail: function () {
            this.$router.push({ path:'/admin/usersdetail' ,query: { User : this.User } })
        }
    },
    created: function () {
        switch (this.User.role) {
            case 'Root': this.role_text = '根用户'; break;
            case 'Admin': this.role_text = '管理员'; break;
            case 'Coach': this.role_text = '教练'; break;
            case 'Clerk': this.role_text = '人事'; break;
            case 'Member': this.role_text = '会员'; break;
        }
    }
}
</script>

<style>

</style>
