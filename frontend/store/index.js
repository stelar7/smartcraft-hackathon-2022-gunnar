
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
    return response.data;
  },
  async getTasks({ state, commit }) {

  },
};
