import React from "react";
import { Message } from "semantic-ui-react";

interface Props {
    errors: any;

}


export default function ValidationErrors({ errors }: Props) {
    return (
        <Message error>
            {errors && (
                <Message.List>
                    {errors.map((e: any, i: any) => (
                        <Message.Item key={i}>{e}</Message.Item>
                    ))}
                </Message.List>
            )}
        </Message>
    )
}