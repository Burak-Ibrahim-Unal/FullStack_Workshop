import React, { ChangeEvent, useState } from "react";
import { Button, Form, Segment, SemanticWIDTHS } from "semantic-ui-react";
import { Activity } from '../../../app/models/activity';
import { useStore } from "../../../app/stores/store";

interface Props {
    createOrEdit: (activity: Activity) => void;
    submitting: boolean;

}


export default function ActivityForm({ createOrEdit, submitting }: Props) {
    const { activityStore } = useStore();
    const { selectedActivity, closeForm } = activityStore;


    const initialState = activityStore.selectedActivity ?? {
        id: "",
        title: "",
        category: "",
        description: "",
        date: "",
        city: "",
        venue: ""
    }

    const [activity, setActivity] = useState(initialState);

    function handleSubmit() {
        createOrEdit(activity);
    }

    function handleFormChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setActivity({ ...activity, [name]: value })
    }


    return (
        <Segment clearing>
            <Form onSubmit={handleSubmit} autoComplete="off">
                <Form.Input placeholder="Title" value={activity.title} name="title" onChange={handleFormChange} />
                <Form.TextArea placeholder="Description" value={activity.description} name="description" onChange={handleFormChange} />
                <Form.Input placeholder="Category" value={activity.category} name="category" onChange={handleFormChange} />
                <Form.Input type="date" placeholder="Date" value={activity.date} name="date" onChange={handleFormChange} />
                <Form.Input placeholder="City" value={activity.city} name="city" onChange={handleFormChange} />
                <Form.Input placeholder="Venue" value={activity.venue} name="venue" onChange={handleFormChange} />
                <Button floated="right" positive type="submit" content="Submit" loading={submitting} />
                <Button floated="right" type="button" content="Cancel" onClick={() => {
                    closeForm();
                }
                } />
            </Form>
        </Segment>
    )
}