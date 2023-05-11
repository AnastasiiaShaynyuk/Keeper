<template>
  <div class="container">
    <div class="masonry-with-columns my-2">
      <div v-for="k in keeps" :key="k.id" class="transaction">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>

    <ActiveKeepModal id="activeKeep"/>
</template>

<script>
import Pop from "../utils/Pop.js";
import { keepsService } from '../services/KeepsService.js'
import { computed, onMounted } from "vue";
import { AppState } from "../AppState";
import KeepCard from "../components/KeepCard.vue";
import ActiveKeepModal from "../components/ActiveKeepModal.vue";


export default {
  setup() {
    async function getAllKeeps() {
      try {
        await keepsService.getAllKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getAllKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard, ActiveKeepModal }
}
</script>

<style scoped lang="scss">
.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1.5rem;

  div {
    width: 150px;
    color: white;
    margin: .5rem 0 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: 'Marko One', serif;
  }
}

// .transaction {
//   transition: all 0.2s ease-in-out;
// }

// .transaction:hover {
//   transform: scale(.97);
//   border-width: none;
// }
</style>
