import { observer } from "mobx-react-lite";
import React, { ChangeEvent, useEffect, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/store/store";
import { NavLink, useHistory, useParams } from 'react-router-dom';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { v4 as uuid } from 'uuid';



export default observer(function VehicleForm() {
    const history = useHistory();
    const { vehicleStore } = useStore();
    const { createVehicle, updateVehicle, loading, loadVehicle, loadingInitial } = vehicleStore;
    const { id } = useParams<{ id: string }>();


    const [vehicle, setVehicle] = useState({
        id: "",
        make: "",
        model: "",
        year_model: 1900,
        price: 0,
        licenced: false,
        date_added: ""
    });

    // explanation mark means it can be undefined
    useEffect(() => {
        if (id) loadVehicle(id).then(vehicle => setVehicle(vehicle!))
    }, [id, loadVehicle]);



    function handleSubmit() {
        if (vehicle.id.length === 0) {
            let newVehicle = {
                ...vehicle,
            };
            createVehicle(newVehicle).then(() => {
                history.push(`/vehicles/${newVehicle.id}`);
            })
        }else {
            updateVehicle(vehicle).then(()=> {
                history.push(`/vehicles/${vehicle.id}`);
            })
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setVehicle({ ...vehicle, [name]: value })
    }


    if (loadingInitial) return <LoadingComponent content="Loading vehicle.Please Wait..." />

    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete="off">
                <Form.Input placeholder="Make" value={vehicle.make} name="make" onChange={handleInputChange} />
                <Form.TextArea placeholder="Model" value={vehicle.model} name="model" onChange={handleInputChange} />
                <Form.Input placeholder="Price" value={vehicle.price} name="price" onChange={handleInputChange} />
                <Form.Input type="Year_model" placeholder="Date" value={vehicle.year_model} name="year_model" onChange={handleInputChange} />
                <Form.Input placeholder="Licenced" value={vehicle.licenced} name="licenced" onChange={handleInputChange} />
                <Form.Input placeholder="Date_added" value={vehicle.date_added} name="date_added" onChange={handleInputChange} />
                <Button floated="right" positive type="submit" content="Submit" loading={loading} />
                <Button as={NavLink} to="/vehicles" floated="right" type="button" content="Cancel" />
            </Form>
        </Segment>
    )
})