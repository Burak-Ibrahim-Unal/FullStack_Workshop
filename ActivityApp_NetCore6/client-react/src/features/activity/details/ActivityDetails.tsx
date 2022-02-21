import React from "react";
import { Card, Image, Button, SemanticWIDTHS } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';


interface Props {
    activity: Activity;
    cancelSelectActivity: () => void;
    openForm: (id: string) => void;
    closeForm: () => void;
    mainPageWidth: SemanticWIDTHS | undefined;
    mainDetailWidth: SemanticWIDTHS | undefined;

}

export default function ActivityDetails({ activity, cancelSelectActivity, openForm, closeForm, mainPageWidth, mainDetailWidth }: Props) {
    return (
        <Card fluid>
            <Image src={`assets/categoryImages/${activity.category}.jpg`} wrapped ui={false} />
            <Card.Content>
                <Card.Header>{activity.title}</Card.Header>
                <Card.Meta>
                    <span>{activity.date}</span>
                </Card.Meta>
                <Card.Description>
                    {activity.description}
                </Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths={2}>
                    <Button onClick={() => {
                        openForm(activity.id)
                        mainPageWidth = 10;
                        mainDetailWidth = 6;
                    }
                    }

                        basic color="blue" content="Edit" />

                    <Button 
                        onClick={
                        () => {
                            cancelSelectActivity();
                            closeForm();
                            mainPageWidth = 16;
                            mainDetailWidth = undefined;
                                }
                            }
                        
                        basic color="red" content="Cancel" />

                </Button.Group>
            </Card.Content>
        </Card>
    )
}

