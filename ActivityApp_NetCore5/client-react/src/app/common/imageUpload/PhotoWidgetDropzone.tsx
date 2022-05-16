import React, { useCallback } from 'react'
import { useDropzone } from 'react-dropzone'
import { Header, Icon } from 'semantic-ui-react';

interface Props {
    setFiles: (files: any) => void;
}

export default function PhotoWidgetDropzone({ setFiles }: Props) {
    const dropZoneStyles = {
        border: "dashed 3px #eee",
        borderColor: "#eee",
        borderRadius: "5px",
        paddingTop: "30px",
        textAlign: "center" as "center",
        height: 200
    };

    const dropZoneActive = {
        borderColor: "green",
    };

    const onDrop = useCallback(acceptedFiles => {
        //console.log(acceptedFiles);
        setFiles(acceptedFiles.map((file: any) => Object.assign(file, {
            preview: URL.createObjectURL(file)
        })))
    }, [setFiles])

    const { getRootProps, getInputProps, isDragActive } = useDropzone({ onDrop })

    return (
        <div {...getRootProps()} style={isDragActive ? { ...dropZoneStyles, ...dropZoneActive } : dropZoneStyles}>
            <input {...getInputProps()} />
            <Icon name='upload' size='massive'/>
            <Header content="Drop Image Here"/>
        </div>
    )
}