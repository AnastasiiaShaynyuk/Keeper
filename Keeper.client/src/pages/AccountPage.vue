<template>
  <div class="container">
    <section class="row justify-content-center my-5">
      <div class="col-md-10 col-12">
        <img class="img-fluid rounded position-relative bg-img" :src="account.coverImg" :alt="account.name">
        <img class="positioning elevation-3" :src="account.picture" :alt="account.name">
      </div>
    </section>
    <br>
    <section class="row text-center mt-5">
      <h1>{{ account.name }}</h1>
      <div class="d-flex justify-content-center"> 
        <p>{{ myVaults.length }} Vaults || </p> &nbsp;
        <p>{{  myKeeps.length }} Keeps </p>
      </div>
    </section>
    <!-- <img class="rounded" :src="account.picture" alt="" /> -->
    <p>{{ account.email }}</p>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import Pop from "../utils/Pop";
export default {
  setup() {
    // async function getMyKeeps(accountId) {
    //   try {
    //     await 
    //   }
    //   catch (error){
    //     Pop.error(error);
    //   }
    // }
    // onMounted(() => {
    //   getMyKeeps()
    // })
    return {
      account: computed(() => AppState.account),
      myKeeps: computed(() => AppState.keeps),
      myVaults: computed(() => AppState.vaults)

    }
  }
}
</script>

<style scoped>
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
}
</style>
