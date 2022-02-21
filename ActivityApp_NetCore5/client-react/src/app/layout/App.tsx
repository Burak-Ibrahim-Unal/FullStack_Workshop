import React, {  useEffect } from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';
import LoadingComponent from './LoadingComponents';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {
  const { activityStore } = useStore();

  useEffect(() => {
    activityStore.loadActivities();
  }, [])

  if (activityStore.loadingInitial) return <LoadingComponent content='Loading...Please wait...' />

  return (
    <>
      <Navbar />
      <Container style={{ marginTop: "7em" }} >
        <ActivityDashboard
        />
      </Container>
    </>
  );
}

export default observer(App);
