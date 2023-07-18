<template>
  <div>
    <div class="container">
      <div class="fila-responsive">
        <div class="imagen tercio contenido-producto-imagen p-pequeno">
          <img :src="producto.foto" class="foto-producto" />
          <button class="boton m-arriba" @click="guardarPrecio">
            Registrar precio de este producto en un supermercado
          </button>
        </div>

        <div class="p-pequeno tercio">
          <div class="contenido contenido-producto">
            <h1 class="titulo-carta-grande centrado">{{ producto.nombre }}</h1>
            <h3 class="titulo-carta centrado">{{ producto.marca }}</h3>
            <h3 class="titulo-carta centrado">{{ producto.tipo }}</h3>
            <p class="titulo-carta-pequeno centrado">
              {{ producto.descripcion }}
            </p>
          </div>
        </div>
      </div>
    </div>

    <div class="container m-arriba">
      <h1 class="titulo-grande">Precios del producto</h1>
      <div class="fila-responsive" v-if="!sinPrecios">
        <div v-for="(precio, index) in precios" :key="index" class="tercio">
          <CartaPrecioVue :precio="precio" />
        </div>
      </div>

      <div v-else>
        <h2 class="centrado">No hay ningún precio</h2>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import router from "@/router";
import FoodeadorDataService from "@/services/FoodeadorDataService";
import Precio from "@/types/Precio";
import Producto from "@/types/Producto";
import ResponseData from "@/types/ResponseData";
import { defineComponent } from "vue";
import CartaPrecioVue from "./CartaPrecio.vue";

export default defineComponent({
  components: {
    CartaPrecioVue,
  },
  data() {
    return {
      id: 0,
      producto: {
        id: 0,
        nombre: "",
        descripcion: "",
        marca: "",
        tipo: "",
        foto: "",
        idUsuario: 0,
      } as Producto,
      precios: [] as Precio[],
      sinPrecios: false,
    };
  },
  methods: {
    detalleProducto() {
      FoodeadorDataService.detalleProducto(this.id)
        .then((response: ResponseData) => {
          this.producto = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    preciosProducto() {
      FoodeadorDataService.getPreciosProducto(this.id)
        .then((response: ResponseData) => {
          this.precios = response.data;
          if (response.data.length == 0) {
            this.sinPrecios = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    guardarPrecio() {
      router.push("/guardarPrecio?producto=" + this.producto.id);
    },
  },
  mounted() {
    this.id = Number(this.$route.params.id);

    this.detalleProducto();
    this.preciosProducto();
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
