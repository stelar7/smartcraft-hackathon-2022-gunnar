export const state = () => ({
  user: {
    Name: 'John Doe',
    ThisMonthsScore: 234562,
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
};

export const actions = {
  async getUser({ state, commit }) {

  },
  async getTasks({ state, commit }) {

  },

};
