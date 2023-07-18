<template>
  <div>
    <div class="fondo">
      <div class="container">
        <div class="fila-responsive-final p-pequeno">
          <router-link to="/identificacion" class="boton m-derecha"
            >Identificación</router-link
          >
          <router-link to="/registro" class="boton">Registro</router-link>
        </div>

        <div class="fila-responsive contenido-fondo">
          <div class="mitad p-pequeno flex-centro">
            <h1 class="titulo-grande">
              La mejor aplicación para comparar precios de alimentos
            </h1>
          </div>

          <div class="mitad flex-centro">
            <img src="./../assets/icono.png" class="icono" />
          </div>
        </div>
      </div>
    </div>

    <div class="caracs">
      <div class="container">
        <div class="fila-responsive p-pequeno">
          <h1 class="tamano-grande">
            Foodeador te ayuda a ahorrar a la hora de comprar alimentos
          </h1>
        </div>

        <div class="fila-responsive">
          <div class="contenido tercio p-pequeno">
            <div class="caracs-carta">
              <font-awesome-icon
                icon="fa-solid fa-apple-whole"
                class="icono-dibujo"
              />
              <h2 class="caracs-carta-titulo">
                Encuentra los precios de un producto
              </h2>
            </div>
          </div>

          <div class="contenido tercio p-pequeno">
            <div class="caracs-carta">
              <font-awesome-icon
                icon="fa-solid fa-cart-shopping"
                class="icono-dibujo"
              />
              <h2 class="caracs-carta-titulo">
                Encuentra los precios de un supermercado
              </h2>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="numbers">
      <div class="container">
        <div class="fila-responsive">
          <div class="titulo mitad p-pequeno">
            <h1 class="tamano-grande">
              Forma parte de la comunidad y empieza a registrar supermercados y
              productos
            </h1>
          </div>

          <div class="numbers-cartas mitad">
            <div class="interior p-pequeno tres-cuartos">
              <div class="numbers-cartas-carta p-pequeno">
                <h2 class="centrado">+500 productos</h2>
              </div>
            </div>

            <div class="interior p-pequeno tres-cuartos">
              <div class="numbers-cartas-carta p-pequeno ancho-completo">
                <h2 class="centrado">+300 supermercados</h2>
              </div>
            </div>

            <div class="interior p-pequeno tres-cuartos">
              <div class="numbers-cartas-carta p-pequeno ancho-completo">
                <h2 class="centrado">+50000 usuarios</h2>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <div class="footer">
    <h1>José María Lozano Olmedo</h1>
    <h1>All rights reserved &copy;</h1>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({});
</script>

<style lang="scss">
@import "estilos.scss";
</style>
