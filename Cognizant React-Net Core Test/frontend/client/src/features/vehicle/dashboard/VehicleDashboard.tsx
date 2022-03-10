import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import { useStore } from "../../../app/store/store";
import VehicleList from "./VehicleList";
import { observer } from 'mobx-react-lite';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import VehicleFilters from './VehicleFilters';



export default observer(function VehicleDashboard() {
    const { vehicleStore } = useStore();
    const { loadVehicles, vehicleRegistry, loadingInitial } = vehicleStore;

    useEffect(() => {
        if (vehicleRegistry.size <= 1) loadVehicles();
    }, [vehicleRegistry.size, loadVehicles])

    if (loadingInitial) return <LoadingComponent content='Loading...Please wait...' />


    return (
        <Grid>
            <Grid.Column width={12}>
                <VehicleList
                />
            </Grid.Column>
            <Grid.Column width={4}>
                <VehicleFilters />
            </Grid.Column>
        </Grid>
    )
})