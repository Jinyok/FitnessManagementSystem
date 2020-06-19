<template>
  <div class="asidebuttonlist">
    <div class="div_aside">
      <h1 style="font-size: 32px">ADMIN<br></h1>
    </div>

    <asidebutton content="HOME" @select="reselect"></asidebutton>
    <asidebutton content="SCHEDULE" @select="reselect"></asidebutton>
    <asidebutton content="COURSES" @select="reselect"></asidebutton>

    <div style="position:absolute;bottom: 10px">
      <asidebutton content="EXIT" @select="reselect"></asidebutton>
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
      
      if (con === 'EXIT')
        this.$emit('exit')

      this.$emit('select', con)
    }
  },
  mounted: function () {
    var allasidebutton = this.$children
      for (var i = 0; i < allasidebutton.length; i++) {
          allasidebutton[i].bgcolor_="#929292" 
          allasidebutton[i].bgcolorMoveover_="#aaaaaa"
          allasidebutton[i].button_mouseleave()
      }
      allasidebutton[0].button_click()
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
  font-family: "Roboto_Medium", Arial, Helvetica, sans-serif;
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
