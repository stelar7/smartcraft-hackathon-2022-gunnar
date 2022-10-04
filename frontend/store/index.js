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
    PhoneNumber: '77442634',
    Address: 'Some street 2, 2322 City',
    State: '',
    Score: 135,
    Deleted: '',
    OwnerId: '',
    EstimatedTime: '',
    StartDate: '05.10.2022',
    CreatedBy: '',
    CreatedDate: '',
    UpdatedBy: '',
    UpdatedDate: '',
  },
  tasks: [
    {
      Id: 3,
      Title: 'Very important task 3',
      Description: 'You need to quickly fix that leaking pipe in the office or there will be poop flood',
      Customer: 'Jone Hop',
      PhoneNumber: '77442634',
      Address: 'Some street 2, 2322 City',
      State: '',
      Score: 135,
      Deleted: '',
      OwnerId: '',
      EstimatedTime: '',
      StartDate: '05.10.2022',
      CreatedBy: '',
      CreatedDate: '',
      UpdatedBy: '',
      UpdatedDate: '',
    },
    {
      Id: 4,
      Title: 'Very important task 4',
      Description: 'You need to quickly fix that leaking pipe in the office or there will be poop flood',
      Customer: 'Jone Hop',
      PhoneNumber: '77442634',
      Address: 'Some street 2, 2322 City',
      State: '',
      Score: 135,
      Deleted: '',
      OwnerId: '',
      EstimatedTime: '',
      StartDate: '05.10.2022',
      CreatedBy: '',
      CreatedDate: '',
      UpdatedBy: '',
      UpdatedDate: '',
    },
    {
      Id: 5,
      Title: 'Very important task 5',
      Description: 'You need to quickly fix that leaking pipe in the office or there will be poop flood',
      Customer: 'Jone Hop',
      PhoneNumber: '77442634',
      Address: 'Some street 2, 2322 City',
      State: '',
      Score: 135,
      Deleted: '',
      OwnerId: '',
      EstimatedTime: '',
      StartDate: '05.10.2022',
      CreatedBy: '',
      CreatedDate: '',
      UpdatedBy: '',
      UpdatedDate: '',
    },
  ],
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
