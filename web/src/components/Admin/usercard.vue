<template>
    <div class='usercard card' style="justify-content: space-between; cursor: pointer;" @click="goToDetail">
        <div style="font-size: 25px">{{ User.UserName }}</div>
        <div style="color: #929292; display: flex; align-items:center;">
            <div style="padding-right: 20px; font-size: 18px">{{ User.Role }}</div>
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
            UserId: '',
            UserName: '',
            Role: '',
            Number: ''
        }
    },
    methods: {
        goToDetail: function () {
            this.$router.push({ path:'/admin/usersdetail' ,query: { UserId : this.User.UserId } })
        }
    }
}
</script>

<style>

</style>
