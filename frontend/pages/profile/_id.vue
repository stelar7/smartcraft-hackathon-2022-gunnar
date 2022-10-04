<template>
  <div class="content">
    <div class="avatar">
      <span class="name">{{ user.Name }}</span>
      <CircularProgress :value="67" :to="100">
        <v-avatar color="primary" class="secondary--text" size="124">
          CJ
        </v-avatar>
      </CircularProgress>
      <span class="score">{{user.ThisMonthsScore}} Points!</span>
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
      <div :class="['one', { nooutline: !isDark }]" @click="toggleTheme(false)">
        a
      </div>
      <div :class="['two', { nooutline: isDark }]" @click="toggleTheme(true)">
        b
      </div>
      <v-tooltip top>
        <template #activator="{ on, attrs }">
          <div class="three" v-bind="attrs" v-on="on">
            <fa-icon :icon="['fa', 'lock']" />
          </div>
        </template>
        90000 Points to unlock
      </v-tooltip>
      <v-tooltip top>
        <template #activator="{ on, attrs }">
          <div class="four" v-bind="attrs" v-on="on">
            <fa-icon :icon="['fa', 'lock']" />
          </div>
        </template>
        100000 Points to unlock
      </v-tooltip>
      <v-tooltip top>
        <template #activator="{ on, attrs }">
          <div class="five" v-bind="attrs" v-on="on">
            <fa-icon :icon="['fa', 'lock']" />
          </div>
        </template>
        110000 Points to unlock
      </v-tooltip>
    </div>
  </div>
</template>

<script>
import { mapMutations, mapState } from 'vuex';

export default {
  name: 'UserProfile',
  computed: {
    ...mapState({
      isDark: (state) => state.isDarkTheme,
      user: (state) => state.user,
    }),
  },
  methods: {
    ...mapMutations({
      changeTheme: 'changeTheme',
    }),
    toggleTheme(dark) {
      this.changeTheme(dark);
      this.$vuetify.theme.dark = dark;
    },
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

    .name {
      font-size: 2rem;
      font-weight: bold;
    }

    .score {
      font-size: 1.5rem;
      font-weight: bold;
    }
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
      width: 100%;
      height: 100%;
      display: grid;
      place-items: center;
      cursor: pointer;
      outline: dashed;
      outline-offset: 2px;
      outline-color: black;
    }

    .nooutline {
      outline: none;
      cursor: default;
    }

    .one {
      background: wheat;
    }

    .two {
      background: black;
      color: white;
    }
    .three {
      background: hotpink;
    }
    .four {
      background: yellow;
    }
    .five {
      background: purple;
    }
  }
}
</style>
