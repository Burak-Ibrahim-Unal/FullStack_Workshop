import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Header, Label } from "semantic-ui-react";
import CustomTextInput from "../../app/common/form/customTextInput";
import ValidationErrors from "../../app/errors/ValidationErrors";
import { useStore } from "../../app/stores/store";

export default observer(function LoginForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ email: "", password: "", error: null }}
            onSubmit={(values, { setErrors }) => userStore.login(values)
            .catch(error => setErrors({ error }))
        }
        >
            {({ handleSubmit, isSubmitting, errors }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <Header as="h2" content="Login for Activities" color="teal" textAlign="center" />
                    <CustomTextInput name="email" placeholder="Email" />
                    <CustomTextInput name="password" placeholder="Password" type="password" />
                    <Button loading={isSubmitting} positive content="Login" type="submit" fluid />
                    <ErrorMessage
                        name="error" render={() => 
                            <ValidationErrors errors={errors.error} />}
                    />
                </Form>

            )}
        </Formik>
    )
})