import { ErrorMessage, Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { Button, Header, Label } from "semantic-ui-react";
import CustomTextInput from "../../app/common/form/customTextInput";
import { useStore } from "../../app/stores/store";
import * as Yup from 'yup';



export default observer(function RegisterForm() {
    const { userStore } = useStore();
    return (
        <Formik
            initialValues={{ displayName: "", username: "", email: "", password: "", error: null }}
            onSubmit={(values, { setErrors }) => userStore.register(values)
                .catch(error => setErrors({ error: "Invalid email or password" }))
            }
            validationSchema={Yup.object({
                displayName: Yup.string().required(),
                username: Yup.string().required(),
                email: Yup.string().required().email(),
                password: Yup.string().required(),

            })}
        >
            {({ handleSubmit, isSubmitting, errors, isValid, dirty }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <Header as="h2" content="Sign up for Activities" color="teal" textAlign="center" />
                    <CustomTextInput name="displayName" placeholder="Display Name" />
                    <CustomTextInput name="username" placeholder="Username" />
                    <CustomTextInput name="email" placeholder="Email" />
                    <CustomTextInput name="password" placeholder="Password" type="password" />
                    <Button disabled={!isValid || !dirty || isSubmitting} loading={isSubmitting} positive content="Register" type="submit" fluid />                    <ErrorMessage
                        name="error" render={() => <Label style={{ marginBottom: 10, marginTop: 10 }} basic color="red" content={errors.error} />}
                    />

                </Form>

            )}
        </Formik>
    )
})