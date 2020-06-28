import Vue from 'vue'
import App from './App.vue'
import router from './router.js'
import ElementUI from 'element-ui'
import '../theme/index.css'

Vue.use(ElementUI)

new Vue({
  router,
  render: h => h(App),
  data () {
    return {
      myEvent: new Vue()
    }
  }
}).$mount('#app')
