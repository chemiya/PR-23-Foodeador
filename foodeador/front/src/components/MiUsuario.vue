<template>
  <div>
    <div class="aviso" v-if="mostrarAviso">{{ mensaje }}</div>
    <div class="navbar p-pequeno">
      <div class="icono-div">
        <img src="./../assets/icono.png" class="icono-navbar" />
      </div>

      <div class="links">
        <router-link to="/buscarProductos" class="boton m-derecha"
          >Buscar productos</router-link
        >
        <router-link to="/buscarSupermercados" class="boton m-derecha"
          >Buscar supermercados</router-link
        >
      </div>
    </div>

    <div class="container">
      <div class="fila-responsive-titulos">
        <h1 class="m-derecha">Mis productos guardados</h1>
        <router-link to="/guardarProducto" class="boton centrado"
          >Guardar producto</router-link
        >
      </div>

      <div v-if="!ningunProducto" class="fila-responsive p-pequeno">
        <div
          v-for="(producto, index) in productosUsuario"
          :key="index"
          class="tercio"
        >
          <CartaProductoVue
            :producto="producto"
            :mostrarBotones="true"
            @actualizar="recargar"
          />
        </div>
      </div>
      <div v-else class="p-pequeno">
        <h3>Ningún producto creado</h3>
      </div>
    </div>

    <div class="container">
      <div class="fila-responsive-titulos">
        <h1 class="m-derecha">Mis supermercados guardados</h1>
        <router-link to="/guardarSupermercado" class="boton centrado"
          >Guardar supermercado</router-link
        >
      </div>
      <div v-if="!ningunSupermercado" class="fila-responsive p-pequeno">
        <div
          v-for="(supermercado, index) in supermercadosUsuario"
          :key="index"
          class="tercio"
        >
          <CartaSupermercadoVue
            :supermercado="supermercado"
            :mostrarBotones="true"
            @actualizar="recargar"
          />
        </div>
      </div>
      <div v-else class="p-pequeno">
        <h3>Ningún supermercado creado</h3>
      </div>
    </div>

    <div class="container">
      <div class="fila-responsive-titulos">
        <h1 class="m-derecha">Mis precios guardados</h1>
      </div>
      <div v-if="!ningunPrecio" class="fila-responsive p-pequeno">
        <div
          v-for="(precio, index) in preciosUsuario"
          :key="index"
          class="tercio"
        >
          <CartaPrecioVue :precio="precio" />
        </div>
      </div>
      <div v-else class="p-pequeno">
        <h3>Ningún precio creado</h3>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import FoodeadorDataService from "@/services/FoodeadorDataService";
import Producto from "@/types/Producto";
import Supermercado from "@/types/Supermercado";
import Precio from "@/types/Precio";
import { defineComponent } from "vue";
import ResponseData from "@/types/ResponseData";

import CartaProductoVue from "./CartaProducto.vue";
import CartaSupermercadoVue from "./CartaSupermercado.vue";
import CartaPrecioVue from "./CartaPrecio.vue";

export default defineComponent({
  components: {
    CartaProductoVue,
    CartaSupermercadoVue,
    CartaPrecioVue,
  },
  data() {
    return {
      productosUsuario: [] as Producto[],
      supermercadosUsuario: [] as Supermercado[],
      preciosUsuario: [] as Precio[],
      idUsuario: 0,
      ningunPrecio: false,
      ningunProducto: false,
      ningunSupermercado: false,
      mostrarAviso: false,
      mensaje: "",
    };
  },
  methods: {
    buscarProductosUsuario() {
      FoodeadorDataService.getProductosUsuario(this.idUsuario)
        .then((response: ResponseData) => {
          this.productosUsuario = response.data;
          console.log("productos encontrados");
          if (response.data.length == 0) {
            this.ningunProducto = true;
          }
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    recargar(parametro: any) {
      this.buscarPreciosUsuario(),
        this.buscarProductosUsuario(),
        this.buscarSupermercadosUsuario();

      if (parametro == "eliminadoProducto") {
        this.mensaje = "Producto eliminado";
        this.mostrarAviso=true;
        setTimeout(() => {
          this.mostrarAviso = false;
        }, 5000);
      }

      if (parametro == "eliminadoSupermercado") {
        this.mensaje = "Supermercado eliminado";
        this.mostrarAviso=true;
        setTimeout(() => {
          this.mostrarAviso = false;
        }, 5000);
      }
    },
    buscarSupermercadosUsuario() {
      FoodeadorDataService.getSupermercadosUsuario(this.idUsuario)
        .then((response: ResponseData) => {
          this.supermercadosUsuario = response.data;
          if (response.data.length == 0) {
            this.ningunSupermercado = true;
          }
          console.log("super encontrados");
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },

    buscarPreciosUsuario() {
      FoodeadorDataService.getPreciosUsuario(this.idUsuario)
        .then((response: ResponseData) => {
          this.preciosUsuario = response.data;
          console.log("precios encontrados");
          if (response.data.length == 0) {
            this.ningunPrecio = true;
          }
          console.log(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
  },
  mounted() {
    console.log("id encontrado");
    console.log(localStorage.getItem("idUsuario"));
    this.idUsuario = Number(localStorage.getItem("idUsuario"));
    console.log(this.idUsuario);
    this.buscarProductosUsuario();

    this.buscarSupermercadosUsuario();
    this.buscarPreciosUsuario();

    if (this.$route.query.mensaje) {
      this.mostrarAviso = true;
      if (this.$route.query.mensaje == "productoGuardado") {
        this.mensaje = "Producto guardado";
      }

      if (this.$route.query.mensaje == "supermercadoGuardado") {
        this.mensaje = "Supermercado guardado";
      }

      if (this.$route.query.mensaje == "precioGuardado") {
        this.mensaje = "Precio guardado";
      }

      setTimeout(() => {
        this.mostrarAviso = false;
      }, 5000);
    }
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>@/services/FoodeadorDataService