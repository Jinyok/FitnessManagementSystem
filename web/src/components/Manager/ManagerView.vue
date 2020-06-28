<template>
    <div class="container">
        <sidebar
            title="人事"
            color="#79C1E5"
            colorHover="#92CFED"
            :selectedPage="selectedPage"
            :listItems="['教练管理', '课程管理']"
            @change="change"
            @exit="exit"
        />
        <div class="main">
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
import methods from '../../methods.js';
import sidebar from '../sidebar.vue';

export default {
    name: 'ManagerView',
    components: {
        sidebar
    },
    data: function () {
        var page, index, select;
        var subpages= [
            { name: '教练管理', path: '/manager/coach' },
            { name: '课程管理', path: '/manager/course' }
        ];
        for ([index, page] of subpages.entries ())
        {
            if (this.$router.currentRoute.path == page.path) {
                select = index;
                break;
            }
        }
        return {
            selectedPage: select,
            subpages: subpages
        };
    },
    methods: {
        change (index) {
            this.$router.push (this.subpages[index].path);
        },
        exit () {
            this.$router.push ('/manager/login');
        }
    },
}
</script>

<style>
@import url("../../assets/css/font.css");

html, body, #app, .container{
    padding: 0px;
    margin: 0px;
    height: 100%;
    font-family: "Roboto", "SourceHan";
}

.container {
    display: flex;
}

.main {
    background: #E5E5E5;
    width: 100%;
    padding: 16px;
    overflow: auto;
}

.card {
    display: flex;
    background: #ffffff;
    border-radius: 5px;
    padding: 16px 24px;
    margin-bottom: 16px;
    align-items: center;
}

.list-title {
    margin: 0px;
    color: #444444;
    font-size: 24px;
    font-weight: bold;
}

.list-text {
    margin: 0px;
    color: #444444;
    font-size: 18px;
}

.title {
    margin: 0px;
    margin-bottom: 16px;
    font-weight: bold;
    font-size: 28px;
    color: #444444;
}

.info {
    margin: 8px 0px;
    color: #b0b0b0;
    font-size: 16px;
}

input.inputbox {
    font-family: "Roboto", "SourceHan";
    font-size: 16px;
    color: #444444;
    border: none;
    border-bottom: 1px solid #b0b0b0;
    width: 500px;
    padding: 2px 8px;
}

input.inputbox:focus {
    outline: none;
    border-bottom: 1px solid #79C1E5;
}

select.select {
    font-family: "Roboto", "SourceHan";
    font-size: 16px;
    color: #444444;
    border: none;
    border-bottom: 1px solid #b0b0b0;
    padding: 2px 12px;
}

select.select:focus {
    outline: none;
    border-bottom: 1px solid #79C1E5;
}

</style>