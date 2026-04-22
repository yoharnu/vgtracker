import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import { createBootstrap } from 'bootstrap-vue-next';

// Import Bootstrap and BootstrapVueNext CSS files
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue-next/dist/bootstrap-vue-next.css';

const app = createApp(App)
app.use(createBootstrap());
app.mount('#app')
