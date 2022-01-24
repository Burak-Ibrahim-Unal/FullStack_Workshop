import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header, List, ListItem } from "semantic-ui-react";

function App() {
    const [activities, setActivities] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:5001/api/activities").then(response => {
            setActivities(response.data);
            console.log(response.data);
        })
    }, []);




    return (
        <div>
            <Header as='h2' icon='users' content='Activities' />
            <List>
                {activities.map((activity: any) => (
                    <List.Item key={activity.id}>
                        {activity.title}
                    </List.Item>
                ))}
            </List>
        </div>
    );
}

export default App;
