import { createContext, useContext } from 'react';
import VehicleStore from './vehicleStore';


interface Store {
      vehicleStore: VehicleStore
}

export const store: Store = {
      vehicleStore: new VehicleStore()
}


export const StoreContext = createContext(store);

export function useStore() {
      return useContext(StoreContext);
}