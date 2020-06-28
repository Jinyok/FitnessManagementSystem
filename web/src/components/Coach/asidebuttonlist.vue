<template>
  <div class="asidebuttonlist">
    <div class="div_aside">
      <h1 style="font-size: 35px">教练<br></h1>
    </div>

    <asidebutton content="主页" @select="reselect"></asidebutton>
    <asidebutton content="课程表" @select="reselect"></asidebutton>
    <asidebutton content="我的课程" @select="reselect"></asidebutton>
    <asidebutton content="私人指导" @select="reselect"></asidebutton>

    <div style="position:absolute;bottom: 10px">
      <asidebutton content="退出" @select="reselect"></asidebutton>
    </div>

  </div>
</template>

<script>
import asidebutton from '../asidebutton.vue'

export default {
  name: "asidebuttonlist",
  components: {
    asidebutton
  },
  methods: {
    reselect: function (con) {
      var allasidebutton = this.$children
      for (var i = 0; i < allasidebutton.length; i++) {
        allasidebutton[i].reselect(con)
      }
      
      if (con === '退出')
        this.$emit('exit')

      this.$emit('select', con)
    }
  },
  mounted: function () {
    var allasidebutton = this.$children
      for (var i = 0; i < allasidebutton.length; i++) {
          allasidebutton[i].bgcolor_="#de5757" 
          allasidebutton[i].bgcolorMoveover_="#de8888"
          allasidebutton[i].button_mouseleave()
      }
      allasidebutton[0].button_click()
  },
  watch: {
    $route(to, from) {
      var content
      switch(to.path) {
        case '/coach/home': content='主页'; break;
        case '/coach/schedule': content='课程表'; break;
        case '/coach/courses': content='我的课程'; break;
        case '/coach/instruct': content='私人指导'; break;
      }
      var allasidebutton = this.$children
      for (var i = 0; i < allasidebutton.length; i++) {
        allasidebutton[i].reselect(content)
      }
    }
  }
}
</script>

<style>
@import url("../../assets/css/font.css");
</style>


<style>
.div_aside{
  width: 220px;
  padding-left: 16px;
  text-align: start;
  font-size: 25px;
  font-family: 'Roboto', "SourceHan", Arial, Helvetica, sans-serif;
}

html,body,#app,.el-container{
    /*设置内部填充为0*/
    padding: 0px;
     /*外部间距为0*/
    margin: 0px;
    /*高度为100%*/
    height: 100%;
  }
</style>
