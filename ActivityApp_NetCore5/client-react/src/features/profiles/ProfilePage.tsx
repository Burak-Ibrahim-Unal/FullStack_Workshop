import { observer } from "mobx-react-lite";
import React from "react";
import { useParams } from "react-router-dom";
import { Grid } from 'semantic-ui-react';
import ProfileContent from "./ProfileContent";
import ProfileHeader from './ProfileHeader';
import { useStore } from '../../app/stores/store';
import { useEffect } from 'react';
import LoadingComponent from '../../app/layout/LoadingComponents';

export default observer(function ProfilePage() {
    const { username } = useParams<{ username: string }>();
    const { profileStore } = useStore();
    const { loadProfile, loadingProfile, profile } = profileStore;


    useEffect(() => {
        loadProfile(username);

    }, [loadProfile, username])

    if (loadingProfile) return <LoadingComponent content="Profile is Loading... " />

    /* 2nd option <ProfileHeader profile={profile!} /> */
    return (
        <Grid>
            <Grid.Column width={16}>
                {profile &&
                    <>
                        <ProfileHeader profile={profile} />
                        <ProfileContent profile={profile} />
                    </>}

            </Grid.Column>
        </Grid>
    )
})