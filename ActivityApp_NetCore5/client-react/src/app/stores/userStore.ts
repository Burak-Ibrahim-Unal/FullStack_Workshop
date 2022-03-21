import { User, UserFormValues } from '../models/user';
import { makeAutoObservable, runInAction } from 'mobx';
import agent from '../api/agent';
import { store } from './store';
import { history } from '../..';

export default class UserStore {
      user: User | null = null;

      constructor() {
            makeAutoObservable(this);
      }

      get isLoggedIn() {
            return !!this.user;
      }

      login = async (creds: UserFormValues) => {
            try {
                  const user = await agent.Accounts.login(creds);
                  store.commonStore.setToken(user.token);
                  runInAction(() => this.user = user);
                  history.push("/activities")
            } catch (error) {
                  throw error;
            }
      }

      logout = () => {
            store.commonStore.setToken(null);
            window.localStorage.removeItem("jwt");
            this.user = null;
            history.push("/");
      }

}