<template>
  <v-app>

    <v-app-bar color="primary" class="header accent--text" app short clipped-left>
      <v-app-bar-nav-icon color="accent" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-spacer />
      <div class="user">
        Username
      </div>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" app floating clipped>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          color="secondary"
          active-class="deep-purple--text text--accent-4"
        >
          <v-list-item>
            <v-list-item-title>Main</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-title>Scoreboard</v-list-item-title>
          </v-list-item>

          <v-list-item>
            <v-list-item-title>Profile</v-list-item-title>
          </v-list-item>

          <v-list-item>
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
}
</style>
