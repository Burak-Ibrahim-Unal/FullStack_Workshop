import { Link } from "react-router-dom";
import { Button, Icon, Item, Segment } from 'semantic-ui-react';
import { Vehicle } from "../../../app/models/vehicle";

interface Props {
    vehicle: Vehicle
}


export default function VehicleListItem({ vehicle }: Props) {
    return (
        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item>
                        <Item.Image size="tiny" circular src="/assets/user.png" />
                        <Item.Content>
                            <Item.Header as={Link} to={`/vehicles/${vehicle.id}`}>
                                {`${vehicle.Make}  ${vehicle.Model}`}
                            </Item.Header>
                            <Item.Description>
                                Made by Burak
                            </Item.Description>
                        </Item.Content>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment>
                <span>
                    <Icon name="clock" /> {vehicle.DateAdded}
                    <Icon name="marker" /> {vehicle.YearModel}
                    <Icon name="truck" /> {vehicle.Licensed}

                </span>
            </Segment>
            <Segment clearing>
                <span>{vehicle.Price}</span>
                <Button
                    as={Link}
                    to={`vehicles/${vehicle.id}`}
                    color="teal"
                    floated="right"
                    content="Details"
                />
            </Segment>
        </Segment.Group>
    )
}