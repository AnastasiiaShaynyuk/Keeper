<template>
  <div class="card text-light elevation-4 border-0">
    <img class="card-img" :src="keep.img" :alt="keep.name">
    <div class="card-img-overlay d-flex align-items-end w-100">
      <div class="d-flex align-items-center justify-content-between w-100">
        <h5 class="card-title m-0 text-start">{{ keep.name }}</h5>
        <img class="avatar rounded-circle elevation-3" :src="keep.creator.picture" :alt="keep.creator.name">
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { Keep } from "../models/Keep";
import { AppState } from "../AppState";

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
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
</style>