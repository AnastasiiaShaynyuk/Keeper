<template>
  <div class="container">
    <section class="row justify-content-center my-5">
      <div class="col-md-10 col-12">
        <img class="img-fluid rounded position-relative bg-img" :src="account.coverImg" :alt="account.name">
        <img class="positioning elevation-3" :src="account.picture" :alt="account.name">
        <div v-if="account.id" class="dropstart d-flex justify-content-end mt-2">
          <i class="mdi mdi-dots-horizontal btn-secondary fs-3" type="button" data-bs-toggle="dropdown"
            aria-expanded="false" title="See more"></i>
          <ul class="dropdown-menu bg-success mt-2 border border-1 border-dark">
            <li class="dropdown-item text-bold" data-bs-toggle="modal" data-bs-target="#editAccount">edit account</li>
          </ul>
        </div>
      </div>
    </section>
    <section class="row justify-content-center text-center mt-5">
      <div class="col-md-11 ">
        <h1>{{ account.name }}</h1>
        <div class="d-flex justify-content-center">
          <p>{{ myVaults.length }} Vaults || </p> &nbsp; <p>{{ myKeeps.length }} Keeps </p>
        </div>
      </div>
    </section>
    <section class="row">
      <div v-if="myVaults.length == 0" class="col mb-2 text-center">
        <h5>You do not have any Vaults.</h5>
      </div>
      <div v-else class="col mb-2">
        <h3>Vaults</h3>
        <div class="row">
          <div v-for="v in myVaults" :key="v.id" class="col-md-3 col-6 my-2 font transaction">
            <VaultCard :vault="v" />
          </div>
        </div>
      </div>
    </section>
    <section class="row">
      <div v-if="myKeeps.length == 0" class="col mb-2 text-center">
        <h5>You do not have any Keeps.</h5>
      </div>
      <div v-else class="col mb-2">
        <h3>Keeps</h3>
        <div class="row">
          <div class="masonry-with-columns">
            <div v-for="k in myKeeps" :key="k.id" class="transaction">
              <VaultKeepCard :vaultKeep="k" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  <ActiveVaultKeep id="activeVaultKeep" />
  <Modal id="editAccount">
    <template #header>
      <div>Edit Your Account</div>
    </template>
    <template #body>
      <EditAccountForm />
    </template>
  </Modal>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import Pop from "../utils/Pop";
import { keepsService } from "../services/KeepsService";
import VaultCard from "../components/VaultCard.vue";
import { accountService } from "../services/AccountService";
import VaultKeepCard from "../components/VaultKeepCard.vue";
import { useRoute } from "vue-router";
import { logger } from "../utils/Logger.js"
import Modal from "../components/Modal.vue";
import EditAccountForm from "../components/EditAccountForm.vue";
import ActiveVaultKeep from "../components/ActiveVaultKeep.vue";

export default {
  setup() {
    async function getMyVaults() {
      try {
        await accountService.getMyVaults()
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getSavedKeeps() {
      try {
        const profileId = AppState.account.id
        await keepsService.getSavedKeeps(profileId)
      }
      catch (error) {
        Pop.error(error);
      }
    }
    watchEffect(() => {
      if (AppState.account.id) {
        getMyVaults()
        getSavedKeeps()
      }
    })
    onMounted(() => {
      getSavedKeeps()

    })
    return {
      account: computed(() => AppState.account),
      myKeeps: computed(() => AppState.myKeeps),
      myVaults: computed(() => AppState.myVaults),

    };
  },
  components: { VaultCard, VaultKeepCard, Modal, EditAccountForm, ActiveVaultKeep }
}
</script>

<style scoped lang="scss">
.bg-img {
  width: 100%;
  max-height: 45vh;
}

.positioning {
  height: 27vh;
  width: 27vh;
  position: absolute;
  bottom: 30%;
  left: 43%;
  border: 2px solid whitesmoke;
  border-radius: 50%;
  object-fit: cover;
  object-position: center;
}

.text-bold {
  font-weight: bold;
}

hr {
  width: 90%;
}

.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1.5rem;

  div {
    width: 150px;
    color: white;
    margin: .5rem 0 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: 'Marko One', serif;
  }
}

.font {
  font-family: 'Quando', serif;
  text-transform: uppercase;
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
  letter-spacing: .5em;
}

.transaction {
  transition: all 0.2s ease-in-out;
}

.transaction:hover {
  transform: scale(.97);
  border-width: none;
}

@media screen and (max-width: 450px) {
  .masonry-with-columns {
    columns: 2;
  }


  .positioning {
    height: 23vh;
    width: 23vh;
    bottom: 50%;
    left: 24%;
  }

  .font {
    letter-spacing: .3em;
  }
}
</style>
