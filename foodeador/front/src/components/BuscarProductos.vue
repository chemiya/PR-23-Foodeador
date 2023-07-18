<template>
  <div class="exterior">
    <div class="container">
      <div class="fila-responsive">
        <h1 class="tamano-grande">Buscar productos</h1>
      </div>
      <div class="fila-responsive m-arriba">
        <input
          type="text"
          placeholder="Nombre del producto"
          v-model="nombre"
          class="input-modificado-busqueda tamano-medio"
        />
        <button @click="buscarProducto" class="boton">Buscar</button>
      </div>

      <div v-if="!ningunProducto" class="fila-responsive">
        <div v-for="(producto, index) in productos" :key="index" class="tercio">
          <CartaProductoVue :producto="producto" :mostrarBotones="false" />
        </div>
      </div>
      <div v-else>
        <h3 class="centrado">Ningún producto encontrado</h3>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import FoodeadorDataService from "@/services/FoodeadorDataService";
import Producto from "@/types/Producto";
import ResponseData from "@/types/ResponseData";
import Supermercado from "@/types/Supermercado";
import { defineComponent } from "vue";
import CartaProductoVue from "./CartaProducto.vue";

export default defineComponent({
  components: {
    CartaProductoVue,
  },
  data() {
    return {
      nombre: "",
      productos: [] as Producto[],
      ningunProducto: false,
    };
  },
  methods: {
    buscarProducto() {
      FoodeadorDataService.buscarProducto(this.nombre)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.productos = response.data;

          if (response.data.length == 0) {
            this.ningunProducto = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    buscarProductosTodos() {
      FoodeadorDataService.buscarProductosTodos()
        .then((response: ResponseData) => {
          console.log(response.data);
          this.productos = response.data;

          if (response.data.length == 0) {
            this.ningunProducto = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.buscarProductosTodos();
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>

