<template>
    <div>
        <v-tabs v-model="tab" background-color="primary" dark grow class="fixed-tabs-bar">
            <v-tabs-slider color="accent"></v-tabs-slider>
            <v-tab key="weekly">Weekly</v-tab>
            <v-tab key="monthly">Monthly</v-tab>
            <v-tab key="alltime">All Time</v-tab>
        </v-tabs>
        <v-tabs-items v-model="tab" style="background: #F6F4F2" class="pa-4 mt-12">

            <!-- WEEKLY -->
            <v-tab-item key="weekly">
                <div>
                    <h1 class="text-center mb-8">Scoreboard of the Week</h1>
                    <div class="podium-container">
                        <PodiumStep 
                            v-for="(score, index) in scores" 
                            :key="score.name" 
                            :item="score"
                            :step="index + 1" 
                            :tabItem="0" 
                            :tab="tab" />
                    </div>
                    <ScoreTable :scores="scores" />
                </div>
            </v-tab-item>

            <!-- MONTHLY -->
            <v-tab-item key="monthly">
                <div>
                    <h1 class="text-center mb-8">Scoreboard of the Month</h1>
                    <div class="podium-container">
                        <PodiumStep 
                            v-for="(score, index) in scores" 
                            :key="score.name" 
                            :item="score" 
                            :step="index + 1" 
                            :tab="tab"
                            :tabItem="1" />
                    </div>
                    <ScoreTable :scores="scores" />
                </div>
            </v-tab-item>

            <!-- ALLTIME -->
            <v-tab-item key="alltime">
                <div>
                    <h1 class="text-center mb-8">Scoreboard of All Time</h1>
                    <div class="podium-container">
                        <PodiumStep
                            v-for="(score, index) in scores"
                            :key="score.name" 
                            :item="score" 
                            :step="index + 1" 
                            :tab="tab"
                            :tabItem="2" />
                    </div>
                    <ScoreTable :scores="scores" />
                </div>
            </v-tab-item>
        </v-tabs-items>
    </div>

</template>

<script>
export default {
    name: 'ScoreboardPage',
    data() {
        return {
            scores: [
                {
                    name: "Emilia",
                    score: 4321,
                },
                {
                    name: "Steffen",
                    score: 1234,
                },
                {
                    name: "Hlynur",
                    score: 1100,
                },
                {
                    name: "Trond",
                    score: 1000,
                },
                {
                    name: "Martine",
                    score: 950,
                },
                {
                    name: "Stian",
                    score: 900,
                },
                {
                    name: "Kari",
                    score: 800,
                },
            ],
            tab: "",
        }
    }
};
</script>

<style lang="scss" scoped>
.podium-container {
    height: 452px;
    margin: 0 -5px;
    display: flex;
    align-items: flex-end;
    justify-content: space-between;
}

.fixed-tabs-bar {
    ::v-deep .v-tabs-bar {
        position: fixed;
        width: 100%;
        z-index: 2;
    }
}
</style>
