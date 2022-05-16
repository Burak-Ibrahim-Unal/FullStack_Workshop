import React, { useState } from "react";
import { Grid, Header, Image } from "semantic-ui-react";
import PhotoWidgetDropzone from "./PhotoWidgetDropzone";
import { useEffect } from 'react';
import PhotoWidgetCropper from "./PhotoWidgetCropper";
import { Cropper } from "react-cropper";
import "cropperjs/dist/cropper.css";


export default function PhotoUploadWidget() {
    const [files, setFiles] = useState<any>([]);
    const [cropper, setCropper] = useState<Cropper>();

    function onCrop() {
        if (cropper) {
            cropper.getCroppedCanvas().toBlob(blob => console.log(blob));
        }
    }

    useEffect(() => {
        return () => {
            files.foreach((file: any) => URL.revokeObjectURL(file.preview))
        }
    }, [files])

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
                    // <Image src={files[0].preview} />
                    <PhotoWidgetCropper setCropper={setCropper} imagePreview={files[0].preview} />
                )}
            </Grid.Column>
            <Grid.Column width={1} />
            <Grid.Column width={4}>
                <Header sub color="teal" content="Upload" />
                <div className="img-preview" style={{ minHeight: 200, overflow: "hidden" }}>

                </div>
            </Grid.Column>
        </Grid >
    )
}