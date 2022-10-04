<template>
  <v-app>

    <v-app-bar color="primary" class="header accent--text" app fixed short clipped-left>
      <v-app-bar-nav-icon color="accent" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-spacer />
      <div class="user">
        Username
      </div>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" fixed app floating clipped>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          color="secondary"
          active-class="deep-purple--text text--accent-4"
        >
          <v-list-item to="main" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Main</v-list-item-title>
          </v-list-item>

          <v-list-item to="scoreboard" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Scoreboard</v-list-item-title>
          </v-list-item>

          <v-list-item to="profile" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Profile</v-list-item-title>
          </v-list-item>

          <v-list-item to="logout" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Log out</v-list-item-title>
          </v-list-item>

        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <Nuxt class="app" />

  </v-app>
</template>

<script>
export default {
  data: () => ({
    drawer: false,
    group: null,
  }),

  watch: {
    group() {
      this.drawer = false;
    },
  },
};
</script>

<style lang="scss" scoped>

.app {
  height: 100%;
  margin-top: 56px;
  background: #F6F4F2;
}
</style>
