import { Form, Formik } from "formik";
import React from "react";
import { Button } from "semantic-ui-react";
import CustomTextInput from "../../app/common/form/customTextInput";

export default function LoginForm() {
    return (
        <Formik
            initialValues={{ email: "", password: "" }}
            onSubmit={values => console.log(values)}
        >
            {({ handleSubmit }) => (
                <Form className="ui form" onSubmit={handleSubmit} autoComplete="off">
                    <CustomTextInput name="email" placeholder="Email" />
                    <CustomTextInput name="password" placeholder="Password" type="password"/>
                    <Button positive content="Login" type="submit" fluid />
                </Form>

            )}
        </Formik>
    )
}