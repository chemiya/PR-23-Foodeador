<template>
  <div>
    <div class="aviso" v-if="mostrarAviso">Te has registrado con éxito</div>
    <div class="container contenido-identificacion">
      <div class="fila-responsive p-pequeno">
        <div class="form-identificacion p-pequeno tercio">
          <h1>Identifícate</h1>
          <div class="form-identificacion-entrada ancho-completo m-arriba">
            <p class="tamano-medio">Username</p>
            <input
              type="text"
              v-model="usuario.username"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[0]">El username es obligatorio</p>
          </div>

          <div class="form-identificacion-entrada ancho-completo m-arriba">
            <p class="tamano-medio">Contraseña</p>
            <input
              type="password"
              v-model="usuario.password"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[1]">La contraseña es obligatoria</p>
          </div>

          <div class="boton-div">
            <button @click="identificar" class="boton">Identificarse</button>
            <p v-if="incorrecto">Usuario y contraseña incorrectos</p>
          </div>
        </div>

        <div class="icono-div tercio p-pequeno">
          <img src="./../assets/icono.png" class="icono" />
          <h2 class="tamano-grande centrado">
            La mejor aplicación para comparar precios de alimentos
          </h2>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import UsuarioDataService from "@/services/FoodeadorDataService";
import Usuario from "@/types/Usuario";
import ResponseData from "@/types/ResponseData";
import router from "@/router";

export default defineComponent({
  data() {
    return {
      usuario: {
        id: null,
        username: "",
        password: "",
        email: ".",
      } as Usuario,
      incorrecto: false,
      errors: [false, false],
      submitted: false,
      mostrarAviso: false,
    };
  },
  methods: {
    identificar() {
      this.submitted = true;

      if (!this.usuario.username) {
        this.errors[0] = true;
      } else {
        this.errors[0] = false;
      }
      if (!this.usuario.password) {
        this.errors[1] = true;
      } else {
        this.errors[1] = false;
      }

      if (this.errors[0] == false && this.errors[1] == false) {
        let data = {
          username: this.usuario.username,
          password: this.usuario.password,
          email: ".",
          id: 5,
        };

        console.log(data);
        UsuarioDataService.identificar(data)
          .then((response: ResponseData) => {
            if (response.data == "") {
              console.log("no");
              this.incorrecto = true;
            } else {
              console.log("resultado");
              var id = response.data.id.toString();

              localStorage.setItem("idUsuario", id);
              router.push("/miUsuario");
            }
          })
          .catch((e: Error) => {
            console.log(e);
          });
      }
    },
  },
  mounted() {
    if (this.$route.query.mensaje) {
      this.mostrarAviso = true;
      setTimeout(() => {
        this.mostrarAviso = false;
      }, 5000);
    }
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>