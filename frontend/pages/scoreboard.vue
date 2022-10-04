<template>
  <div>
    <v-tabs
      v-model="tab"
      align-with-title
      background-color="primary"
      dark
      grow
    >
      <v-tabs-slider color="accent"></v-tabs-slider>
      <v-tab key="weekly">Weekly</v-tab>
      <v-tab key="monthly">Monthly</v-tab>
      <v-tab key="alltime">All Time</v-tab>
    </v-tabs>
    <v-tabs-items v-model="tab">
      <v-tab-item
        key="weekly"
      >
        <div class="pt-8">
          <h1 class="text-center mb-12">Scoreboard of the Week</h1>
          <div class="podium-container">
            <PodiumStep 
              v-for="(score, index) in scores"
              :key="score.name"
              :item="score"
              :step="index + 1"
            />
          </div>
          <ScoreTable :scores="scores" />
        </div>
      </v-tab-item>
    </v-tabs-items>
    
  </div>
  
</template>

<script>
export default {
  name: 'ScoreboardPage',
  data() {
    return {
      scores: [
        {
          name: "Emilia",
          score: 4321,
        },
        {
          name: "Steffen",
          score: 1234,
        },
        {
          name: "Hlynur",
          score: 1100,
        },
        {
          name: "Trond",
          score: 1000,
        },
        {
          name: "Martine",
          score: 950,
        },
        {
          name: "Stian",
          score: 900,
        },
        {
          name: "Kari",
          score: 800,
        },
      ],
      tab: "",
    }
  }
};
</script>

<style scoped>
  .podium-container {
    margin: 0 -5px;
    display: flex; 
    align-items: flex-end; 
    justify-content: space-between;
  }
</style>
