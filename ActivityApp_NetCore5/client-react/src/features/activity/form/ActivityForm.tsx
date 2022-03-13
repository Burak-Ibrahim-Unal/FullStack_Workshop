import { observer } from "mobx-react-lite";
import React, { ChangeEvent, useEffect, useState } from "react";
import { Button, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { NavLink, useHistory, useParams } from 'react-router-dom';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { v4 as uuid } from 'uuid';
import { Formik, Form, Field } from "formik";



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
            <Formik enableReinitialize initialValues={activity} onSubmit={values => console.log(values)}>
                {({ handleSubmit }) => (
                    <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                        <Field placeholder="Title" name="title"  />
                        <Field placeholder="Description" name="description"  />
                        <Field placeholder="Category" name="category"  />
                        <Field type="date" placeholder="Date"name="date"  />
                        <Field placeholder="City" name="city"  />
                        <Field placeholder="Venue" name="venue"  />
                        <Button floated="right" positive type="submit" content="Submit" loading={loading} />
                        <Button as={NavLink} to="/activities" floated="right" type="button" content="Cancel" />
                    </Form>
                )}
            </Formik>


        </Segment>
    )
})