<template>
  <div class="asidebutton">
    <div class="basestyle" :style = "currentcolor"
      @mouseenter="button_mouseenter"
      @mouseleave="button_mouseleave"
      @click="button_click">
    {{ content }}
    </div>
  </div>
</template>

<style>
@import url("../assets/css/font.css");
</style>

<script>
export default {
  name: 'asidebutton',
  data () {
    return {
        bgcolor_: '',
        bgcolorMoveover_: '',
        selected: false,
        currentcolor: {
          background: '#ff0000',
          color: '#ffffff'
        }
    }
  },
  props: {
    content: {
        type: String,
        default: ''
    },
    bgcolor: {
        type: String,
        default: '#ff0000'
    },
    bgcolorMoveover: {
        type: String,
        default: 'aa0000'
    }
  },
  methods: {
    button_mouseenter: function() {
      if (!this.selected) {
        this.currentcolor.background=this.bgcolorMoveover_
        this.currentcolor.color="#ffffff"
      }
    },
    button_mouseleave: function() {
      if (!this.selected) {
        this.currentcolor.background=this.bgcolor_
        this.currentcolor.color="#ffffff"
      }
    },
    button_click: function() {
      if (!this.selected) {
        this.currentcolor.background="#ffffff"
        this.currentcolor.color=this.bgcolor_

        this.$emit('select', this.content)
        this.selected=true
      }
    },
    reselect: function(con) {
      if (this.content != con) {
        this.selected=false
        this.button_mouseleave()
      }
    }
  },
  mounted: function() {
    this.bgcolor_= this.bgcolor
    this.bgcolorMoveover_=this.bgcolorMoveover
  }
}
</script>

<style>
.basestyle {
  width: 222px;
  padding-left: 18px;
  padding-top: 7px;
  padding-bottom: 7px;
  text-align: start;
  font-size: 23px;
  letter-spacing: 2px;
  font-family: 'Roboto', Arial, Helvetica, sans-serif;
  cursor: pointer;
}
</style>
