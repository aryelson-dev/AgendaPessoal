import { createRouter, createWebHistory } from 'vue-router'
import Contato from '../views/Contato.vue'
import Compromisso from '../views/Compromisso.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/contato',
      name: 'contato',
      component: Contato
    },
    {
      path: '/compromisso',
      name: 'compromisso',
      component: Compromisso
    }
  ]
})

export default router
