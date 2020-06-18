<template>
    <el-container>
        <el-aside class="red" style="width: 240px">
            <asidebuttonlist></asidebuttonlist>
        </el-aside>
    </el-container>
</template>

<script>
import asidebuttonlist from './asidebutton/asidebuttonlist.vue'

export default {
    name: 'CoachView',
    components: {
        asidebuttonlist
    }
}

</script>

<style>
html,body,.el-container{
    /*设置内部填充为0*/
    padding: 0px;
     /*外部间距为0*/
    margin: 0px;
    /*高度为100%*/
    height: 100%;
  }
.red {
    background-color: #de5757;
    color: #ffffff;
  }

</style>
