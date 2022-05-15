import React from "react";
import { Grid, Header } from "semantic-ui-react";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";

export default function PhotoUploadWidget(){
    return(
        <Grid>
            <Grid.Column width={4}>
                <Header sub color="teal" content="Add Photo"/>
                <PhotoWidgetDropzone />
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                <Header sub color="teal" content="Resize"/>
            </Grid.Column>
            <Grid.Column width={1}/>
            <Grid.Column width={4}>
                <Header sub color="teal" content="Upload"/>
            </Grid.Column>
        </Grid>
    )
}