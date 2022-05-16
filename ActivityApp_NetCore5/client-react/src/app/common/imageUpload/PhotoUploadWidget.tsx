import React, { useState } from "react";
import { Grid, Header, Image } from "semantic-ui-react";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";

export default function PhotoUploadWidget() {
    const [files, setFiles] = useState<any>([]);

    return (
        <Grid>
            <Grid.Column width={4}>
                <Header sub color="teal" content="Add Photo" />
                <PhotoWidgetDropzone setFiles={setFiles} />
            </Grid.Column>
            <Grid.Column width={1} />
            <Grid.Column width={4}>
                <Header sub color="teal" content="Resize" />
                {files && files.length > 0 && (
                    <Image src={files[0].preview} />
                )}
            </Grid.Column>
            <Grid.Column width={1} />
            <Grid.Column width={4}>
                <Header sub color="teal" content="Upload" />
            </Grid.Column>
        </Grid>
    )
}