import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { Button } from "semantic-ui-react";
import CustomTextInput from "../../app/common/form/customTextInput";
import { useStore } from "../../app/stores/store";

export default observer(function LoginForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ email: "", password: "" }}
            onSubmit={values => userStore.login(values)}
        >
            {({ handleSubmit, isSubmitting }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <CustomTextInput name="email" placeholder="Email" />
                    <CustomTextInput name="password" placeholder="Password" type="password" />
                    <Button loading={isSubmitting} positive content="Login" type="submit" fluid />
                </Form>

            )}
        </Formik>
    )
})