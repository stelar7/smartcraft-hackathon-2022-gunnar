<template>
    <div class="step-container">
        <p class="avatar">{{step}}</p>
        <div :class="[styleForStep, 'step']">
            {{step}}
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
    }
  },
  computed: {
    styleForStep() {
        return "step" + this.step;
    }
  }
};
</script>

<style scoped>
    .step-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-bottom: 50px;
        width: 100%;
        padding: 0 5px;
    }
    .step {
        width: 100%;
        display: flex;
        justify-content: center;
        padding-top: 10px;
        box-sizing: border-box;
    }
    .step1 {
        height: 150px;
        background-color: goldenrod;
    }
    .step2 {
        height: 100px;
        background-color: silver;
    }
    .step3 {
        height: 75px;
        background-color: rgb(165, 88, 44);
    }
    .avatar {
        width: 20vw;
        height: 20vw;
        border-radius: 100%;
        background-color: lightgreen;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>