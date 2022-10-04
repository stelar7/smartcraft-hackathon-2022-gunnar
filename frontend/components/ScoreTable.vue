<template>
  <v-data-table
    :headers="headers"
    :items="scores"
    :items-per-page="5"
    class="elevation-3"
  ></v-data-table>
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