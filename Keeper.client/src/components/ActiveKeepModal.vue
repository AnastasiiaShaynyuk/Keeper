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
                <div class="row p-3">
                  <div class="col d-flex justify-content-between">
                    <div v-if="account.id" class="dropdown">
                      <button class="btn btn-secondary btn-sm  dropdown-toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false" @click="getMyVaults()"> Add to Vaults </button>
                      <ul class="dropdown-menu bg-success">
                        <li class="dropdown-item" v-if="myVaults.length == 0">No Vaults</li>
                        <div v-for="vault in myVaults">
                          <li @click="addKeepVault(vault.id, keep.id)" class="dropdown-item" >{{ vault.name }}</li>
                        </div>
                      </ul>
                    </div>
                    <div class="d-flex align-items-center">
                      <img class="avatar rounded-circle elevation-3" :src="keep.creator.picture" :alt="keep.creator.name"
                        :title="keep.creator.name">
                      <b class="ps-2 mb-1">{{ keep.creator.name }}</b>
                    </div>
                  </div>
                  <!-- <div v-if="account.id && keep.creatorId" class="col-12 text-end pb-3"> -->
                  <!-- <button class="btn btn-outline-danger" title="Delete Recipe"><i class="mdi mdi-delete"></i></button>
                </div> -->
                </div>
              </div>
            </div>
            <!-- </div> -->
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- <Modal id="newVault">
    <template #header>
      <div>Add Your Vault</div>
    </template>
    <template #body>
      <VaultForm/>
    </template>
  </Modal> -->
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import { accountService } from "../services/AccountService";
import Pop from "../utils/Pop";
import { vaultKeepsService } from "../services/VaultKeepsService";
// import Modal from "./Modal.vue";
// import VaultForm from "./VaultForm.vue";




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

      async addKeepVault(vaultId, keepId) {
        try {
          await vaultKeepsService.addKeepVault(vaultId, keepId)
          Pop.success(`Keep was added to ${this.myVaults.name} Vault`)
        }
        catch (error){
          Pop.error(error);
        }
      }

    }
  },
  // components: {  Modal, VaultForm }
}
</script>


<style lang="scss" scoped>
.card-img {
  height: 100%;
  width: 100%;
  object-fit: cover;
  // object-position: center;
  border-bottom-right-radius: 0;
  border-top-right-radius: 0;
}

.modal-content {
  background-color: #FEF6F0;
  // max-height: 80vh;
}

.btn {
  background-color: #877A8F;
}

.avatar {
  height: 6vh;
  width: 6vh;
  object-fit: cover;
  object-position: center;
}
</style>

<!-- import { computed } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { keepsService } from "../services/KeepsService.js";

export default {
  setup() {
    return {
      keep: computed(() => AppState.keep),
      myVaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),
      theme: computed(() => AppState.theme),
      async vaultAKeep(vaultId, keepId) {
        try {
          await vaultKeepsService.vaultAKeep(vaultId, keepId)
          Pop.success('Keep successfully added to your vault!')
        } catch (error) {
          Pop.error(error.message, '[Vaulting A Keep]')
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.blur {
  backdrop-filter: blur(10px);
}

.stop-rounding {
  border-radius: 0% !important;
}

.keep-body {
  height: 70%;
  overflow-y: scroll;
}

.keep-body::-webkit-scrollbar {
  display: none;
}

.creator-pfp {
  height: 50px;
  width: 50px;
  border-radius: 50%;
}

.fill {
  min-height: 90%;
  max-height: 70vh;
  max-width: 100%;
}

@media screen and (min-width: 768px) {
  .keep-modal {
    height: 70vh;
    width: 100%;
  }


  .fill {
    object-fit: contain;
  }
}
</style> -->



