<template>
  <div class="asidebutton">
    <div class="div_asidebutton"
      v-bind:class="{
      'div_asidebutton untouched': button_untouched,
      'div_asidebutton moveover': button_moveover,
      'div_asidebutton selected': button_selected }"
      @mouseenter="button_mouseenter"
      @mouseleave="button_mouseleave"
      @click="button_click">
    {{ content }}
    </div>
  </div>
</template>

<style>
@import url("../../../assets/css/font.css");
</style>

<script>
export default {
  name: 'asidebutton',
  data () {
    return {
        button_untouched: true,
        button_moveover: false,
        button_selected: false
    }
  },
  props: {
    content: {
        type: String,
        default: ''
    },
    
  },
  methods: {
    button_mouseenter: function() {
      if (!this.button_selected) {
        this.button_moveover=true
        this.button_untouched=false
      }
    },
    button_mouseleave: function() {
      if (!this.button_selected) {
        this.button_moveover=false
        this.button_untouched=true
      }
    },
    button_click: function() {
      if (!this.button_selected) {
        this.button_selected=true
        this.button_moveover=false
        this.button_untouched=false
        this.$emit('select', this.content)
      }
    },
    reselect: function(con) {
      if (this.content != con) {
        this.button_selected=false
        this.button_moveover=false
        this.button_untouched=true
      }
      else {
        this.button_selected=true
        this.button_moveover=false
        this.button_untouched=false
      }
    }
  }
}
</script>

<style>
.div_asidebutton{
  width: 222px;
  padding-left: 18px;
  padding-top: 7px;
  padding-bottom: 7px;
  text-align: start;
  font-size: 23px;
  letter-spacing: 2px;
  font-family: "Roboto", Arial, Helvetica, sans-serif;
}

.untouched{
  background:#de5757;
  color: #ffffff;
  cursor: pointer;
}

.moveover{
  background: #de8080;
  color: #ffffff;
  cursor: pointer;
}

.selected{
  background: #ffffff;
  color: #de5757;
}
</style>
