import { makeAutoObservable, runInAction } from 'mobx';
import vehicleAgent from "../api/vehicleAgent";
import { Vehicle } from '../models/vehicle';

export default class VehicleStore {
      vehicleRegistry = new Map<string, Vehicle>();
      selectedVehicle: Vehicle | undefined = undefined;
      editMode = false;
      loading = false;
      loadingInitial = true;

      constructor() {
            makeAutoObservable(this)
      }


      get vehiclesByDate() {
            return Array.from(this.vehicleRegistry.values()).sort((a, b) =>
                  Date.parse(a.DateAdded) - Date.parse(b.DateAdded));
      }


      get groupedVehicles() {
            return Object.entries(
                  this.vehiclesByDate.reduce((vehicles, vehicle) => {
                        const date = vehicle.DateAdded;
                        vehicles[date] = vehicles[date] ? [...vehicles[date], vehicle] : [vehicle];
                        return vehicles;
                  }, {} as { [key: string]: Vehicle[] })
            )
      }


      loadVehicles = async () => {
            this.loadingInitial = true;
            try {

                  const vehicles = await vehicleAgent.Vehicles.list();
                  vehicles.forEach(vehicle => {
                        this.setVehicle(vehicle);
                  })
                  this.setLoadingInitial(false);


            } catch (error) {
                  console.log(error)
                  this.setLoadingInitial(false);
            }

      }

      loadVehicle = async (id: string) => {
            let vehicle = this.getVehicle(id);

            if (vehicle) {
                  this.selectedVehicle = vehicle;
                  return vehicle;

            } else {
                  this.loadingInitial = true;

                  try {
                        vehicle = await vehicleAgent.Vehicles.details(id);
                        this.setVehicle(vehicle);
                        runInAction(() => {
                              this.selectedVehicle = vehicle;
                        })
                        this.setLoadingInitial(false);
                        return vehicle;
                  } catch (error) {
                        console.log(error);
                        this.setLoadingInitial(false);
                  }
            }
      }

      private setVehicle = (vehicle: Vehicle) => {
            vehicle.DateAdded = vehicle.DateAdded.split("T")[0];
            this.vehicleRegistry.set(vehicle.id, vehicle);
      }

      private getVehicle = (id: string) => {
            return this.vehicleRegistry.get(id);
      }

      setLoadingInitial = (state: boolean) => {
            this.loadingInitial = state;
      }

      createVehicle = async (vehicle: Vehicle) => {
            this.loading = true;
            try {
                  await vehicleAgent.Vehicles.create(vehicle)
                  runInAction(() => {
                        this.vehicleRegistry.set(vehicle.id, vehicle);
                        this.selectedVehicle = vehicle;
                        this.editMode = false;
                        this.loading = false;
                  })
            } catch (error) {
                  console.log(error);
                  runInAction(() => {
                        this.loading = false;
                  })
            }

      }

      updateVehicle = async (vehicle: Vehicle) => {
            this.loading = true;
            try {
                  await vehicleAgent.Vehicles.update(vehicle);
                  runInAction(() => {
                        this.vehicleRegistry.set(vehicle.id, vehicle);
                        this.selectedVehicle = vehicle;
                        this.editMode = false;
                        this.loading = false;
                  })
            } catch (error) {
                  console.log(error);
                  runInAction(() => {
                        this.loading = false;
                  })
            }
      }

      deleteVehicle = async (id: string) => {
            this.loading = true;
            try {
                  await vehicleAgent.Vehicles.delete(id);
                  runInAction(() => {
                        this.vehicleRegistry.delete(id);
                        this.loading = false;
                  })
            } catch (error) {
                  console.log(error);
                  runInAction(() => {
                        this.loading = false;
                  })
            }
      }

}