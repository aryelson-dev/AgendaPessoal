import { createRouter, createWebHistory } from 'vue-router'
import Contato from '../views/Contato.vue'
import Compromisso from '../views/Compromisso.vue'
import ContatoForm from '../views/ContatoForm.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Contato
    },
    {
      path: '/contato',
      name: 'contato',
      component: Contato
    },
    {
      path: '/compromisso',
      name: 'compromisso',
      component: Compromisso
    },
    {
      path: '/novocontato',
      name: 'novocontato',
      component: ContatoForm
    }
  ]
})

export default router
