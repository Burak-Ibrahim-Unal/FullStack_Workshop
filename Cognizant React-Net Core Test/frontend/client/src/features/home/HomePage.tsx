import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from 'semantic-ui-react';

export default function HomePage() {
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as="h1" inverted>
                    <Image size="massive" src="/assets/logo.png" alt="logo" style={{ marginBottom: 10 }} />
                    Activities
                </Header>
                <Header as="h2" inverted content="Wellcome to Cognizant" />
                <Button as={Link} to="/vehicles" size="huge" inverted>
                    Activities
                </Button>
            </Container>

        </Segment>
    )
}