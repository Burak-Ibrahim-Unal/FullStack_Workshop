import React from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import "../layout/sytles.css";
import ActivityDashboard from '../../features/activity/dashboard/ActivityDashboard';
import { observer } from 'mobx-react-lite';
import { Route, Switch, useLocation } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import ActivityForm from '../../features/activity/form/ActivityForm';
import ActivityDetails from '../../features/activity/details/ActivityDetails';
import TestErrors from '../errors/TestErrors';
import { ToastContainer } from 'react-toastify';
import NotFound from '../errors/NotFound';


function App() {
  const location = useLocation();

  return (
    <>
      <ToastContainer position='bottom-center' hideProgressBar />
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <Navbar />
            <Container style={{ marginTop: "7em" }} >
              <Switch>
                <Route exact path="/activities" component={ActivityDashboard} />
                <Route path="/activities/:id" component={ActivityDetails} />
                <Route key={location.key} path={["/createActivity", "/manage/:id"]} component={ActivityForm} />
                <Route path="/errors" component={TestErrors} />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </>
        )}
      />


    </>
  );
}

export default observer(App);
