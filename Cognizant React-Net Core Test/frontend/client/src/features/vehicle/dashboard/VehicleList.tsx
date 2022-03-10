import { observer } from "mobx-react-lite";
import { Fragment } from "react";
import { Header } from "semantic-ui-react";
import { useStore } from "../../../app/store/store"; 
import ActivityListItem from "./VehicleListItem";

export default observer(function ActivityList() {
    const { vehicleStore } = useStore();
    const { groupedVehicles } = vehicleStore;
    // const { vehiclesByDate } = vehicleStore;


    return (
        <>
            {groupedVehicles.map(([group, vehicles]) => (
                <Fragment key={group}>
                    <Header sub color="teal">
                        {group}
                            {vehicles.map((vehicle) => (
                                <ActivityListItem key={vehicle.id} vehicle={vehicle} />
                            ))}
                    </Header>
                </Fragment>
            ))}

        </>

    )
})