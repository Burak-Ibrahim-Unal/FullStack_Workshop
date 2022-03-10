import { observer } from 'mobx-react-lite';
import React from 'react'
import { Button, Header, Item, Segment, Image } from 'semantic-ui-react'
import { Vehicle } from "../../../app/models/vehicle";

const vehicleImageStyle = {
    filter: 'brightness(30%)'
};

const vehicleImageTextStyle = {
    position: 'absolute',
    bottom: '5%',
    left: '5%',
    width: '100%',
    height: 'auto',
    color: 'white'
};

interface Props {
    vehicle: Vehicle
}

export default observer(function VehicleDetailHeader({ vehicle }: Props) {
    return (
        <Segment.Group>
            <Segment basic attached='top' style={{ padding: '0' }}>
                <Image src={`/assets/categoryImages/${vehicle.Make}.png`} fluid style={vehicleImageStyle} />
                <Segment style={vehicleImageTextStyle} basic>
                    <Item.Group>
                        <Item>
                            <Item.Content>
                                <Header
                                    size='huge'
                                    content={vehicle.Model}
                                    style={{ color: 'white' }}
                                />
                                <p>{vehicle.DateAdded}</p>
                                <p>
                                    Hosted by <strong>Burak</strong>
                                </p>
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Segment>
            </Segment>
            <Segment clearing attached='bottom'>
                <Button color='teal'>Join Vehicle</Button>
                <Button>Cancel attendance</Button>
                <Button color='orange' floated='right'>
                    Manage Event
                </Button>
            </Segment>
        </Segment.Group>
    )
})
