<template>
  <v-app>
    <header class="top-bar" app dense dark>
      <div class="top-bar-title">
        <h1>Clipper</h1>
      </div>
    </header>
    <main>
      <router-view />
    </main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'App',

  data: () => ({
    //
  })
});
</script>
<style>
.top-bar {
  padding: 0;
  margin: 0;
  background-color: #222;
  color: #eee;
}

.top-bar-title {
  padding: 0.5rem 1rem;
  font-family: Roboto, sans-serif;
}
</style>
