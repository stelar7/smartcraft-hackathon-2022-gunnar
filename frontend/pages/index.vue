<template>
  <v-container>
    <h3>Current task</h3>
    <v-card min-height="200" class="mb-6">
      <v-card-title class="secondary primary--text">
        {{ currentTask.Title }}
        {{ currentTask.Score }}
      </v-card-title>
      <v-card-text></v-card-text>
    </v-card>

    <h3 class="mt-6">Next</h3>
    <v-card min-height="200">
      <v-card-title class="secondary"> Fix some other pipe </v-card-title>
      <v-card-text></v-card-text>
    </v-card>
  </v-container>
</template>

<script>
import { mapActions, mapState } from 'vuex';
export default {
  data: () => ({}),
  computed: {
    ...mapState({
      user: (state) => state.user,
      loadingUser: (state) => state.loading.user,
      currentTask: (state) => state.currentTask,
    }),
  },
  watch: {},
  created() {
    this.getTasks();
  },
  methods: {
    ...mapActions({
      getTasks: 'getTasks',
    }),
  },
};
</script>

