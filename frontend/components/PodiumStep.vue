<template>
    <v-container v-if="step < 4" :class="['step-container', 'step-container-' + step]">
        <v-avatar
            v-if="step === 1"
            size="40"
            class="mb-6"
        >
            <fa-icon :icon="['fa', 'trophy']" class="icon amber--text"/>
        </v-avatar>
        <v-avatar color="primary" class="avatar" :size="124 - (step * 10)">
            {{item.name}}
        </v-avatar>
        
        <div :class="[styleForStep, 'step']">
            <p class="podium-title">{{step}}</p>
            <p class="podium-score">{{item[scoreKey]}}</p>
        </div>
    </v-container>
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
    },
    tab: {
        type: Number,
        required: true,
    },
    tabItem: {
        type: Number,
        required: true,
    },
    scoreKey: {
        type: String,
        required: true,
    }
  },
  data() {
    return {
        expand: false,
    }
  },
  computed: {
    styleForStep() {
        return "step" + this.step;
    },
  },
};
</script>

<style lang="scss" scoped>
    .step-container {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: flex-end;
        margin-bottom: 50px;
        width: 90%;
        max-width: 100%;
        padding: 0 5px;
        &-1 {
            order: 2;
            .avatar {
                font-size: 22px;
            }
        }
        &-2 {
            order: 1;
            .avatar {
                font-size: 20px;
            }
        }
        &-3 {
            order: 3;
            .avatar {
                font-size: 18px;
            }
        }
    }
    .step {
        font-size: 20px;
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: flex-start;
        box-sizing: border-box;
        border-radius: 5px 5px 0 0;
        .podium-title {
            font-size: 28px;
            font-weight: bold;
            margin: 0;
        }
    }
    .step1 {
        background-color: #c91dc9;
        height: 200px;
        .podium-title {
            color: #4e0b4e;
        }
    }
    .step2 {
        background-color: #65d91c;
        height: 150px;
        .podium-title {
            color: #2d610c;
        }
    }
    .step3 {
        background-color: #ff9116;
        height: 100px;
        .podium-title {
            color: #6c3900;
        }
    }
    .avatar {
        margin-bottom: 24px;
        color: #FFF;
    }
</style>