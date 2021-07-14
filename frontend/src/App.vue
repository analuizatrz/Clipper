<template>
  <v-app>
    <v-app-bar dense app>
      <v-tabs centered>
        <v-tab key="clippings" to="/">Clippings</v-tab>
        <v-tab key="edit" to="/about">Edit</v-tab>
      </v-tabs>
    </v-app-bar>
    <div class="pt-8">
      <router-view />
    </div>
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
