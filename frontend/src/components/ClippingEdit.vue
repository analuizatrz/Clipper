<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-text-field
      v-model="text"
      :counter="10"
      :rules="nameRules"
      label="Name"
      required
    ></v-text-field>

    <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>

    <v-select
      v-model="select"
      :items="items"
      :rules="[(v) => !!v || 'Item is required']"
      label="Item"
      required
    ></v-select>

    <v-checkbox
      v-model="checkbox"
      :rules="[(v) => !!v || 'You must agree to continue!']"
      label="Do you agree?"
      required
    ></v-checkbox>

    <v-btn :disabled="!valid" color="success" class="mr-4" @click="validate">
      Validate
    </v-btn>

    <v-btn color="error" class="mr-4" @click="reset">
      Reset Form
    </v-btn>

    <v-btn color="warning" @click="resetValidation">
      Reset Validation
    </v-btn>
  </v-form>
</template>

<script lang="ts">
import { Component, Prop, Vue, Ref } from 'vue-property-decorator';
import Clipping from '@/models/Clipping';
import ClippingType from '@/models/ClippingType';
import { VForm } from '@/utils/types';

@Component
export default class ClippingEdit extends Vue {
  @Prop() clipping!: Clipping;
  @Ref() readonly form!: VForm;

  valid = true;
  name = '';
  nameRules = [
    (v: any) => !!v || 'Name is required',
    (v: any) => (v && v.length <= 10) || 'Name must be less than 10 characters'
  ];
  email = '';
  emailRules = [
    (v: any) => !!v || 'E-mail is required',
    (v: any) => /.+@.+\..+/.test(v) || 'E-mail must be valid'
  ];
  select = null;
  items = ['Item 1', 'Item 2', 'Item 3', 'Item 4'];
  checkbox = false;

  get type() {
    if (this.clipping.type == ClippingType.Highlight) return 'Highlight';
    if (this.clipping.type == ClippingType.Bookmark) return 'Bookmark';
    return '';
  }

  validate() {
    this.form.validate();
  }
  reset() {
    this.form.reset();
  }
  resetValidation() {
    this.form.resetValidation();
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
