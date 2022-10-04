<template>
  <div class="circle-wrap">
    <div class="circle">
      <v-tooltip top>
        <template #activator="{ on, attrs }">
          <div class="mask full" :style="transformStyle"  v-bind="attrs" v-on="on">
            <div class="fill" :style="transformStyle"  v-bind="attrs" v-on="on"></div>
          </div>
          <div class="mask half"  v-bind="attrs" v-on="on">
            <div class="fill" :style="transformStyle"  v-bind="attrs" v-on="on"></div>
          </div>
        </template>
        {{ to - value}} Points to next unlock
      </v-tooltip>
      <div class="inside-circle"><slot /></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CircularProgress',
  props: {
    to: {
      type: Number,
      default: 0,
    },
    value: {
      type: Number,
      default: 0,
    },
    size: {
      type: Number,
      default: 0,
    },
  },
  computed: {
    percent() {
      return (this.value / this.to) * 100;
    },
    circlePercent() {
      return (180 / 100) * this.percent;
    },
    transformStyle() {
      return {
        transform: 'rotate(' + this.circlePercent + 'deg)',
      };
    },
  },
};
</script>

<style lang="scss" scoped>
.circle-wrap {
  background: #fefcff;
  border-radius: 50%;
  border: 1px solid #cdcbd0;
  width: 150px;
  height: 150px;

  .circle {
    .mask,
    .fill {
      width: 150px;
      height: 150px;
      position: absolute;
      border-radius: 50%;
    }

    .mask {
      clip: rect(0px, 150px, 150px, 75px);
    }
  }

  .inside-circle {
    width: 124px;
    height: 124px;
    border-radius: 50%;
    background: #d2eaf1;
    line-height: 120px;
    text-align: center;
    margin-top: 12px;
    margin-left: 12px;
    color: #1e51dc;
    position: absolute;
    z-index: 1;
    font-weight: 700;
    font-size: 2em;
  }
}

.mask .fill {
  clip: rect(0px, 75px, 150px, 0px);
  background-color: var(--v-accent-base);
}
</style>
