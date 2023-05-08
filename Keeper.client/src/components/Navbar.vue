<template>
  <nav class="navbar navbar-expand-lg body-dg px-3 elevation-2 fixed-top">
    <div class="container-fluid ">
      <div class="d-flex justify-content-around ">
        <ul class="navbar-nav me-auto align-items-center">
          <li>
            <router-link class="navbar-brand fs-6 home selectable" :to="{ name: 'Home' }"> Home </router-link>
          </li>
          <li v-if="account.id" class="dropend">
            <span class="navbar-brand dropdown-toggle text-bold fs-6" role="button" data-bs-toggle="dropdown" aria-expanded="false"> Create
            </span>
            <ul class="dropdown-menu bg-success border border-1 border-dark">
              <li><a class="dropdown-item text-bold" href="#">new keep</a></li>
              <li><hr class="dropdown-divider border-top border-dark mx-auto"></li>
              <li><a class="dropdown-item text-bold" href="#">new vault</a></li>
            </ul>
          </li>
        </ul>
      </div>
      <router-link class="navbar-brand" :to="{ name: 'Home' }">
        <img class="pe-5 me-5" alt="logo" src="../assets/img/Keepr logo.png" height="55" />
      </router-link>
      <Login />
      <!-- <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>Home</li>
        <li>Create</li>
      </ul> -->
      <!-- LOGIN COMPONENT HERE -->
      <!-- <Login />
    </div> -->
    </div>
  </nav>
</template>

<script>
import { computed } from "vue";
import { Account } from "../models/Account";
import Login from './Login.vue'
import { AppState } from "../AppState";
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  },
  components: { Login }
}
</script>

<style scoped>
nav {
  font-family: 'Oxygen', sans-serif;
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
}

hr {
  width: 90%;
}


@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
