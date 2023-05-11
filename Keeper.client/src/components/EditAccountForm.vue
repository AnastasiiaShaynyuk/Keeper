<template>
  <form @submit.prevent="editAccount()">
    <div class="mb-3">
      <label class="text" for="name">Your Name</label>
      <input class="form-control border-0" type="text" id="name" placeholder="Your Name..." name="name" required
        minlength="3" maxlength="50" v-model="editable.name">
      <hr class="m-0">
    </div>
    <div class="mb-3">
      <label class="text" for="img">Your Picture</label>
      <input class="form-control border-0" type="url" id="img" placeholder="Your Picture..." name="img" required
        v-model="editable.picture" @input="previewImage()">
      <hr class="m-0">
      <img class='img-preview rounded-circle' :src="imagePreview" v-if="imagePreview" />
    </div>
    <div class="mb-3">
      <label class="text" for="img">Your Cover Image</label>
      <input class="form-control border-0" type="url" id="coverImg" placeholder="Your Cover Img..." name="coverImg"
        required v-model="editable.coverImg">
      <hr class="m-0">
    </div>
    <div class="mt-3 text-end">
      <button data-bs-dismiss="modal" class="btn btn-secondary mt-3" type="submit"> Edit </button>
    </div>
  </form>
</template>


<script>
import { computed, ref, watchEffect } from "vue";
import Pop from "../utils/Pop";
import { AppState } from "../AppState";
import { accountService } from "../services/AccountService";
import { logger } from "../utils/Logger";
export default {
  setup() {
    const editable = ref({})
    const imagePreview = computed(() => editable.value.img);
    watchEffect(() => {
      if (AppState.account.id) {
        editable.value = { ...AppState.account }
      }
    })
    return {
      editable,
      imagePreview,
      async editAccount() {
        try {
          const accountData = editable.value
          await accountService.editAccount(accountData)
          Pop.toast('Account edited Successfully', 'success', 'center')
        }
        catch (error) {
          Pop.error(error);
        }
      },
      previewImage() {
        editable.value.img = imagePreview.value;
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

.btn {
  background-color: #2D2D2D;
  color: #F9F6FA;
}

.text {
  font-weight: bold;
}
</style>