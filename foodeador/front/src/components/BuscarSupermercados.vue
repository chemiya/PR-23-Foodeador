<template>
  <div class="exterior">
    <div class="container">
      <div class="fila-responsive">
        <h1 class="tamano-grande">Buscar supermercados</h1>
      </div>
      <div class="fila-responsive m-arriba">
        <input
          type="text"
          placeholder="Nombre del supermercado"
          v-model="nombre"
          class="input-modificado-busqueda tamano-medio"
        />
        <button @click="buscarSupermercado" class="boton">Buscar</button>
      </div>

      <div v-if="!ningunSupermercado" class="fila-responsive">
        <div
          v-for="(supermercado, index) in supermercados"
          :key="index"
          class="tercio"
        >
          <CartaSupermercadoVue
            :supermercado="supermercado"
            :mostrarBotones="false"
          />
        </div>
      </div>
      <div v-else>
        <h3 class="centrado">Ningún supermercado encontrado</h3>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import FoodeadorDataService from "@/services/FoodeadorDataService";
import ResponseData from "@/types/ResponseData";
import Supermercado from "@/types/Supermercado";
import { defineComponent } from "vue";
import CartaSupermercadoVue from "./CartaSupermercado.vue";

export default defineComponent({
  components: {
    CartaSupermercadoVue,
  },
  data() {
    return {
      nombre: "",
      supermercados: [] as Supermercado[],
      ningunSupermercado: false,
    };
  },
  methods: {
    buscarSupermercado() {
      FoodeadorDataService.buscarSupermercado(this.nombre)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.supermercados = response.data;

          if (response.data.length == 0) {
            this.ningunSupermercado = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    buscarSupermercadosTodos() {
      FoodeadorDataService.buscarSupermercadosTodos()
        .then((response: ResponseData) => {
          console.log(response.data);
          this.supermercados = response.data;

          if (response.data.length == 0) {
            this.ningunSupermercado = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
  },
  mounted() {
    this.buscarSupermercadosTodos();
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
