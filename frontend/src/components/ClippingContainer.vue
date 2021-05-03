<template>
  <v-container class="clipping-container">
    <div v-for="clipping in clippings" :key="clipping.id">
      <ClippingCard :clipping="clipping" />
    </div>
  </v-container>
</template>

<script lang="ts">
import Clipping from '@/models/Clipping';
import Book from '@/models/Book';
import { Component, Vue } from 'vue-property-decorator';
import ClippingType from '@/models/ClippingType';
import ClippingCard from './ClippingCard.vue';
import Author from '@/models/Author';

@Component({
  components: {
    ClippingCard
  }
})
export default class ClippingContainer extends Vue {
  clippings: Clipping[] = [
    new Clipping(
      'Curioso !',
      new Book('Harry Potter', new Author('J. K. Rowling', 1), 1),
      ClippingType.Highlight,
      1
    ),
    new Clipping(
      'O nome dele é v..... O nome dele é v....',
      new Book('Harry Potter', new Author('J. K. Rowling', 1), 1),
      ClippingType.Highlight,
      2
    )
  ];
}
</script>
<style scoped>
.clipping-container {
  display: flex;
  flex-wrap: wrap;
}
@media (max-width: 700px) {
  .clipping-container {
    flex-direction: column;
  }
}
</style>
