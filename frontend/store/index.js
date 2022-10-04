
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
});

export const mutations = {
  SET_USER(state, user) {
    state.user = user;
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
    return response.data;
  },
  async getTask({ state, commit }, taskId) {
    const response = await axios.get("http://localhost:8082/api/Task/" + taskId);
    return response.data;
  },
  async getTasks({ state, commit }, userId) {
    const response = await axios.get("http://localhost:8082/api/Task/owner/" + userId);
    return response.data;
  },
  async reserveTask({ state, commit }, taskId) {
    await axios.put("http://localhost:8082/api/Task/Reserve/" + taskId);
  },
  async setAsCurrentTask({ state, commit }, taskId) {
    await axios.put("http://localhost:8082/api/Task/SetAsActive/" + taskId);
  },
  async completeTask({ state, commit }, taskId) {
    await axios.put("http://localhost:8082/api/Task/Complete/" + taskId);
  },
  async getLeaderboard({ state, commit }, time) {
    switch(time) {
      case "yearly": return (await axios.put("http://localhost:8082/api/User/YearlyLeaders")).data;
      case "monthly": return (await axios.put("http://localhost:8082/api/User/MonthlyLeaders")).data;
      case "weekly": return (await axios.put("http://localhost:8082/api/User/WeeklyLeaders")).data;
    }
    throw new Error("Invalid variable, expected yearly, monthly, or weekly");
  },
};
