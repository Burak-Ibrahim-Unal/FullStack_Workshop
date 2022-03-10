import React from 'react';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import "../layout/styles.css";
import VehicleDashboard from '../../features/vehicle/dashboard/VehicleDashboard';
import { observer } from 'mobx-react-lite';
import { Route, useLocation } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import VehicleForm from '../../features/vehicle/form/VehicleForm';
import VehicleDetails from '../../features/vehicle/details/VehicleDetails';


function App() {
  const location = useLocation();

  return (
    <>
      <Route exact path="/" component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <>
            <Navbar />
            <Container style={{ marginTop: "7em" }} >
              <Route exact path="/vehicles" component={VehicleDashboard} />
              <Route path="/vehicles/:id" component={VehicleDetails} />
              <Route key={location.key} path={["/createVehicle", "/manage/:id"]} component={VehicleForm} />
            </Container>
          </>
        )}
      />


    </>
  );
}

export default observer(App);
