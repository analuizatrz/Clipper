<template>
  <div>
    <HelloWorld />
    <v-row justify="center">
      <a
        v-for="(link, i) in importantLinks"
        :key="i"
        :href="link.href"
        class="subheading mx-3"
        target="_blank"
      >
        {{ link.text }}
      </a>
    </v-row>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
  components: {
    HelloWorld
  }
})
export default class Home extends Vue {}
</script>
