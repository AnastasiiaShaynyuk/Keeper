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
import { computed, watch } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    const appState = computed(() => AppState)
    watch(() => appState.value.keeps, (newVal, oldVal) => {
      console.log('AppState.keeps changed', newVal, oldVal)
    }, { deep: true })

    return {
      appState
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
