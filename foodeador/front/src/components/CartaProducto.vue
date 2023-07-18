

<!--


-->



<template>
  <div class="producto p-pequeno">
    <div class="producto-interior p-pequeno" @click="abrirProducto">
      <img :src="producto.foto" class="foto-producto" />
      <h3 class="titulo-carta">{{ producto.nombre }}</h3>
      <h3 class="titulo-carta">{{ producto.marca }}</h3>
      <div class="botones-editar-eliminar" v-if="mostrarBotones">
        <button class="editar" @click.stop="updateProducto">Editar</button>
        <button class="eliminar" @click.stop="deleteProducto">Eliminar</button>
      </div>
      <div v-if="marcarPrecio">
        <button class="editar" @click.stop="seleccionado">Seleccionar</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import router from "@/router";
import ResponseData from "@/types/ResponseData";
import FoodeadorDataService from "@/services/FoodeadorDataService";
export default {
  props: ["producto", "propagacion", "marcarPrecio", "mostrarBotones"],
  methods: {
    abrirProducto() {
      if (this.propagacion != false) {
        router.push("/detalleProducto/" + this.producto.id);
      }
    },

    updateProducto() {
      router.push("/guardarProducto?editar=" + this.producto.id);
    },
    seleccionado() {
      this.$emit("seleccionar", this.producto.id);
    },
    deleteProducto() {
      console.log("entro");
      FoodeadorDataService.deleteProducto(this.producto.id)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.$emit("actualizar","eliminadoProducto");
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
  },
  mounted() {
    console.log("propagacion");
    console.log(this.propagacion);
  },
};
</script>

<style lang="scss">
@import "estilos.scss";
</style>



