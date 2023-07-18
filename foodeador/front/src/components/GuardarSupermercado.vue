<template>
  <div class="guardar-super p-pequeno">
    <div class="container mitad form-super p-pequeno">
      <div class="fila-responsive">
        <h1 v-if="!actualizar">Guardar supermercado</h1>
        <h1 v-else>Editar supermercado</h1>
      </div>

      <div class="fila-responsive" v-if="actualizar">
        <img :src="supermercado.foto" class="foto-producto" />
      </div>

      <div class="guardar-super-container">
        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Nombre</p>
          <input
            type="text"
            v-model="supermercado.nombre"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[0]">El nombre es obligatorio</p>
        </div>

        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Localización</p>
          <input
            type="text"
            v-model="supermercado.localizacion"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[1]">La localización es obligatoria</p>
        </div>

        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Dirección completa</p>
          <input
            type="text"
            v-model="supermercado.direccionCompleta"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[2]">La dirección completa es obligatoria</p>
        </div>

        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Horario</p>
          <input
            type="text"
            v-model="supermercado.horario"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[3]">El horario es obligatorio</p>
        </div>

        <div class="fila-responsive guardar-super-abajo m-arriba">
          <div class="guardar-super-entrada-foto">
            <p class="tamano-medio">Foto</p>
            <input
              type="file"
              @change="handleFileChange"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[4]">La foto es obligatoria</p>
          </div>
          <div class="guardar-super-entrada">
            <p class="tamano-medio">Fecha apertura</p>
            <input
              type="text"
              v-model="supermercado.fechaApertura"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[5]">La fecha de apertura es obligatoria</p>
          </div>
        </div>

        <div class="fila-responsive ancho-completo p-pequeno">
          <button class="boton" @click="registrarSupermercado">Guardar</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import router from "@/router";
import FoodeadorDataService from "@/services/FoodeadorDataService";
import ResponseData from "@/types/ResponseData";
import Supermercado from "@/types/Supermercado";
import axios from "axios";
import { defineComponent } from "vue";

export default defineComponent({
  data() {
    return {
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
      errors: [false, false, false, false, false, false],
      submitted: false,
      actualizar: false,
      foto: null,
    };
  },

  methods: {
    handleFileChange(event: any) {
      this.foto = event.target.files[0];
    },
    registrarSupermercado() {
      this.submitted = true;

      if (!this.supermercado.nombre) {
        this.errors[0] = true;
      } else {
        this.errors[0] = false;
      }

      if (!this.supermercado.localizacion) {
        this.errors[1] = true;
      } else {
        this.errors[1] = false;
      }

      if (!this.supermercado.direccionCompleta) {
        this.errors[2] = true;
      } else {
        this.errors[2] = false;
      }

      if (!this.supermercado.horario) {
        this.errors[3] = true;
      } else {
        this.errors[3] = false;
      }

      if (this.actualizar == false) {
        if (!this.foto) {
          this.errors[4] = true;
        } else {
          this.errors[4] = false;
        }
      }

      if (!this.supermercado.fechaApertura) {
        this.errors[5] = true;
      } else {
        this.errors[5] = false;
      }

      var alguno = false;
      this.errors.forEach((error) => {
        console.log(error);
        if (error) {
          alguno = true;
        }
      });

      console.log(alguno);
      if (!alguno) {
        let data = {
          nombre: this.supermercado.nombre,
          direccionCompleta: this.supermercado.direccionCompleta,
          localizacion: this.supermercado.localizacion,
          id: 5,
          horario: this.supermercado.horario,
          fechaApertura: this.supermercado.fechaApertura,
          foto: "foto",
          idUsuario: this.supermercado.idUsuario,
        };

        if (this.actualizar == false) {
          if (this.foto) {
            const formData = new FormData();
            formData.append("file", this.foto);
            formData.append("upload_preset", "moavdx20");

            axios
              .post(
                "https://api.cloudinary.com/v1_1/chemareact/image/upload",
                formData
              )
              .then((response) => {
                data.foto = response.data.secure_url;
                console.log("supermercado que envio-------------");
                console.log(data);
                console.log(data);
                FoodeadorDataService.createSupermercado(data)
                  .then((response: ResponseData) => {
                    router.push("/miUsuario?mensaje=supermercadoGuardado");
                  })
                  .catch((e: Error) => {
                    console.log(e);
                  });
              })
              .catch((error) => {
                console.error("Error al cargar la imagen:", error);
              });
          }
        } else {
          data.id = this.supermercado.id;

          if (this.foto) {
            const formData = new FormData();
            formData.append("file", this.foto);
            formData.append("upload_preset", "moavdx20");

            axios
              .post(
                "https://api.cloudinary.com/v1_1/chemareact/image/upload",
                formData
              )
              .then((response) => {
                data.foto = response.data.secure_url;
                console.log("supermercado que envio-------------");
                console.log(data);
                console.log(data);
                console.log(data);
                FoodeadorDataService.updateSupermercado(data)
                  .then((response: ResponseData) => {
                    setTimeout(() => {
                      router.push("/miUsuario?mensaje=supermercadoGuardado");
                    }, 2000);
                  })
                  .catch((e: Error) => {
                    console.log(e);
                  });
              })
              .catch((error) => {
                console.error("Error al cargar la imagen:", error);
              });
          } else {
            data.foto = this.supermercado.foto;
            FoodeadorDataService.updateSupermercado(data)
              .then((response: ResponseData) => {
                router.push("/miUsuario?mensaje=supermercadoGuardado");
              })
              .catch((e: Error) => {
                console.log(e);
              });
          }
        }
      }
    },
  },
  mounted() {
    console.log("id usuario guardar");
    console.log(localStorage.getItem("idUsuario"));

    if (this.$route.query.editar) {
      this.actualizar = true;
      console.log(Number(this.$route.query.editar));
      FoodeadorDataService.detalleSupermercado(Number(this.$route.query.editar))
        .then((response: ResponseData) => {
          this.supermercado = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    }

    this.supermercado.idUsuario = Number(localStorage.getItem("idUsuario"));
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
