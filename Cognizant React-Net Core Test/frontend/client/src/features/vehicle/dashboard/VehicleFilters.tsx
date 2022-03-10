import React from "react";
import Calendar from "react-calendar";
import { Header, Menu } from "semantic-ui-react";


export default function VehicleFilters() {
    return (
        <>
            <Menu vertical size="large" style={{ width: "100%", marginTop: "15px" }}>
                <Header icon="filter" attached color="teal" content="Filters" />
                <Menu.Item content="All Vehicles" />
                <Menu.Item content="Going" />
                <Menu.Item content="Hosting" />
            </Menu>
            <Header />
            <Calendar locale="en" />
        </>
    )
}