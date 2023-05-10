<template>
  <div @click="setActiveKeep(keep.id)" data-bs-toggle="modal" data-bs-target="#activeKeep" class="card text-light elevation-4 border-0 selectable position-relative" >
    <i @click="deleteKeep(keep.id).stop()" class="mdi mdi-alpha-x-circle positioning text-danger fs-6" v-if="account.id && keep.creatorId == account.id" title="Delete keep"></i>
    <img class="card-img" :src="keep.img" :alt="keep.name">
    <div class="card-img-overlay d-flex align-items-end w-100">
      <div class="d-flex align-items-center justify-content-between w-100">
        <h5 class="card-title m-0 text-start">{{ keep.name }}</h5>
        <img class="avatar rounded-circle elevation-3" :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name">
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


export default {
    props: {
        keep: { type: Object, required: true }
    },
    setup() {
      return {
          account: computed(() => AppState.account),
          async setActiveKeep(keepId) {
          try {
            await keepsService.setActiveKeep(keepId)
          }
          catch (error){
            Pop.error(error);
          }
        },
        async deleteKeep(keepId) {
          try {
            if (await Pop.confirm("Are you sure you'd like to remove this keep?", "This action cannot be undone", "Yes, I'm sure", "warning")) {
              await keepsService.deleteKeep(keepId)
              Pop.success('Your keep was deleted!')
            }
          }
          catch (error){
            Pop.error(error);
          }
        }
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