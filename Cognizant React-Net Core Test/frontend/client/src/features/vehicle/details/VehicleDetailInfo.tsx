import { observer } from 'mobx-react-lite';
import React from 'react'
import {Segment, Grid, Icon} from 'semantic-ui-react'
import {Vehicle} from "../../../app/models/vehicle";

interface Props {
    vehicle: Vehicle
}

export default observer(function VehicleDetailInfo({vehicle}: Props) {
    return (
        <Segment.Group>
            <Segment attached='top'>
                <Grid>
                    <Grid.Column width={1}>
                        <Icon size='large' color='teal' name='info'/>
                    </Grid.Column>
                    <Grid.Column width={15}>
                        <p>{`${vehicle.Model} ${vehicle.Make}`}</p>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='calendar' size='large' color='teal'/>
                    </Grid.Column>
                    <Grid.Column width={15}>
            <span>
              {vehicle.DateAdded}
            </span>
                    </Grid.Column>
                </Grid>
            </Segment>
            <Segment attached>
                <Grid verticalAlign='middle'>
                    <Grid.Column width={1}>
                        <Icon name='marker' size='large' color='teal'/>
                    </Grid.Column>
                    <Grid.Column width={11}>
                        <span>{vehicle.Price}, {vehicle.YearModel}</span>
                    </Grid.Column>
                </Grid>
            </Segment>
        </Segment.Group>
    )
})