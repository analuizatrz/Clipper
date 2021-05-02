<template>
  <v-app>
    <v-app-bar app dense dark>
      <div class="text-primary">
        <h1>Clipper</h1>
      </div>
      <v-space />
    </v-app-bar>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'App',

  data: () => ({
    //
  }),
});
</script>
