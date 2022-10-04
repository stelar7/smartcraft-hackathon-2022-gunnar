<template>
  <div>
    <v-container class="pa-4">
      <h3 class="mb-4">Current task</h3>
      <TaskCard v-for="task in activeTasks" :key="task.id" :task="task" color="secondary" text-color="primary" @finish="finishTask"/>
    </v-container>

    <v-container class="pa-4">
      <h3 class="mb-4">Next</h3>
      <TaskCard v-for="task in reservedTasks" :key="task.id" :task="task" color="grey" text-color="primary--text" @start="startTask"/>
    </v-container>

    <v-container class="pa-4">
      <h3 class="mb-4">Suggested</h3>
        <TaskCard v-for="task in tasks" :key="task.id" :task="task" color="primary" text-color="secondary--text" @select="selectTask"/>
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
      userTasks: (state) => state.userTasks,
    }),
    reservedTasks() {
      return this.userTasks.filter(task => task.state === 1);
    },
    activeTasks() {
      return this.userTasks.filter(task => task.state === 2);
    },
  },
  watch: {
    user: {
      immediate: true,
      deep: true,
      handler(user){
        this.getTasks(user.id);
      }
    }
  },
  created() {
    this.getAvailableTasks();
  },
  methods: {
    ...mapActions({
      getAvailableTasks: 'getAvailableTasks',
      getTasks: 'getTasks',
      reserveTask: 'reserveTask',
      activateTask: 'activateTask',
      completeTask: 'completeTask',
    }),
    async selectTask(task){
      await this.reserveTask({taskId: task.id, userId: this.user.id});
      this.getTasks(this.user.id);
    },
    async startTask(task){
      await this.activateTask(task.id);
      this.getTasks(this.user.id);
    },
    async finishTask(task){
      await this.completeTask(task.id);
      this.getTasks(this.user.id);
    },
  },
};
</script>
<style lang="scss" scoped>

</style>
