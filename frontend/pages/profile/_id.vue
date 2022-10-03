<template>
  <div>hello {{ $route.params.id }} hello</div>
</template>

<script>
export default {
  name: 'Profile',
  async asyncData({ $axios }) {
    // Fetch any BE data here, then return it as an object to be merged into data();
    const ip = await $axios.$get('https://icanhazip.com');
    return { ip };
  },
};
</script>

<style></style>
