import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'


import { library } from '@fortawesome/fontawesome-svg-core'


import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'


import { faAppleWhole } from '@fortawesome/free-solid-svg-icons'
import { faCartShopping } from '@fortawesome/free-solid-svg-icons'


library.add(faAppleWhole)
library.add(faCartShopping)

createApp(App).use(store).component('font-awesome-icon', FontAwesomeIcon).use(router).mount('#app')
