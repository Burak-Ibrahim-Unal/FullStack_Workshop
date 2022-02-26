import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { NavLink, useParams } from "react-router-dom";
import { Card, Button, Grid } from 'semantic-ui-react';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { useStore } from "../../../app/stores/store";
import ActivityDetailChat from "./ActivityDetailChat";
import ActivityDetailHeader from "./ActivityDetailHeader";
import ActivityDetailInfo from "./ActivityDetailInfo";
import ActivityDetailSidebar from "./ActivityDetailSidebar";



export default observer(function ActivityDetails() {
    const { activityStore } = useStore();
    const { selectedActivity: activity, loadActivity, loadingInitial } = activityStore;
    const { id } = useParams<{ id: string }>();

    useEffect(() => {
        if (id) loadActivity(id);
    }, [id, loadActivity]);

    if (loadingInitial || !activity) return <LoadingComponent />;


    return (
       <Grid>
            <Grid.Column width={12}>
                <ActivityDetailHeader activity={activity}/>
                <ActivityDetailInfo activity={activity}/>
                <ActivityDetailChat />
            </Grid.Column>

            <Grid.Column width={4}>
                <ActivityDetailSidebar />
            </Grid.Column>
       </Grid>
    )
})

