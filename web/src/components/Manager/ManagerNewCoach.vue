<template>
    <div class="card" style="justify-content: space-between">
        <form>
            <div>
                <span class="info">账号 :</span>
                <input v-model="info.account" class="inputbox" style="margin-left: 16px">
            <div>
                <span class="info">姓名 :</span>
                <input v-model="info.name" class="inputbox" style="margin-left: 16px">
            </div>
            <div>
                <span class="info">联系电话 :</span>
                <input v-model="info.phone" class="inputbox" style="margin-left: 16px">
            </div>
            <div>
                <span class="info">电子邮箱 :</span>
                <input v-model="info.email" class="inputbox" style="margin-left: 16px">
            </div>
        </form>
        <div>
            <p style="cursor: pointer; color: #79C1E5; margin: 0px 16px;"
                @click="submitAdd()"
            >
                确认
            </p>
            <p style="cursor: pointer; color: #b0b0b0; margin: 0px 16px;"
                @click="discardAdd()"
            >
                放弃
            </p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'ManagerNewCoach',
    data: function () {
        return {
            account: '', name: '', phone: '', email: ''
        };
    },
    methods: {
        submitAdd() {
            this.back();
        },
        discardAdd() {
            this.back();
        },
        back() {
            this.$router.go(-1);
        }
    }
}
</script>