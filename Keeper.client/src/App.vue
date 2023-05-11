<template>
  <header>
    <Navbar />
  </header>
  <main class="my-5 pt-md-5 pt-3">
    <router-view />
  </main>
  <!-- <footer class="bg-dark text-light">
  </footer> -->
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root{
  --main-height: calc(100vh - 32px - 64px);
}

</style>
