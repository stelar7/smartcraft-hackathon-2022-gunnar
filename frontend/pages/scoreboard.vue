<template>
  <div>
    <h1>hello this is the Scoreboard page :)</h1>
    <div class="podium-container">
      <PodiumStep step="2" />
      <PodiumStep step="1" />
      <PodiumStep step="3" />
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
          name: "Steffen",
          score: 1234,
        },
        {
          name: "Emilia",
          score: 4321,
        }
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
