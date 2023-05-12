<template>
  <div @click="setActiveVaultKeep(vaultKeep)" data-bs-toggle="modal" data-bs-target="#activeVaultKeep"
    class="card text-light elevation-4 border-0 selectable position-relative">
    <img class="card-img" :src="vaultKeep.img" :alt="vaultKeep.name">
    <div class="card-img-overlay d-flex align-items-end w-100">
      <div class="d-flex align-items-center justify-content-between w-100">
        <h5 class="card-title m-0 text-start">{{ vaultKeep.name }}</h5>
        <img class="avatar rounded-circle elevation-3" :src="vaultKeep.creator.picture" :alt="vaultKeep.creator.name"
          :title="vaultKeep.creator.name">
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { Keep } from "../models/Keep";
import { keepsService } from "../services/KeepsService";
import Pop from "../utils/Pop";
import { AppState } from "../AppState";
import { Modal } from "bootstrap";
import { logger } from "../utils/Logger";


export default {
  props: {
    vaultKeep: { type: Object, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps),

      async setActiveVaultKeep(vaultKeep) {
        try {
          logger.log('vault keep', vaultKeep)
          await keepsService.setActiveKeep(vaultKeep)
        }
        catch (error) {
          Pop.error(error);
        }
      },

    };
  },
}
</script>


<style lang="scss" scoped>
.avatar {
  height: 6vh;
  width: 6vh;
  object-fit: cover;
  object-position: center;
}

.card-title {
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
}

.positioning {
  // background-color: rgba(255, 87, 87, 0.525);
  height: 1em;
  width: 1em;
  position: absolute;
  bottom: 98%;
  left: 95%
}
</style>