<template>
  <div class="clipping">
    <div class="clipping-text v-card-title">{{ clipping.text }}</div>
    <div class="clipping-info">
      <div class="clipping-info-item">{{ clipping.book && clipping.book.name }}</div>

      <div class="clipping-info-item">
        {{ clipping.book && clipping.book.author && clipping.book.author.name }}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import Clipping from '@/models/Clipping';
import ClippingType from '@/models/ClippingType';

@Component
export default class ClippingCard extends Vue {
  @Prop() clipping!: Clipping;

  get type() {
    if (this.clipping.type == ClippingType.Highlight) return 'Highlight';
    if (this.clipping.type == ClippingType.Bookmark) return 'Bookmark';
    return '';
  }
}
</script>

<style scoped>
.clipping {
  border-radius: 5px;
  margin: 3px;
  min-width: 200px;
  padding: 10px;
  box-shadow: 0 3px 1px -2px rgb(0 0 0 / 20%), 0 2px 2px 0 rgb(0 0 0 / 14%),
    0 1px 5px 0 rgb(0 0 0 / 12%);
}

.clipping-info {
  font-size: 0.7rem;
  display: flex;
  flex-wrap: wrap;
}

.clipping-info-item {
  margin: 0.3rem;
}
</style>
