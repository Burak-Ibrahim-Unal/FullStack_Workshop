import { observer } from "mobx-react-lite";
import react, { useEffect, useState } from "react";
import { Button, Header, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { NavLink, useHistory, useParams } from 'react-router-dom';
import LoadingComponent from "../../../app/layout/LoadingComponents";
import { v4 as uuid } from 'uuid';
import { Formik, Form } from "formik";
import * as Yup from "yup";
import CustomTextInput from "../../../app/common/form/customTextInput";
import CustomTextArea from '../../../app/common/form/customTextArea';
import CustomSelectedTextInput from '../../../app/common/form/customSelectedTextInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import CustomDateInput from '../../../app/common/form/customDateInput';
import { ActivityFormValues } from '../../../app/models/activity';



export default observer(function ActivityForm() {
    const history = useHistory();
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loadActivity, loadingInitial } = activityStore;
    const { id } = useParams<{ id: string }>();



    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());



    const validationSchema = Yup.object({
        title: Yup.string().required("Activity title can not be null"),
        description: Yup.string().required("Activity description can not be null"),
        category: Yup.string().required("Activity category can not be null"),
        date: Yup.string().required().nullable(),
        city: Yup.string().required("Activity city can not be null"),
        venue: Yup.string().required("Activity venue can not be null"),

    });


    // explanation mark means it can be undefined
    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity)))
    }, [id, loadActivity]);



    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = {
                ...activity,
                id: uuid()
            };
            createActivity(newActivity).then(() => {
                history.push(`/activities/${newActivity.id}`);
            })
        } else {
            updateActivity(activity).then(() => {
                history.push(`/activities/${activity.id}`);
            })
        }
    }


    if (loadingInitial) return <LoadingComponent content="Loading activity.Please Wait..." />

    return (
        <Segment clearing>
            <Header content="Activity Details" sub color="teal" />
            <Formik
                enableReinitialize
                initialValues={activity}
                onSubmit={values => console.log(values)}
                validationSchema={validationSchema}
            >
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                        <CustomTextInput name="title" placeholder="Title" />
                        <CustomTextArea rows={3} placeholder="Description" name="description" />
                        <CustomSelectedTextInput options={categoryOptions} placeholder="Category" name="category" />
                        <CustomDateInput
                            placeholderText="Date"
                            name="date"
                            showTimeSelect
                            timeCaption="time"
                            dateFormat="MMMM d,yyyy h:mm aa"

                        />
                        <Header content="Location Details" sub color="teal" />
                        <CustomTextInput placeholder="City" name="city" />
                        <CustomTextInput placeholder="Venue" name="venue" />
                        <Button
                            disabled={isSubmitting || !dirty || !isValid}
                            loading={isSubmitting}
                            floated="right"
                            positive type="submit"
                            content="Submit" />
                        <Button

                            as={NavLink} to="/activities"
                            floated="right"
                            type="button"
                            content="Cancel" />
                    </Form>
                )}
            </Formik>


        </Segment>
    )
})