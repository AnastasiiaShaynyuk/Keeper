<template>
  <form @submit.prevent="createKeep()">
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
    <div class="mb-3">
      <textarea class="form-control border-0" id="description" placeholder="Keep Description..." name="description"
        required style="height: 200px" v-model="editable.description" minlength="5" maxlength="1000"></textarea>
      <hr class="m-0">
    </div>
    <div class="mt-3 text-end">
      <button data-bs-dismiss="modal" class="btn btn-secondary" type="submit"> Create! </button>
    </div>
  </form>
</template>


<script>
import { computed, ref } from "vue";
import Pop from "../utils/Pop";
import { keepsService } from "../services/KeepsService";

export default {
  setup() {
    const editable = ref({})
    const imagePreview = computed(() => editable.value.img);
    return {
      editable,
      imagePreview,

      async createKeep() {
        try {
          const keepData = editable.value
          const keep = await keepsService.createKeep(keepData)
          Pop.toast('Successfully created a keep', 'success', 'center')
          editable.value = {}
        }
        catch (error){
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