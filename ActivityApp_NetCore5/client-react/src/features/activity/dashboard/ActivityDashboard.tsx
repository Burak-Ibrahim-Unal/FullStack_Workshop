import React from "react";
import { Grid } from "semantic-ui-react";
import { Activity } from '../../../app/models/activity';
import ActivityDetails from "../details/ActivityDetails";
import ActivityForm from "../form/ActivityForm";
import ActivityList from "./ActivityList";


interface Props {
    activities: Activity[];
    selectedActivity: Activity | undefined;
    selectActivity: (id: string) => void;
    cancelSelectActivity: () => void;
    editMode: boolean;
    openForm: (id: string) => void;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
}


export default function ActivityDashboard({ activities, selectedActivity, selectActivity, cancelSelectActivity, editMode, openForm, closeForm, createOrEdit }: Props) {
    return (
        <Grid>
            <Grid.Column width={10}>
                <ActivityList activities={activities} selectActivity={selectActivity} />
            </Grid.Column>
            <Grid.Column width={6}>
                {
                    selectedActivity &&
                    <ActivityDetails
                        activity={selectedActivity}
                        cancelSelectActivity={cancelSelectActivity}
                        openForm={openForm}
                        closeForm={closeForm}
                    />
                }
                {editMode &&
                    <ActivityForm closeForm={closeForm} activity={selectedActivity} createOrEdit={createOrEdit} />}
            </Grid.Column>
        </Grid>
    )
}