<template>
  <router-link :to="{name: 'VaultDetails', params: {vaultId: vault.id}}">
    <!-- FIXME do i need to go to vault page from someones vault? -->
    <div  v-if="vault" class="card text-light elevation-0">
      <img class="card-img" :src="vault.img" :alt="vault.name"/>
      <div class="card-img-overlay d-flex align-items-end justify-content-between">
        <h6 class="m-0">{{ vault.name }}</h6>
        <i v-if="vault.isPrivate" class="mdi mdi-lock fs-4" title="Private Vault"></i>
      </div>
    </div>
  </router-link>
</template>


<script>
import { computed } from "vue";
import { Vault } from "../models/Vault";
import { AppState } from "../AppState";

export default {
  props: {
    vault: {type: Object, required: true}
  },
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>


<style lang="scss" scoped>

.card-img {
  max-height: 30vh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}

@media screen and (max-width: 450px) {
  .card-img {
  max-height: 15vh;
}
}


</style>