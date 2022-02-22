import React from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';
import { observer } from 'mobx-react-lite';
import { Route } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activity/form/ActivityForm';
import ActivityDetails from '../../features/activity/details/ActivityDetails';


function App() {

  return (
    <>
      <Navbar />
      <Container style={{ marginTop: "7em" }} >
        <Route exact path="/" component={HomePage} />
        <Route exact path="/activities" component={ActivityDashboard} />
        <Route path="/activities/:id" component={ActivityDetails} />
        <Route path="/createActivity" component={ActivityForm} />
      </Container>
    </>
  );
}

export default observer(App);
