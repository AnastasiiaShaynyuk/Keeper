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
                        aria-expanded="false"> Add to Vaults </button>
                      <ul class="dropdown-menu bg-success">
                        <li><a class="dropdown-item" href="#">Action</a></li>
                        <li><a class="dropdown-item" href="#">Another action</a></li>
                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                      </ul>
                    </div>
                    <div  class="d-flex align-items-center">
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
  <!-- <div class="col-6 d-flex justify-content-between align-items-center">
              <div class="btn-group" v-if="account.id">
                <button class="btn btn-sm dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false"
                </button>
                <ul v-if="myVaults.length > 0" class="dropdown-menu">
                  <li v-for="v in myVaults" class="selectable" @click="vaultAKeep(v.id, keep.id)"
                    :title="`Add this keep to your ${v.name} vault!`">
                    <span>
                      {{ v.name }}
                    </span>
                  </li>
                </ul>
                <ul v-else>
                  <li><span>No Vaults Created!</span></li>
                </ul>
              </div>
              <div> -->
</template>

<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";


export default {
  setup() {


    return {
      keep: computed(() => AppState.activeKeep),
      account: computed(() => AppState.account)
    }
  }
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





