<template>
  <v-app>

    <v-app-bar color="primary" class="header accent--text" app fixed short clipped-left>
      <v-app-bar-nav-icon color="accent" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-spacer />
      <div class="user d-flex flex-row">
        <div class=monthly-score>
          <v-avatar
            color="primary"
            size="40"
          >
            <fa-icon :icon="['fa', 'trophy']" class="icon amber--text"/>
          </v-avatar>

            {{ user.ThisMonthsScore }}
        </div>
        <div>
          <v-avatar
            color="accent"
            size="40"
          >
            <fa-icon :icon="['fa', 'user']" class="icon primary--text"/>
          </v-avatar>

          {{ user.Name }}
        </div>
      </div>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" fixed app floating clipped>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          color="secondary"
          active-class="deep-purple--text text--accent-4"
        >
          <v-list-item :to="{name:'index'}" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Main</v-list-item-title>
          </v-list-item>

          <v-list-item :to="{name:'scoreboard'}" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Scoreboard</v-list-item-title>
          </v-list-item>

          <v-list-item :to="{name:'profile-id', params: {id: 'user-id-goes-here'}}" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Profile</v-list-item-title>
          </v-list-item>

          <v-list-item :to="{name:'logout'}" exact @click.stop="drawer = !drawer">
            <v-list-item-title>Log out</v-list-item-title>
          </v-list-item>

        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <Nuxt class="app" />

  </v-app>
</template>

<script>
import { mapActions, mapState } from 'vuex';

export default {
  data: () => ({
    drawer: false,
    group: null,
  }),

  computed: {
    ...mapState({
      user: (state) => state.user,
      loadingUser: (state) => state.loading.user,
    }),
  },

  watch: {
    group() {
      this.drawer = false;
    },
  },
  created() {
    this.getUser();
  },

  methods: {
    ...mapActions({
      getUser: 'getUser',
    }),
  },


};
</script>

<style lang="scss" scoped>

.app {
  height: 100%;
  margin-top: 56px;
  background: #F6F4F2;
}
.user {
  gap: 20px;
}
.icon {
  width: 35px;
  height: 35px;
}
</style>
