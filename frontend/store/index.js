
import axios from "axios";


export const state = () => ({
  isDarkTheme: false,
  currentUserId: "11111111-1111-1111-1111-111111111111",
  user: {
  },
  loading: {
    user: false,
  },
  currentTask: {
  },
  tasks: [],
  userTasks: [],
});

export const mutations = {
  SET_USER(state, user) {
    state.user = user;
  },
  SET_TASKS(state, tasks) {
    state.tasks = tasks;
  },
  SET_USER_TASKS(state, tasks) {
    state.userTasks = tasks;
  },
  changeTheme(state, dark) {
    state.isDarkTheme = dark;
  }
};


export const actions = {
  async getUser({ state, commit }) {
    const response = await axios.get("http://localhost:8082/api/User/" + state.currentUserId);
    commit("SET_USER", response.data);
  },
  async getAvailableTasks({ state, commit }) {
    const response = await axios.get("http://localhost:8082/api/Task");
    commit("SET_TASKS", response.data);
  },
  async getTask({ state, commit }, taskId) {
    const response = await axios.get("http://localhost:8082/api/Task/" + taskId);
    return response.data;
  },
  async getTasks({ state, commit }, userId) {
    const response = await axios.get("http://localhost:8082/api/Task/owner/" + userId);
    commit("SET_USER_TASKS", response.data);
  },
  async reserveTask({ state, commit }, {taskId, userId}) {
    await axios.put("http://localhost:8082/api/Task/Reserve/" + taskId + '?userId='+ userId);
  },
  async activateTask({ state, commit }, taskId) {
    await axios.put("http://localhost:8082/api/Task/SetAsActive/" + taskId);
  },
  async completeTask({ state, commit }, taskId) {
    await axios.put("http://localhost:8082/api/Task/Complete/" + taskId);
  },
  async getLeaderboard({ state, commit }, time) {
    switch(time) {
      case "yearly": return (await axios.get("http://localhost:8082/api/User/YearlyLeaders")).data;
      case "monthly": return (await axios.get("http://localhost:8082/api/User/MonthlyLeaders")).data;
      case "weekly": return (await axios.get("http://localhost:8082/api/User/WeeklyLeaders")).data;
    }
    throw new Error("Invalid variable, expected yearly, monthly, or weekly");
  },
};
