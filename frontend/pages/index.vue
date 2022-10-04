<template>
  <div>
    <v-container class="pa-4">
      <h3 class="mb-4">Current task</h3>
      <TaskCard :task="currentTask" color="secondary" text-color="primary" @select="selectTask"/>
    </v-container>

    <v-container class="pa-4">
      <h3 class="mb-4">Next</h3>
      <TaskCard :task="currentTask" color="grey" text-color="primary--text" @cancel="cancelTask"/>
    </v-container>

    <v-container class="pa-4">
      <h3 class="mb-4">Suggested</h3>
        <TaskCard v-for="task in tasks" :key="task.Id" :task="task" color="primary" text-color="secondary--text"/>
    </v-container>
  </div>
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
      tasks: (state) => state.tasks,
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
    selectTask(task){
      console.log(task)
    },
  },
};
</script>
<style lang="scss" scoped>

</style>
