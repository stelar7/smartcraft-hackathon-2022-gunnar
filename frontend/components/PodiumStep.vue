<template>
    <div :class="['step-container', 'step-container-' + step]" v-if="step < 4">
        <p class="avatar">{{item.name}}</p>
        <div :class="[styleForStep, 'step']">
            <p class="podium-title">{{step}}</p>
            <p class="podium-score">{{item.score}}</p>
        </div>
    </div>
</template>

<script>
export default {
  name: 'PodiumStep',
  props:  {
    step: {
        type: Number, 
        required: true,
    }, 
    item: {
        type: Object,
        required: true,
    }
  },
  computed: {
    styleForStep() {
        return "step" + this.step;
    }
  }
};
</script>

<style lang="scss" scoped>
    .step-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-bottom: 50px;
        width: 90%;
        max-width: 100%;
        padding: 0 5px;
        &-1 {
            order: 2;
        }
        &-2 {
            order: 1;
        }
        &-3 {
            order: 3;
        }
    }
    .step {
        font-size: 20px;
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: flex-start;
        padding-top: 10px;
        box-sizing: border-box;
        border-radius: 5px 5px 0 0;
        .podium-title {
            font-size: 28px;
            font-weight: bold;
            margin: 0;
        }
    }
    .step1 {
        height: 200px;
        background-color: #c91dc9;
        .podium-title {
            color: #4e0b4e;
        }
    }
    .step2 {
        height: 150px;
        background-color: #65d91c;
        .podium-title {
            color: #2d610c;
        }
    }
    .step3 {
        height: 100px;
        background-color: #ff9116;
        .podium-title {
            color: #6c3900;
        }
    }
    .avatar {
        width: 20vw;
        height: 20vw;
        border-radius: 100%;
        background-color: #eee;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>