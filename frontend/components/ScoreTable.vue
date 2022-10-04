<template>
  <div>
    <v-card
      class="list-item-wrapper"
      v-for="(score, index) in scores"
      :key="score.name"
      elevation="1"
    >
    <v-card-subtitle class="d-flex justify-space-between" v-if="index > 2">
      <div>{{ index + 1 + ". " + score.name }}</div>
      <div>{{ score.score }}</div>
    </v-card-subtitle>
  </v-card>
  </div>
</template>

<script>
export default {
  name: 'ScoreTable',
  props: ["scores"],
  computed: {
    headers() {
        return [
            {
                text: "name",
                value: "name"
            },
            {
                text: "score",
                value: "score",
            }
        ]
    },
  }
};
</script>

<style>
  .list-item-wrapper {
    margin-bottom: 10px;
  }
</style>