
import axios from "axios";
export const state = () => ({
  isDarkTheme: false,
  user: {
    Name: 'John Doe',
    ThisMonthsScore: 3500,
  },
  loading: {
    user: false,
  },
  currentTask: {
    Id: 1,
    Title: 'Very important task',
    Description: 'You need to quickly fix that leaking pipe in the office or there will be poop flood',
    Customer: 'Jone Hop',
    PhoneNumber: '',
    Address: '',
    State: '',
    Score: 135,
    Deleted: '',
    OwnerId: '',
    EstimatedTime: '',
    StartDate: '',
    CreatedBy: '',
    CreatedDate: '',
    UpdatedBy: '',
    UpdatedDate: '',
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
    const response = await axios.get("http://localhost:8082/api/User");
    return response.data;
  },
  async getTasks({ state, commit }) {

  },
};
