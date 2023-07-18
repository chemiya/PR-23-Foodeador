<template>
  <div class="guardar-super p-pequeno">
    <div class="container mitad form-super p-pequeno">
      <div class="fila-responsive">
        <h1 v-if="!actualizar">Guardar producto</h1>
        <h1 v-else>Editar producto</h1>
      </div>

      <div class="fila-responsive" v-if="actualizar">
        <img :src="producto.foto" class="foto-producto" />
      </div>

      <div class="guardar-super-container">
        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Nombre</p>
          <input
            type="text"
            v-model="producto.nombre"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[0]">El nombre es obligatorio</p>
        </div>

        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Descripción</p>
          <textarea
            type="text"
            v-model="producto.descripcion"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[1]">La descripción es obligatoria</p>
        </div>

        <div class="guardar-super-entrada m-arriba">
          <p class="tamano-medio">Marca</p>
          <input
            type="text"
            v-model="producto.marca"
            class="input-modificado tamano-medio"
          />
          <p v-if="this.errors[2]">La marca es obligatoria</p>
        </div>

        <div class="fila-responsive guardar-super-abajo m-arriba">
          <div class="guardar-super-entrada-foto">
            <p class="tamano-medio">Foto</p>
            <input
              type="file"
              @change="handleFileChange"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[3]">La foto es obligatoria</p>
          </div>
          <div class="guardar-super-entrada">
            <p class="tamano-medio">Tipo</p>
            <input
              type="text"
              v-model="producto.tipo"
              class="input-modificado tamano-medio"
            />
            <p v-if="this.errors[4]">El tipo es obligatorio</p>
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
import Producto from "@/types/Producto";
import ResponseData from "@/types/ResponseData";
import Supermercado from "@/types/Supermercado";
import axios from "axios";
import { defineComponent } from "vue";

export default defineComponent({
  data() {
    return {
      producto: {
        id: 0,
        nombre: "",
        descripcion: "",
        marca: "",
        tipo: "",
        foto: "",
        idUsuario: 0,
      } as Producto,
      errors: [false, false, false, false, false],
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

      if (!this.producto.nombre) {
        this.errors[0] = true;
      } else {
        this.errors[0] = false;
      }

      if (!this.producto.descripcion) {
        this.errors[1] = true;
      } else {
        this.errors[1] = false;
      }

      if (!this.producto.marca) {
        this.errors[2] = true;
      } else {
        this.errors[2] = false;
      }

      if (!this.producto.tipo) {
        this.errors[4] = true;
      } else {
        this.errors[4] = false;
      }

      if (this.actualizar == false) {
        if (!this.foto) {
          this.errors[3] = true;
        } else {
          this.errors[3] = false;
        }
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
          nombre: this.producto.nombre,
          descripcion: this.producto.descripcion,
          marca: this.producto.marca,
          id: 2,
          tipo: this.producto.tipo,

          foto: "foto",
          idUsuario: this.producto.idUsuario,
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
                console.log("producto que envio-------------");
                console.log(data);
                FoodeadorDataService.createProducto(data)
                  .then((response: ResponseData) => {
                    setTimeout(() => {
                      router.push("/miUsuario?mensaje=productoGuardado");
                    }, 2000);
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
          data.id = this.producto.id;

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
                console.log("producto que envio-------------");
                console.log(data);
                console.log(data);
                FoodeadorDataService.updateProducto(data)
                  .then((response: ResponseData) => {
                    setTimeout(() => {
                      router.push("/miUsuario?mensaje=productoGuardado");
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
            data.foto = this.producto.foto;
            FoodeadorDataService.updateProducto(data)
              .then((response: ResponseData) => {
                setTimeout(() => {
                  router.push("/miUsuario?mensaje=productoGuardado");
                }, 2000);
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

    this.producto.idUsuario = Number(localStorage.getItem("idUsuario"));
    if (this.$route.query.editar) {
      this.actualizar = true;
      console.log(Number(this.$route.query.editar));
      FoodeadorDataService.detalleProducto(Number(this.$route.query.editar))
        .then((response: ResponseData) => {
          this.producto = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    }
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
