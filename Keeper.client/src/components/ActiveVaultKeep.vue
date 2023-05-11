<template>
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
      <div class="modal-content">
        <div v-if="keep" class="card border-0">
          <div class="row">
            <div class="col-6 pe-0">
              <img class="card-img img-fluid rounded-start" :src="keep.img" :alt="keep.name">
            </div>
            <div class="col-6 ps-0">
              <div class="card-body d-flex flex-column justify-content-between h-100">
                <div>
                  <div class="text-end">
                    <button title="Close" type="button" class="btn-close btn-light" data-bs-dismiss="modal"
                      aria-label="Close"></button>
                  </div>
                  <div class="row px-3 justify-content-center">
                    <div class="col-12 d-flex fs-5 justify-content-center">
                      <i class="mdi mdi-eye-outline pe-2" title="Views"></i> <span>{{ keep.views }}</span>
                      <i class="ps-3 mdi mdi-alpha-k-box-outline pe-2" title="Saved"></i> <span>{{ keep.kept }}</span>
                    </div>
                  </div>
                </div>
                <div class="row p-3 text-center ">
                  <div class="col-12">
                    <h5>{{ keep.name }}</h5>
                  </div>
                  <div class="col-12 text-start">
                    <p>{{ keep.description }}</p>
                  </div>
                </div>
                <div class="row py-3">
                <div v-if="account.id" class="col d-flex justify-content-between align-items-center">
                  <div v-if="keep?.vaultKeepId"
                    class="d-flex justify-content-between align-items-center">
                    <button @click="deleteVaultKeep(keep.vaultKeepId)" class="btn  delete-btn"><i
                        class="mdi mdi-cancel pe-1"></i><u>Remove</u></button>
                  </div>
                  <div class="d-flex align-items-center">
                    <img class="avatar rounded-circle elevation-3" :src="keep.creator.picture" :alt="keep.creator.name"
                      data-bs-dismiss="modal">
                    <b class="ps-2 mb-1 text-dark">{{ keep.creator.name }}</b>
                  </div>
                </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService";
import Pop from "../utils/Pop";
import { vaultKeepsService } from "../services/VaultKeepsService";
import { Modal } from "bootstrap";
import { keepsService } from "../services/KeepsService";
import { logger } from "../utils/Logger";


export default {
  setup() {


    return {
      keep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      async getMyVaults() {
        try {
          await accountService.getMyVaults()
        } catch (error) {
          Pop.error(error.message)
        }
      },

      async deleteVaultKeep(vaultKeepId) {
        try {
          if (await Pop.confirm("Are you sure you'd like to remove this keep?", "This action can be undone", "Yes, I'm sure", "warning")) {
            vaultKeepsService.deleteVaultKeep(vaultKeepId)
            Pop.toast('Your keep was deleted!', 'success', 'center')
            Modal.getOrCreateInstance("#activeVaultKeep").hide();
          }
        } catch (error) {
          Pop.error(error.message)
        }
      },

    }
  },
}
</script>


<style lang="scss" scoped>
.card-img {
  height: 100%;
  width: 100%;
  object-fit: cover;
  object-position: center;
  border-bottom-right-radius: 0;
  border-top-right-radius: 0;
}

.modal-content {
  background-color: #FEF6F0;
  // max-height: 80vh;
}

.drop {
  background-color: #877A8F;
}

.avatar {
  height: 6vh;
  width: 6vh;
  object-fit: cover;
  object-position: center;
}
</style>




