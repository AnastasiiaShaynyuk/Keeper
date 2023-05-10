<template>
  <div v-if="vault" class="container">
    <section class="row justify-content-center mt-4">
      <div class="col-md-8">
        <div class="card">
          <img class="card-img" :src="vault.img" :alt="vault.name">
          <div class="card-img-overlay d-flex align-items-end">
            <div class="d-flex flex-column align-items-center justify-content-center w-100 text-light">
              <h3 class="card-title text-center  font">{{ vault.name }}</h3>
              <p class="card-text">by {{ account.name }}</p>
            </div>
            <div v-if="vault.isPrivate" class="text-end me-2">
              <i class="mdi mdi-lock text-light fs-3"></i>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-8 text-center">
        <div v-if="vault.creatorId == account.id" class="dropstart d-flex justify-content-end">
          <i class="mdi mdi-dots-horizontal btn-secondary fs-4" type="button" data-bs-toggle="dropdown"
            aria-expanded="false" title="See more"></i>
          <ul class="dropdown-menu mt-2 bg-success border border-1 border-dark">
            <li @click="deleteVault()" class="dropdown-item text-bold">delete vault</li>
          </ul>
        </div>
        <h6  v-if="vaultKeeps.length > 0"><span class="bg-success rounded py-1 px-2"> {{ vault.length }} Keeps </span>
        </h6>
      </div>
    </section>
    <section class="row">
      <div class="masonry-with-columns">
        <div v-for="k in vaultKeeps" :key="k.id" class="transaction">
          <KeepCard :keep="k" />
        </div>
      </div>
    </section>
  </div>
  
</template>


<script>
import { useRoute, useRouter } from "vue-router";
import { AppState } from "../AppState";
import { computed, onMounted, watchEffect } from "vue";
import Pop from '../utils/Pop.js';
import { vaultsService } from "../services/VaultsService";
import { vaultKeepsService } from "../services/VaultKeepsService"
import KeepCard from "../components/KeepCard.vue";



//  
export default {
  setup() {
    const route = useRoute();
    const router = useRouter();
    async function getVaultById() {
      try {
        const vaultId = route.params.vaultId;
        await vaultsService.getVaultById(vaultId);
      }
      catch (error) {
        Pop.error(error);
        router.push({ name: "Home" });
      }
    }
    async function getVaultKeeps() {
      try {
        const vaultId = route.params.vaultId;
        await vaultKeepsService.getVaultKeeps(vaultId);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getVaultKeeps();
    })
    watchEffect(() => {
      route.params.vaultId;
      getVaultById();
      getVaultKeeps();
    });
    return {
      vault: computed(() => AppState.vault),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps),

      async deleteVault() {
        try {
          if (await Pop.confirm("Are you sure you want to remove your vault?", "This action cannot be undone", "Yes, I'm sure", "warning")) {
            await vaultsService.deleteVault(route.params.vaultId)
            Pop.toast("Vault has been deleted", 'success', 'center')
            router.push({ name: "Home" })
          }
        } catch (error) {
          Pop.error(error, '[delete vault]')
        }
      }
    };
  },
  components: { KeepCard }
}
</script>


<style lang="scss" scoped>
.card-img {
  max-height: 40vh;
  object-fit: cover;
}

.font {
  font-family: 'Quando', serif;
  text-transform: uppercase;
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
  letter-spacing: .5em;
  font-weight: bold;
}

.card-text {
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
  font-weight: bold;
}

i {
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
}

.text-bold {
  font-weight: bold;
}
</style>
