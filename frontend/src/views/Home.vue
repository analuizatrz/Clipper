<template>
  <div>
    <ClippingContainer />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import ClippingContainer from '@/components/ClippingContainer.vue'; // @ is an alias to /src

@Component({
  components: {
    ClippingContainer
  }
})
export default class Home extends Vue {}
</script>
