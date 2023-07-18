<template>
  <div class="producto p-pequeno">
    <div class="producto-interior p-pequeno">
      <img :src="precio.fotoProducto" class="foto-producto" />
      <h3 class="titulo-carta">{{ precio.nombreProducto }}</h3>
      <h3 class="titulo-carta">{{ precio.marcaProducto }}</h3>
      <h3 class="titulo-carta">{{ precio.nombreSupermercado }}</h3>
      <h3 class="titulo-carta">{{ precio.precio }}€</h3>
      <h3 class="titulo-carta">{{ precio.nombreUsuario }}</h3>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default {
  props: ["precio"],
};
</script>

<style lang="scss">
@import "estilos.scss";
</style>
