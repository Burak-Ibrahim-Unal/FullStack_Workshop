import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid } from 'semantic-ui-react';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { useStore } from "../../../app/store/store";
import VehicleDetailChat from "./VehicleDetailChat";
import VehicleDetailHeader from "./VehicleDetailHeader";
import VehicleDetailInfo from "./VehicleDetailInfo";
import VehicleDetailSidebar from "./VehicleDetailSidebar";



export default observer(function VehicleDetails() {
    const { vehicleStore } = useStore();
    const { selectedVehicle: vehicle, loadVehicle, loadingInitial } = vehicleStore;
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) loadVehicle(id);
    }, [id, loadVehicle]);

    if (loadingInitial || !vehicle) return <LoadingComponent />;


    return (
       <Grid>
            <Grid.Column width={12}>
                <VehicleDetailHeader vehicle={vehicle}/>
                <VehicleDetailInfo vehicle={vehicle}/>
                <VehicleDetailChat />
            </Grid.Column>

            <Grid.Column width={4}>
                <VehicleDetailSidebar />
            </Grid.Column>
       </Grid>
    )
})

