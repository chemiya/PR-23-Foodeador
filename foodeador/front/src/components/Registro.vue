<template>
  <div class="fondo-registro">
    <div class="container">
      <div class="fila-responsive p-pequeno">
        <div class="form-registro p-pequeno tercio">
          <img src="./../assets/icono.png" class="icono-pequeno" />
          <h1 class="centrado">
            Regístrate para ver los productos, supermercados y precios
          </h1>
          <div class="form-registro-entrada ancho-completo m-arriba">
            <p class="tamano-medio">Username</p>
            <input
              type="text"
              v-model="usuario.username"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[0]">El username es obligatorio</p>
          </div>

          <div class="form-registro-entrada ancho-completo m-arriba">
            <p class="tamano-medio">Contraseña</p>
            <input
              type="password"
              v-model="usuario.password"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[1]">La contraseña es obligatoria</p>
          </div>

          <div class="form-registro-entrada ancho-completo m-arriba">
            <p class="tamano-medio">Email</p>
            <input
              type="mail"
              v-model="usuario.email"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[2]">El email es obligatorio</p>
            <p v-if="this.errors[3]">Formato de email incorrecto</p>
          </div>

          <div class="boton-div m-arriba">
            <button @click="registrar" class="boton">Registrarse</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import UsuarioDataService from "@/services/FoodeadorDataService";
import Usuario from "@/types/Usuario";
import { defineComponent } from "vue";
import ResponseData from "@/types/ResponseData";
import router from "@/router";

export default defineComponent({
  data() {
    return {
      usuario: {
        id: null,
        username: "",
        password: "",
        email: "",
      } as Usuario,
      errors: [false, false, false, false],
      submitted: false,
    };
  },

  methods: {
    registrar() {
      this.errors = [];
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
      if (!this.usuario.email) {
        this.errors[2] = true;
      } else {
        this.errors[2] = false;
      }
      var expression = /\w+@\w+\.+[a-z]/;
      if (!expression.test(this.usuario.email)) {
        this.errors[3] = true;
      } else {
        this.errors[3] = false;
      }

      var contador = 0;
      this.errors.forEach((error) => {
        if (error) {
          contador++;
        }
      });

      if (contador == 0) {
        let data = {
          username: this.usuario.username,
          password: this.usuario.password,
          email: this.usuario.email,
          id: 5,
        };

        console.log(data);
        UsuarioDataService.create(data)
          .then((response: ResponseData) => {
            router.push("/identificacion?mensaje=identificado");
          })
          .catch((e: Error) => {
            console.log(e);
          });
      }
    },
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>