import { action, makeAutoObservable } from "mobx";

export default class ActivityStore {
      title = "Mobx Hello";

      constructor() {
            makeAutoObservable(this)
      }

      // constructor() {
      //       makeAutoObservable(this, {
      //             title: observable,
      //             // setTitle: action.bound // auto bind this function to class if we dont use arrow function
      //             setTitle: action.bound //if we use arrow function,it is auto bind
      //       })
      // }


      setTitle = () => {
            this.title = this.title + " !!!";
      }

}