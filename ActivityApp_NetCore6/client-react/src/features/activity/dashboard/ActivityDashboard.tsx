import React from "react";
import { Grid, SemanticWIDTHS } from "semantic-ui-react";
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
    deleteActivity: (id: string) => void;
    mainPageWidth: SemanticWIDTHS | undefined;
    mainDetailWidth: SemanticWIDTHS | undefined;
    submitting: boolean;

}


export default function ActivityDashboard({ activities, selectedActivity, selectActivity, cancelSelectActivity, editMode, openForm, closeForm, createOrEdit, deleteActivity, mainPageWidth, mainDetailWidth, submitting }: Props) {
    return (
        <Grid>
            <Grid.Column width={mainPageWidth}>
                <ActivityList
                    activities={activities}
                    selectActivity={selectActivity}
                    deleteActivity={deleteActivity}
                    mainPageWidth={mainPageWidth}
                    mainDetailWidth={mainDetailWidth}
                    submitting={submitting}

                />
            </Grid.Column>
            <Grid.Column width={mainDetailWidth}>
                {
                    selectedActivity &&
                    <ActivityDetails
                        activity={selectedActivity}
                        cancelSelectActivity={cancelSelectActivity}
                        openForm={openForm}
                        closeForm={closeForm}
                        mainPageWidth={mainPageWidth}
                        mainDetailWidth={mainDetailWidth}
                    />
                }
                {editMode &&
                    <ActivityForm
                        closeForm={closeForm}
                        activity={selectedActivity}
                        createOrEdit={createOrEdit}
                        cancelSelectActivity={cancelSelectActivity}
                        mainPageWidth={mainPageWidth}
                        mainDetailWidth={mainDetailWidth}
                        submitting={submitting}


                    />}
            </Grid.Column>
        </Grid>
    )
}