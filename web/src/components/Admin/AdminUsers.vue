<template>
    <div class="AdminUsers">
        <div class="card" style="background:#c4c4c4; height: 30px"></div>
        <div v-for="user in AllUsers" :key='user.userId'>
            <br>
            <usercard :User="user"></usercard>
        </div>
    </div>
</template>

<script>
import usercard from './usercard.vue'
import methods from '../../methods.js'

export default {
    name: 'AdminUsers',
    components: {
        usercard
    },
    data() {
        return {
            AllUsers:[],
        }
    },
    created: function () {
        var this_ = this
        methods.GetAllUsers(function(res) {
            this_.AllUsers = res
            console.log(this_.AllUsers)
        })
    }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>

<style>
</style>