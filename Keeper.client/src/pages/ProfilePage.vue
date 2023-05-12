<template>
  <div v-if="profile" class="container">
    <section class="row justify-content-center my-5">
      <div class="col-md-10 col-12">
        <img class="img-fluid rounded position-relative bg-img" :src="profile.coverImg" :alt="profile.name">
        <img class="positioning elevation-3" :src="profile.picture" :alt="profile.name">
      </div>
    </section>
    <section class="row text-center mt-5">
        <div class="col mt-3">
          <h1>{{ profile.name }}</h1>
          <div class="d-flex justify-content-center">
            <p>{{ vaults.length }} Vaults || </p> &nbsp; <p>{{ keeps.length }} Keeps </p>
          </div>
        </div>
      </section>
      <section class="row">
        <div class="col mb-2">
          <h3>Vaults</h3>
          <div class="row">
            <div v-for="v in vaults" :key="v.id" class="col-md-3 my-2 col-6 font transaction">
              <VaultCard :vault="v" />
            </div>
          </div>
        </div>
      </section>
          <section class="row">
      <div class="col mb-2">
        <h3>Keeps</h3>
        <div class="row">
          <div class="masonry-with-columns">
            <div v-for="k in keeps" :key="k.id" class="transaction">
              <KeepCard :keep="k" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  <ActiveKeepModal id="activeKeep"/>
</template>


<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import { logger } from "../utils/Logger.js";
import VaultCard from "../components/VaultCard.vue";
import Pop from "../utils/Pop.js";
import Modal from "../components/Modal.vue";
import ActiveKeepModal from "../components/ActiveKeepModal.vue";
import { useRoute } from 'vue-router';
import KeepCard from "../components/KeepCard.vue";


export default {
  setup() {
    const route = useRoute();

    onMounted(() => {
      getProfileById();
      getKeepsByProfileId();
      getVaultsByProfileId()
    })
    watchEffect(() => {
      getKeepsByProfileId();
      getVaultsByProfileId()
    })
    async function getProfileById() {
      try {
        const profileId = route.params.profileId
        await profilesService.getProfileById(profileId);
      }
      catch (error) {
        Pop.error(error.message);
      }
    }

    async function getKeepsByProfileId() {
      try {
        await profilesService.getKeepsByProfileId(route.params.profileId)
      } catch (error) {
        Pop.error(error)
      }
    }

    async function getVaultsByProfileId() {
      try {
        await profilesService.getVaultsByProfileId(route.params.profileId)
      } catch (error) {
        Pop.error(error)
      }
    }

    return {
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),

    }
  },
  components: { VaultCard, Modal, ActiveKeepModal, KeepCard }
}
</script>


<style scoped lang="scss">
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

.text-bold {
  font-weight: bold;
}

hr {
  width: 90%;
}

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

.font {
  font-family: 'Quando', serif;
  text-transform: uppercase;
  text-shadow: 1px 1px black, 1px 1px 2px #4b5154, -3px 1px 5px #8f8f8f40;
  letter-spacing: .5em;
}

.transaction {
  transition: all 0.2s ease-in-out;
}

.transaction:hover {
  transform: scale(.97);
  border-width: none;
}

@media screen and (max-width: 450px) {
  .masonry-with-columns {
    columns: 2;
  }


  .positioning {
  height: 23vh;
  width: 23vh;
  bottom: 50%;
  left: 24%;
}

h1{
  margin-top: 2em;
}
}
</style>