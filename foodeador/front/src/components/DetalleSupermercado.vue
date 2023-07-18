<template>
  <div>
    <div class="container">
      <div class="fila-responsive">
        <div class="imagen tercio contenido-producto-imagen p-pequeno">
          <img :src="supermercado.foto" class="foto-producto" />
          <button class="boton m-arriba" @click="guardarPrecio">
            Registrar precio de un producto en este supermercado
          </button>
        </div>

        <div class="p-pequeno tercio">
          <div class="contenido contenido-producto">
            <h1 class="titulo-carta-grande centrado">
              {{ supermercado.nombre }}
            </h1>
            <h3 class="titulo-carta-grande centrado">
              {{ supermercado.localizacion }}
            </h3>
            <h3 class="titulo-carta centrado">
              {{ supermercado.direccionCompleta }}
            </h3>
            <h3 class="titulo-carta centrado">{{ supermercado.horario }}</h3>
            <h3 class="titulo-carta-pequeno centrado">
              Abierto en {{ supermercado.fechaApertura }}
            </h3>
          </div>
        </div>
      </div>
    </div>

    <div class="container m-arriba">
      <h1 class="titulo-grande">Precios en el supermercado</h1>
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
import Supermercado from "@/types/Supermercado";
import { defineComponent } from "vue";
import CartaPrecioVue from "./CartaPrecio.vue";

export default defineComponent({
  components: {
    CartaPrecioVue,
  },
  data() {
    return {
      id: 0,
      supermercado: {
        id: 0,
        nombre: "",
        localizacion: "",
        direccionCompleta: "",
        horario: "",
        fechaApertura: "",
        idUsuario: 0,
        foto: "",
      } as Supermercado,
      precios: [] as Precio[],
      sinPrecios: false,
    };
  },
  methods: {
    detalleSupermercado() {
      FoodeadorDataService.detalleSupermercado(this.id)
        .then((response: ResponseData) => {
          this.supermercado = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    preciosSupermercado() {
      FoodeadorDataService.getPreciosSupermercado(this.id)
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
      router.push("/guardarPrecio?supermercado=" + this.supermercado.id);
    },
  },
  mounted() {
    this.id = Number(this.$route.params.id);

    this.detalleSupermercado();
    this.preciosSupermercado();
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
