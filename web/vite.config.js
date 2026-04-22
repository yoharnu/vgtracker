import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-vue';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    server: {
      port: 64605,
      proxy: {
        '/api': {
          target: 'http://localhost:5025', // Your backend API server
          changeOrigin: true,
        },
      },
    }
})
