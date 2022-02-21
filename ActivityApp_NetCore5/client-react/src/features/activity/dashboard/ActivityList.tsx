import React, { SyntheticEvent, useState } from "react";
import { Button, Item, Label, Segment, SemanticWIDTHS } from "semantic-ui-react";
import { Activity } from '../../../app/models/activity';


interface Props {
    activities: Activity[];
    selectActivity: (id: string) => void;
    deleteActivity: (id: string) => void;
    mainPageWidth: SemanticWIDTHS | undefined;
    mainDetailWidth: SemanticWIDTHS | undefined;
    submitting: boolean

}

export default function ActivityList({ activities, selectActivity, deleteActivity, mainPageWidth, mainDetailWidth, submitting }: Props) {
    const [target, setTarget] = useState("");

    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteActivity(id);
    }


    return (
        <Segment>
            <Item.Group divided>
                {activities.map(activity => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as="a">{activity.title}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Description>
                                <div>{activity.description}</div>
                                <div>{activity.city}</div>
                                <div>{activity.venue}</div>
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={() => {
                                    selectActivity(activity.id);
                                    mainDetailWidth = 6;
                                    mainPageWidth = 10;
                                }
                                }
                                    floated="right" content="Details" color="blue" />
                                <Button
                                    name={activity.id}
                                    loading={submitting && target === activity.id}
                                    onClick={(e) => handleActivityDelete(e, activity.id)}
                                    floated="right"
                                    content="Delete"
                                    color="red" />
                                <Label basic content={activity.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}