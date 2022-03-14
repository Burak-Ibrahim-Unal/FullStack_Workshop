import { observer } from "mobx-react-lite";
import React, { ChangeEvent, useEffect, useState } from "react";
import { Button, FormCustomTextInput, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { NavLink, useHistory, useParams } from 'react-router-dom';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { v4 as uuid } from 'uuid';
import { Formik, Form, ErrorMessage } from "formik";
import * as Yup from "yup";
import CustomTextInput from "../../../app/common/form/customTextInput";



export default observer(function ActivityForm() {
    const history = useHistory();
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loading, loadActivity, loadingInitial } = activityStore;
    const { id } = useParams<{ id: string }>();



    const [activity, setActivity] = useState({
        id: "",
        title: "",
        category: "",
        description: "",
        date: "",
        city: "",
        venue: ""
    });


    const validationSchema = Yup.object({
        title: Yup.string().required("Activity title can not be null"),
        description: Yup.string().required("Activity description can not be null"),
        category: Yup.string().required("Activity category can not be null"),
        date: Yup.string().required(),
        city: Yup.string().required("Activity city can not be null"),
        venue: Yup.string().required("Activity venue can not be null"),

    });


    // explanation mark means it can be undefined
    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(activity!))
    }, [id, loadActivity]);



    // function handleSubmit() {
    //     if (activity.id.length === 0) {
    //         let newActivity = {
    //             ...activity,
    //             id: uuid()
    //         };
    //         createActivity(newActivity).then(() => {
    //             history.push(`/activities/${newActivity.id}`);
    //         })
    //     }else {
    //         updateActivity(activity).then(()=> {
    //             history.push(`/activities/${activity.id}`);
    //         })
    //     }
    // }

    // function handleChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
    //     const { name, value } = event.target;
    //     setActivity({ ...activity, [name]: value })
    // }


    if (loadingInitial) return <LoadingComponent content="Loading activity.Please Wait..." />

    return (
        <Segment clearing>
            <Formik
                enableReinitialize
                initialValues={activity}
                onSubmit={values => console.log(values)}
                validationSchema={validationSchema}
            >
                {({ handleSubmit }) => (
                    <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                        <CustomTextInput name="title" placeholder="Title" />
                        <CustomTextInput placeholder="Description" name="description" />
                        <CustomTextInput placeholder="Category" name="category" />
                        <CustomTextInput placeholder="Date" name="date" />
                        <CustomTextInput placeholder="City" name="city" />
                        <CustomTextInput placeholder="Venue" name="venue" />
                        <Button floated="right" positive type="submit" content="Submit" loading={loading} />
                        <Button as={NavLink} to="/activities" floated="right" type="button" content="Cancel" />
                    </Form>
                )}
            </Formik>


        </Segment>
    )
})