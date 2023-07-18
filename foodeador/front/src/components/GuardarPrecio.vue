<template>
  <div class="container">
    <div class="fila-responsive">
      <h1 class="tamano-grande">Guardar precio</h1>
    </div>
    <div class="guardar-precio-cont m-arriba">
      <div class="contenido-precio-guardar">
        <div class="interior-precio-carta">
          <h1 class="titulo-precio">Supermercado</h1>
          <p v-if="this.errors[0]">Por favor selecciona un supermercado</p>
          <div v-if="marcado == 'supermercado' || supermercadoAnadido == true">
            <CartaSupermercadoVue
              :supermercado="supermercado"
              :propagacion="false"
            />
          </div>
        </div>
      </div>

      <div class="contenido-precio-guardar">
        <div class="interior-precio-carta">
          <h1 class="titulo-precio">Producto</h1>
          <p v-if="this.errors[1]">Por favor selecciona un producto</p>
          <div v-if="marcado == 'producto' || productoAnadido == true">
            <CartaProductoVue :producto="producto" :propagacion="false" />
          </div>
        </div>
      </div>

      <div class="contenido-precio-guardar">
        <h1 class="titulo-precio">Precio</h1>
        <p v-if="this.errors[2]">Por favor introduce un precio</p>

        <input
          v-model="precio.precio"
          type="number"
          class="input-modificado-busqueda tamano-medio m-arriba"
        />
        <button @click="guardarPrecio" class="boton m-arriba">Guardar</button>
      </div>
    </div>
  </div>
  <div v-if="marcado == 'producto'" class="buscadores">
    <div class="container">
      <div class="fila-responsive">
        <h1>Buscar supermercados</h1>
      </div>
      <div class="fila-responsive">
        <input
          type="text"
          placeholder="Nombre del supermercado"
          v-model="nombreSupermercadoBuscar"
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
            :propagacion="false"
            :marcarPrecio="true"
            @seleccionar="seleccionSupermercado"
          />
        </div>
      </div>
      <div v-else>
        <h3>Ningún supermercado encontrado</h3>
      </div>
    </div>
  </div>
  <div v-else>
    <div class="container">
      <div class="fila-responsive">
        <h1>Buscar productos</h1>
      </div>
      <div class="fila-responsive">
        <input
          type="text"
          placeholder="Nombre del producto"
          v-model="nombreProductoBuscar"
          class="input-modificado-busqueda tamano-medio"
        />
        <button @click="buscarProducto" class="boton">Buscar</button>
      </div>

      <div v-if="!ningunProducto" class="fila-responsive">
        <div v-for="(producto, index) in productos" :key="index" class="tercio">
          <CartaProductoVue
            :producto="producto"
            :mostrarBotones="false"
            :propagacion="false"
            :marcarPrecio="true"
            @seleccionar="seleccionProducto"
          />
        </div>
      </div>
      <div v-else>
        <h3>Ningún producto encontrado</h3>
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
import CartaProductoVue from "./CartaProducto.vue";
import CartaSupermercadoVue from "./CartaSupermercado.vue";

export default defineComponent({
  components: {
    CartaProductoVue,
    CartaSupermercadoVue,
  },
  data() {
    return {
      precio: {
        id: 0,
        idProducto: 0,
        idSupermercado: 0,
        idUsuario: 0,
        precio: 0,
        nombreProducto: "-",
        marcaProducto: "-",
        nombreUsuario: "-",
        nombreSupermercado: "-",
        fotoProducto: "-",
      } as Precio,
      producto: {
        id: 0,
        nombre: "",
        descripcion: "",
        marca: "",
        tipo: "",
        foto: "",
        idUsuario: 0,
      } as Producto,
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
      errors: [false, false, false],
      supermercadoAnadido: false,
      productoAnadido: false,

      submitted: false,
      marcado: "producto",
      nombreSupermercadoBuscar: "",
      supermercados: [] as Supermercado[],
      ningunSupermercado: false,
      nombreProductoBuscar: "",
      productos: [] as Producto[],
      ningunProducto: false,
    };
  },

  methods: {
    guardarPrecio() {
      this.precio.idUsuario = Number(localStorage.getItem("idUsuario"));
      this.precio.idProducto = this.producto.id;
      this.precio.idSupermercado = this.supermercado.id;
      this.precio.fotoProducto = this.producto.foto;

      console.log("producto");
      if (this.precio.idProducto == 0) {
        this.errors[1] = true;
      } else {
        this.errors[1] = false;
      }

      console.log("supermercado");
      if (this.precio.idSupermercado == 0) {
        this.errors[0] = true;
      } else {
        this.errors[0] = false;
      }

      console.log("precio");
      if (this.precio.precio == 0) {
        this.errors[2] = true;
      } else {
        this.errors[2] = false;
      }

      if (
        this.errors[0] == false &&
        this.errors[1] == false &&
        this.errors[2] == false
      ) {
        this.precio.id = 2;
        console.log("precio que envio");
        console.log(this.precio);
        FoodeadorDataService.guardarPrecio(this.precio)
          .then((response: ResponseData) => {
            console.log(response.data);
            setTimeout(() => {
              router.push("/miUsuario?mensaje=precioGuardado");
            }, 2000);
          })
          .catch((e: Error) => {
            console.log(e);
          });
      }
    },
    buscarProducto() {
      FoodeadorDataService.buscarProducto(this.nombreProductoBuscar)
        .then((response: ResponseData) => {
          console.log(response.data);
          this.productos = response.data;

          if (response.data.length == 0) {
            this.ningunProducto = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    buscarProductosTodos() {
      FoodeadorDataService.buscarProductosTodos()
        .then((response: ResponseData) => {
          console.log(response.data);
          this.productos = response.data;

          if (response.data.length == 0) {
            this.ningunProducto = true;
          }
        })
        .catch((e: Error) => {
          console.log(e);
        });
    },
    seleccionSupermercado(id: any) {
      var encontrado = this.supermercados.filter(
        (supermercado) => (supermercado.id = id)
      );
      console.log(encontrado);
      this.supermercado = encontrado[0];
      this.supermercadoAnadido = true;
    },

    seleccionProducto(id: any) {
      var encontrado = this.productos.filter(
        (producto) => (producto.id = id)
      );
      console.log(encontrado);
      this.producto = encontrado[0];
      this.productoAnadido = true;
    },
    buscarSupermercado() {
      console.log("busco con");
      console.log(this.nombreSupermercadoBuscar);
      FoodeadorDataService.buscarSupermercado(this.nombreSupermercadoBuscar)
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
    console.log("id usuario guardar");
    console.log(localStorage.getItem("idUsuario"));
    const queryParams = this.$route.query;
    if (queryParams.supermercado) {
      this.marcado = "supermercado";
      FoodeadorDataService.detalleSupermercado(Number(queryParams.supermercado))
        .then((response: ResponseData) => {
          this.supermercado = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    } else {
      this.marcado = "producto";
      console.log(Number(queryParams.producto));
      FoodeadorDataService.detalleProducto(Number(queryParams.producto))
        .then((response: ResponseData) => {
          this.producto = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
    }
    this.precio.idUsuario = Number(localStorage.getItem("idUsuario"));
    this.buscarSupermercadosTodos();
    this.buscarProductosTodos();
  },
});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
