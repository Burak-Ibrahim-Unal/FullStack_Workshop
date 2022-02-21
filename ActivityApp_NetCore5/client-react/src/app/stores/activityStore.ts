import { makeObservable, observable } from "mobx";

export default class ActivityStore {
      title = "Mobx Hello";

      constructor() {
            makeObservable(this, {
                  title: observable
            })
      }



}