import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";
import "../layout/sytles.css";
import { useStore } from "../stores/store";


export default function Navbar() {
    const { activityStore } = useStore();


    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item header>
                    <img src="assets/logo.png" alt="logo" style={{ marginRight: "10px" }} />
                    Activities
                </Menu.Item>
                <Menu.Item name="All Activities" />
                <Menu.Item>
                    <Button onClick={() => activityStore.openForm} positive content="Create Activity" />
                </Menu.Item>
            </Container>
        </Menu>
    )
}