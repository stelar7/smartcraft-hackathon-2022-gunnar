<template>
  <v-card min-height="200" class="mb-6">
    <v-card-title :class="[color, textColor]">
      {{ task.Title }}
      <v-spacer />
        <fa-icon :icon="['fa', 'trophy']" class="icon amber--text mr-2"/>
        {{ task.Score }}
      <v-btn class="expand-button ml-2" icon @click="show = !show">
        <v-icon>{{ show ? 'mdi-chevron-up' : 'mdi-chevron-down' }}</v-icon>
      </v-btn>
    </v-card-title>
    <v-card-text class="pt-4">
      <div class="d-flex flex-row align-center py-1">
        <span class="overline">{{ task.Address }}</span>
        <v-spacer />
        <span>
          <fa-icon :icon="['fa', 'calendar']" class="" />
          {{ task.StartDate }}
        </span>
      </div>

      <v-expand-transition>
        <div v-show="show">
          <h4>Customer:</h4>
          <div class="d-flex flex-row py-1">
            {{ task.Customer }}
            <v-spacer />
            <span>
              <fa-icon :icon="['fa', 'phone']" class="" />
              {{ task.PhoneNumber }}
            </span>
          </div>
          <div class="mt-2">{{ task.Description }}</div>
        </div>
      </v-expand-transition>
    </v-card-text>

    <v-card-actions class="d-flex flex-row justify-end">
      <v-btn color="info" @click="select">
        SELECT
      </v-btn>
      <v-btn color="success" @click="finish">
        FINISH
      </v-btn>
      <v-btn color="error" @click="cancel">
        CANCEL
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
    finish(){
      this.$emit('finish', this.task)
    },
    cancel(){
      this.$emit('cancel', this.task)
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
