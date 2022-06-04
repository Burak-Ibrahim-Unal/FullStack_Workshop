import { observer } from 'mobx-react-lite'
import React from 'react'
import { Segment, Header, Comment, Button, Loader } from 'semantic-ui-react'
import { useStore } from '../../../app/stores/store';
import { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { Formik, Form, Field, FieldProps } from 'formik';
import * as Yup from "yup";
import { formatDistanceToNow } from 'date-fns/esm';


interface Props {
    activityId: string;
}

export default observer(function ActivityDetailChat({ activityId }: Props) {
    const { commentStore } = useStore();

    useEffect(() => {
        if (activityId) {
            commentStore.createHubConnection(activityId);
        }
        return () => {
            commentStore.clearCooments();
        }
    }, [commentStore, activityId])

    return (
        <>
            <Segment
                textAlign='center'
                attached='top'
                inverted
                color='teal'
                style={{ border: 'none' }}
            >
                <Header>Messages about this event</Header>
            </Segment>
            <Segment attached clearing>
                <Formik
                    onSubmit={(values, { resetForm }) =>
                        commentStore.addComments(values).then(() => resetForm())}
                    initialValues={{ body: "" }}
                    validationSchema={Yup.object({
                        body: Yup.string().required()
                    })}
                >
                    {({ isSubmitting, isValid, handleSubmit }) => (
                        <Form className='ui form'>
                            <Field name="body">
                                {(props: FieldProps) => (
                                    <div style={{ position: "relative" }}>
                                        <Loader active={isSubmitting} />
                                        <textarea
                                            placeholder='Press to enter button to submit your comment or for new line press shift+enter '
                                            rows={3}
                                            {...props.field}
                                            onKeyPress={e => {
                                                if (e.key === "enter" && e.shiftKey) return;
                                                if (e.key === "Enter" && !e.shiftKey) {
                                                    e.preventDefault();
                                                    isValid && handleSubmit();
                                                }
                                            }}
                                        />
                                    </div>
                                )}

                            </Field>
                        </Form>
                    )}
                </Formik>
                <Comment.Group>
                    {commentStore.comments.map(comment => (
                        <Comment key={comment.id}>
                            <Comment.Avatar src={comment.image || '/assets/user.png'} />
                            <Comment.Content>
                                <Comment.Author as={Link} to={`/profile/${comment.username}`}>{comment.displayName}</Comment.Author>
                                <Comment.Metadata>
                                    <div>{formatDistanceToNow(comment.createdAt)} ago</div>
                                </Comment.Metadata>
                                <Comment.Text>{comment.body}</Comment.Text>
                            </Comment.Content>
                        </Comment>
                    ))}


                </Comment.Group>
            </Segment>
        </>

    )
})