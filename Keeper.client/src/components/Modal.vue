<template>
  <div class="modal fade" tabindex="-1" data-bs-keyboard="false" role="dialog"
    aria-labelledby="modalTitleId" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" :class="size" role="document">
      <div class="modal-content">
        <div class="modal-header border-0">
          <h5 class="modal-title" id="modalTitleId">
            <slot name="header"></slot>
          </h5>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <slot name="body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>


<script setup>
const props = defineProps({ size: { type: String, default: 'modal-md' } })

</script>


<style lang="scss" scoped>
  .modal-content {
    background-color: #F9F6FA;
  }
</style>
