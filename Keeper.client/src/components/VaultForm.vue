<template>
  <form @submit.prevent="createVault()">
    <div class="mb-3">
      <input class="form-control border-0" type="text" id="name" placeholder="Title..." name="name" required minlength="3"
        maxlength="25" v-model="editable.name">
      <hr class="m-0">
    </div>
    <div class="mb-3">
      <input class="form-control border-0" type="url" id="img" placeholder="Img Url..." name="img" required
        v-model="editable.img" @input="previewImage">
      <hr class="m-0">
      <br>
      <img class='img-preview' :src="imagePreview" v-if="imagePreview" />
    </div>
    <div class="mt-3 text-end">
      <p><small>Private Vaults can be seen by you</small></p>
      <div class="form-check d-flex justify-content-end">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault" v-model="editable.isPrivate">
        <label class="ps-2 form-check-label" for="flexCheckDefault"> Make Vault Private? </label>
      </div>
      <button data-bs-dismiss="modal" class="btn btn-secondary mt-3" type="submit"> Create! </button>
    </div>
  </form>
</template>


<script>
import { computed, ref } from "vue";
import Pop from "../utils/Pop";
import { vaultsService } from "../services/VaultsService.js";
import { useRoute } from 'vue-router';
import { AppState } from "../AppState";

export default {
  setup() {
    const editable = ref({})
    const route = useRoute();
    const imagePreview = computed(() => editable.value.img);
    return {
      editable,
      imagePreview,
      async createVault() {
        try {
          let userId
          route.params.profileId ? userId = route.params.profileId : userId = AppState.account.id
          const vaultData = editable.value
          if (vaultData.isPrivate == null) {
            vaultData.isPrivate = false;
          }
          const vault = await vaultsService.createVault(vaultData, userId)
          Pop.toast('Successfully created a vault', 'success', 'center')
          editable.value = {}
        }
        catch (error) {
          Pop.error(error);
        }
      },

      previewImage() {
        imagePreview.value = editable.value.img;
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.img-preview {
  width: 100%;
  height: 40vh;
  object-fit: cover;
  object-position: center;
}

textarea {
  height: 200px;
  display: block;
  position: relative;
}

textarea::-webkit-input-placeholder {
  position: absolute;
  bottom: .6em;
}

.btn {
  background-color: #2D2D2D;
  color: #F9F6FA;
}
</style>