<!--

<template>
  <div class="producto p-pequeno">
    <div class="producto-interior p-pequeno" @click="abrirSupermercado">
      <img
        src="./../assets/icono.png"
        class="foto-producto"
        
      />
      <h3>{{ supermercado.nombre }}</h3>
      <h3>{{ supermercado.localizacion }}</h3>
      <div class="botones-editar-eliminar" v-if="mostrarBotones">
        <button class="editar">Editar</button>
        <button class="eliminar" @click="deleteSupermercado">Eliminar</button>
      </div>

      <div v-if="marcarPrecio">
        <button class="editar" @click="seleccionado">Seleccionar</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import FoodeadorDataService from "@/services/FoodeadorDataService";
import ResponseData from "@/types/ResponseData";
import router from "@/router";

export default {
  props: ["supermercado", "mostrarBotones", "marcarPrecio"],

  methods: {
    abrirSupermercado() {
      router.push("/detalleSupermercado/" + this.supermercado.id);
    },
    deleteSupermercado() {
      console.log("entro");
      FoodeadorDataService.deleteSupermercado(1)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.$emit("actualizar");
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    seleccionado() {
      this.$emit("seleccionar", 1);
    },
    
  mounted(){
    console.log("en carta")
    console.log(this.supermercado)
  }
  },
};
</script>

<style lang="scss">
@import "estilos.scss";
</style>


-->

<!--


-->

<template>
  <div class="producto p-pequeno">
    <div class="producto-interior p-pequeno" @click="abrirSupermercado">
      <img :src="supermercado.foto" class="foto-producto" />
      <h3 class="titulo-carta">{{ supermercado.nombre }}</h3>
      <h3 class="titulo-carta">{{ supermercado.localizacion }}</h3>
      <div class="botones-editar-eliminar" v-if="mostrarBotones">
        <button class="editar" @click.stop="updateSupermercado">Editar</button>
        <button class="eliminar" @click.stop="deleteSupermercado">
          Eliminar
        </button>
      </div>

      <div v-if="marcarPrecio">
        <button class="editar" @click.stop="seleccionado">Seleccionar</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import FoodeadorDataService from "@/services/FoodeadorDataService";
import ResponseData from "@/types/ResponseData";
import router from "@/router";

export default {
  props: ["supermercado", "mostrarBotones", "marcarPrecio", "propagacion"],

  methods: {
    abrirSupermercado() {
      if (this.propagacion != false) {
        router.push("/detalleSupermercado/" + this.supermercado.id);
      }
    },
    updateSupermercado() {
      router.push("/guardarSupermercado?editar=" + this.supermercado.id);
    },
    deleteSupermercado() {
      console.log("entro");
      FoodeadorDataService.deleteSupermercado(this.supermercado.id)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.$emit("actualizar","eliminadoSupermercado");
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    seleccionado() {
      this.$emit("seleccionar", this.supermercado.id);
    },

    mounted() {
      console.log("en carta");
      console.log(this.supermercado);
      console.log(this.propagacion);
    },
  },
};
</script>

<style lang="scss">
@import "estilos.scss";
</style>

