import React, { Fragment, useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';
import { v4 as uuid } from "uuid";
import agent from '../api/agent';


function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);


  useEffect(() => {
    agent.Activities.list().then(response => {
      console.log(response);
      setActivities(response);
    });
  }, [])

  function handleSelectActivity(id: string) {
    setSelectedActivity(activities.find(a => a.id === id));
  }

  function handleCancelSelectActivity() {
    setSelectedActivity(undefined);
  }

  function handleOpenForm(id?: string) {
    id ? handleSelectActivity(id) : handleCancelSelectActivity();
    setEditMode(true);
  }

  function handleCloseForm() {
    setEditMode(false);
  }

  function handleCreateorEditActivity(activity: Activity) {
    activity.id
      ? setActivities([...activities.filter(a => a.id !== activity.id), activity])
      : setActivities([...activities, { ...activity, id: uuid() }]);
    setEditMode(false);
    setSelectedActivity(activity);
  }

  function handleDeleteActivity(id: string) {
    setActivities([...activities.filter(a => a.id !== id)])
  }


  return (
    <>
      <Navbar openForm={handleOpenForm} />
      <Container style={{ marginTop: "7em" }} >
        <ActivityDashboard
          activities={activities}
          selectedActivity={selectedActivity}
          selectActivity={handleSelectActivity}
          cancelSelectActivity={handleCancelSelectActivity}
          editMode={editMode}
          openForm={handleOpenForm}
          closeForm={handleCloseForm}
          createOrEdit={handleCreateorEditActivity}
          deleteActivity={handleDeleteActivity}
        />
      </Container>
    </>
  );
}

export default App;
