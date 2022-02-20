import React, { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import { List, Container } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>("http://localhost:5001/api/activities").then(response => {
      console.log(response.data);
      setActivities(response.data);
    });
  }, [])


  return (
    <>
      <Navbar />
      <Container style={{ marginTop: "7em" }} >
        <ActivityDashboard activities={activities} />
      </Container>
    </>
  );
}

export default App;
