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
      <div><span>Highest daily:</span><span>123</span></div>
      <div><span>Highest monthly:</span><span>245</span></div>
      <div><span>Highest yearly:</span><span>296</span></div>
    </div>
    <v-divider />
    <h1>Badges</h1>
    <div class="badges">
      <div>a</div>
      <div>b</div>
      <div>c</div>
      <div>d</div>
      <div>e</div>
    </div>
    <v-divider />
    <h1>Themes</h1>
    <div class="themes">
      <div>a</div>
      <div>b</div>
      <div>c</div>
      <div>d</div>
      <div>e</div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'UserProfile',
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

  h1 {
    place-self: center;
  }

  .stats {
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: start;

    > div {
      display: flex;
      gap: 10px;
      justify-content: space-between;
      span:first-child {
        text-align: right;
      }
      > span {
        width: 200px;
      }
    }
  }

  .badges {
    display: grid;
    place-content: center;
    grid-auto-rows: 50px;
    grid-template-columns: repeat(5, 50px);
    gap: 20px;
    
    > div {
      background: cyan;
      width: 100%;
      height: 100%;
      display: grid;
      place-items: center;
    }
  }

  .themes {
    display: grid;
    place-content: center;
    grid-auto-rows: 50px;
    grid-template-columns: repeat(5, 50px);
    gap: 20px;
    margin-bottom: 20px;
    
    > div {
      background: cyan;
      width: 100%;
      height: 100%;
      display: grid;
      place-items: center;
    }
  }
}
</style>
