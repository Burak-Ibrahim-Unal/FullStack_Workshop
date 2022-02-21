import React, { Fragment, useEffect, useState } from 'react';
import { Container, SemanticWIDTHS } from 'semantic-ui-react';
import { Activity } from '../models/activity';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';
import { v4 as uuid } from "uuid";
import agent from '../api/agent';
import LoadingComponent from './LoadingComponents';


function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  const [mainPageWidth, setMainPageWidth] = useState<SemanticWIDTHS | undefined>(16);
  const [mainDetailWidth, setDetailPageWidth] = useState<SemanticWIDTHS | undefined>();
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);


  useEffect(() => {
    agent.Activities.list().then(response => {
      // console.log(response);
      let activities: Activity[] = [];
      response.forEach(activity => {
        activity.date = activity.date.split("T")[0];
        activities.push(activity);
      })

      setActivities(activities);
      setLoading(false);
    });
  }, [])

  function handleSelectActivity(id: string) {
    setSelectedActivity(activities.find(a => a.id === id));
    setMainPageWidth(10);
    setDetailPageWidth(6);
  }

  function handleCancelSelectActivity() {
    setSelectedActivity(undefined);

  }

  function handleOpenForm(id?: string) {
    id ? handleSelectActivity(id) : handleCancelSelectActivity();
    setEditMode(true);
    setMainPageWidth(10);
    setDetailPageWidth(6);
  }

  function handleCloseForm() {
    setEditMode(false);
    setMainPageWidth(16);
    setDetailPageWidth(undefined);

  }

  function handleCreateorEditActivity(activity: Activity) {
    setSubmitting(true);

    if (activity.id) {
      agent.Activities.update(activity).then(() => {
        setActivities([...activities.filter(a => a.id !== activity.id), activity])
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      })
    } else {
      activity.id = uuid();
      agent.Activities.create(activity).then(() => {
        setActivities([...activities, activity]);
        setSelectedActivity(activity);
        setEditMode(false);
        setSubmitting(false);
      })
    }
  }

  function handleDeleteActivity(id: string) {
    setSubmitting(true);
    agent.Activities.delete(id).then(() => {
      setActivities([...activities.filter(a => a.id !== id)])
      setSubmitting(false);
    })
  }

  if (loading) return <LoadingComponent content='Loading...Please wait...' />

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
          mainPageWidth={mainPageWidth}
          mainDetailWidth={mainDetailWidth}
          submitting={submitting}
        />
      </Container>
    </>
  );
}

export default App;
