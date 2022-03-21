import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Header, Label } from "semantic-ui-react";
import CustomTextInput from "../../app/common/form/customTextInput";
import { useStore } from "../../app/stores/store";

export default observer(function LoginForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ email: "", password: "", error: null }}
            onSubmit={(values, { setErrors }) => userStore.login(values)
                .catch(error => setErrors({ error: "Invalid email or password" }))
            }
        >
            {({ handleSubmit, isSubmitting, errors }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <Header as="h2" content="Login for Activities" color="teal" textAlign="center" />
                    <CustomTextInput name="email" placeholder="Email" />
                    <CustomTextInput name="password" placeholder="Password" type="password" />
                    <Button loading={isSubmitting} positive content="Login" type="submit" fluid />
                    <ErrorMessage
                        name="error" render={() => <Label style={{ marginBottom: 10, marginTop: 10 }} basic color="red" content={errors.error} />}
                    />
                </Form>

            )}
        </Formik>
    )
})