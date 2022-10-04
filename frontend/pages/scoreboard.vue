<template>
  <div>
    <h1>hello this is the Scoreboard page :)</h1>
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
      ]
    }
  }
};
</script>

<style>
  .podium-container {
    margin: 0 -5px;
    display: flex; 
    align-items: flex-end; 
    justify-content: space-between;
  }
</style>
