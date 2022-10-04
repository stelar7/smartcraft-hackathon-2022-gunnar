<template>
  <v-card min-height="200" class="mb-6">
    <v-card-title :class="[color, textColor]">
      {{ task.title }}
      <v-spacer />
        <fa-icon :icon="['fa', 'trophy']" class="icon amber--text mr-2"/>
        {{ task.score }}
      <v-btn class="expand-button ml-2" icon @click="show = !show">
        <v-icon color="black">{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
      </v-btn>
    </v-card-title>
    <v-card-text class="pt-4">
      <div class="d-flex flex-row align-center py-1">
        <span class="overline">
          {{ task.address.street }}
          {{ task.address.postalCode }}
          {{ task.address.city }}
          </span>
        <v-spacer />
        <span>
          <fa-icon :icon="['fa', 'calendar']" class="" />
          {{ task.startDate }}
        </span>
      </div>

      <v-expand-transition>
        <div v-show="show">
          <h4>Customer:</h4>
          <div class="d-flex flex-row py-1">
            {{ task.customer }}
            <v-spacer />
            <span>
              <fa-icon :icon="['fa', 'phone']" class="" />
              {{ task.phoneNumber }}
            </span>
          </div>
          <div class="mt-2">{{ task.description }}</div>
        </div>
      </v-expand-transition>
    </v-card-text>

    <v-card-actions class="d-flex flex-row justify-end">
      <v-btn v-if="task.state === 0" color="info" @click="select">
        SELECT
      </v-btn>
      <v-btn v-if="task.state === 1" color="warning" @click="start">
        START
      </v-btn>
      <v-btn v-if="task.state === 2" color="success" @click="finish">
        FINISH
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: 'TaskCard',
  props: {
    color: {
      type: String,
      default: 'primary',
    },
    textColor: {
      type: String,
      default: 'secondary--text',
    },
    task: {
      type: Object,
      default: () => {},
    },
  },
  data: () => ({
    show: false,
  }),

  computed: {},

  methods: {
    select(){
      this.$emit('select', this.task)
    },
    start(){
      this.$emit('start', this.task)
    },
    finish(){
      this.$emit('finish', this.task)
    },
  },
};
</script>

<style lang="scss" scoped>
.expand-button {
  background-color: white;
  opacity: 0.3;

  &:hover {
    opacity:0.2
  }
}
</style>
