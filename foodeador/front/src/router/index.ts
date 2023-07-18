import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    alias: "/principal",
    name: "principal",
    component: () => import("./../components/Principal.vue"),
  },
  {
    path: "/identificacion",
    name: "identificacion",
    component: () => import("./../components/Identificacion.vue"),
  },
  {
    path: "/registro",
    name: "registro",
    component: () => import("./../components/Registro.vue"),
  },

  {
    path: "/miUsuario",
    name: "miUsuario",
    component: () => import("./../components/MiUsuario.vue"),
  },

  {
    path: "/guardarSupermercado",
    name: "guardarSupermercado",
    component: () => import("./../components/GuardarSupermercado.vue"),
  },
  {
    path: "/guardarProducto",
    name: "guardarProducto",
    component: () => import("./../components/GuardarProducto.vue"),
  },

  {
    path: "/detalleProducto/:id",
    name: "detalleProducto",
    component: () => import("./../components/DetalleProducto.vue"),
  },

  {
    path: "/detalleSupermercado/:id",
    name: "detalleSupermercado",
    component: () => import("./../components/DetalleSupermercado.vue"),
  },

  {
    path: "/guardarPrecio",
    name: "guardarPrecio",
    component: () => import("./../components/GuardarPrecio.vue"),
  },

  {
    path: "/buscarSupermercados",
    name: "buscarSupermercados",
    component: () => import("./../components/BuscarSupermercados.vue"),
  },

  {
    path: "/buscarProductos",
    name: "buscarProductos",
    component: () => import("./../components/BuscarProductos.vue"),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
