<template>
  <!-- TODO ask about sticky top -->
  <nav class="navbar navbar-expand-lg  px-md-3 elevation-2 fixed-top">
    <div class="container-fluid">
      <div class="d-flex justify-content-around ">
        <div class="navbar-nav me-auto align-items-center">
          <div class="display">
            <router-link class="navbar-brand fs-6 home selectable" :to="{ name: 'Home' }"> Home </router-link>
          </div>
          <div v-if="account.id" class="dropend">
            <span class="dropdown-toggle text-bold fs-6" type="button" data-bs-toggle="dropdown"
              aria-expanded="false"> Create </span>
            <div class="dropdown-menu bg-success border border-1 border-dark">
              <div class="dropdown-item text-bold" data-bs-toggle="modal" data-bs-target="#newKeep">new keep</div>
              <div>
                <hr class="dropdown-divider border-top border-dark mx-auto">
              </div>
              <div class="dropdown-item text-bold" data-bs-toggle="modal" data-bs-target="#newVault">new vault</div>
            </div>
          </div>
        </div>
      </div>
      <router-link class="navbar-brand" :to="{ name: 'Home' }">
        <img class="pe-md-5 me-md-3" alt="logo" src="../assets/img/Keepr logo.png" height="55" />
      </router-link>
      <Login />
    </div>
  </nav>
  <Modal id="newKeep">
    <template #header>
      <div>Add Your Keep</div>
    </template>
    <template #body>
      <KeepForm />
    </template>
  </Modal>

  <Modal id="newVault">
    <template #header>
      <div>Add Your Vault</div>
    </template>
    <template #body>
      <VaultForm/>
    </template>
  </Modal>
</template>

<script>
import { computed } from "vue";
import { Account } from "../models/Account";
import Login from './Login.vue'
import { AppState } from "../AppState";
import Modal from "./Modal.vue";
import KeepForm from "./KeepForm.vue";
import VaultForm from "./VaultForm.vue";
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  },
  components: { Login, Modal, KeepForm, VaultForm }
}
</script>

<style scoped>
nav {
  font-family: 'Oxygen', sans-serif;
  z-index: 100;
  background-color: #FEF6F0;
}

a:hover {
  text-decoration: none;
}

.home {
  background-color: #E9D8D6;
  padding: .3em 1em;
  border-radius: 10px;
  font-weight: bolder;
}

.text-bold {
  font-weight: bolder;
  cursor: pointer;

}

hr {
  width: 90%;
}


@media screen and (max-width: 450px) {
  nav {
    height: 75px;
  }

.display{
  display: none;
}

}
</style>
