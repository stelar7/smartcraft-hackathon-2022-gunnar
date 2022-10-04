<template>
  <div class="content">
    <div class="avatar">
      Smith Jones
      <CircularProgress :percent="50">
        <v-avatar color="primary" class="secondary--text" size="124">
          CJ
        </v-avatar>
      </CircularProgress>
    </div>
    <div class="stats">
      <div class="values">
        <span>Highest daily:</span><span>123</span>
        <span>Highest monthly:</span><span>245</span>
        <span>Highest yearly:</span><span>296</span>
      </div>
    </div>
    <div class="badges">
      <fa-icon :icon="['fas', 'user-secret']" />
    </div>
    <div class="themes"></div>
  </div>
</template>

<script>
export default {
  name: 'UserProfile',
  async asyncData({ $axios }) {
    // $route.params.id
    // Fetch any BE data here, then return it as an object to be merged into data();
    const ip = await $axios.$get('https://icanhazip.com');
    return { ip };
  },
};
</script>

<style lang="scss" scoped>
.content {
  display: flex;
  justify-content: center;
  align-content: center;
  flex-direction: column;
  width: 100%;
  height: 100%;
  gap: 20px;

  .avatar {
    margin-top: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 20px;
  }

  .stats {
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: start;
    .values {
      display: flex;
      align-items: flex-start;
    }
  }
}
</style>
