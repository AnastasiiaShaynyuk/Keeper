<template>
  <span class="">
    <button class="btn text-uppercase my-2 my-lg-0" @click="login"
      v-if="!user.isAuthenticated">
      Login
    </button>
    <div v-else>
      <div class="dropstart">
        <div type="button" class="body-bg" data-bs-toggle="dropdown"
          aria-expanded="false">
          <div v-if="account.picture || user.picture">
            <img :src="account.picture || user.picture" alt="account photo" height="45" class="rounded-circle elevation-4" :title="account.name"/>
          </div>
        </div>
        <div class="dropdown-menu bg-success border border-1 border-dark" aria-labelledby="authDropdown">
          <div class="list-group">
            <router-link :to="{ name: 'Account' }">
              <div class="text-bold dropdown-item">
                my account
              </div>
            </router-link>
            <li><hr class="dropdown-divider border-top border-dark mx-auto"></li>
            <div class="text-bold dropdown-item" @click="logout">
              <i class="mdi mdi-logout"></i>
              logout
            </div>
          </div>
        </div>
      </div>
    </div>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style lang="scss" scoped>

hr {
  width: 90%;
}

.text-bold {
  font-weight: bolder;
  cursor: pointer;
}
</style>
