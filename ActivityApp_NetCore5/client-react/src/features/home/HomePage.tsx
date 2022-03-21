import { observer } from "mobx-react-lite";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from 'semantic-ui-react';
import { useStore } from "../../app/stores/store";

export default observer(function HomePage() {
    const { userStore } = useStore();
    return (
        <Segment inverted textAlign="center" vertical className="masthead">
            <Container text>
                <Header as="h1" inverted>
                    <Image size="massive" src="/assets/logo.png" alt="logo" style={{ marginBottom: 10 }} />
                    Activities
                </Header>
                {userStore.isLoggedIn ? (
                    <>
                        <Header as="h2" inverted content="Wellcome to Activities" />
                        <Button as={Link} to="/activities" size="huge" inverted>
                            Activities
                        </Button>
                    </>
                ) : (
                    <Button as={Link} to="/login" size="huge" inverted>
                        Login
                    </Button>
                )}

            </Container>

        </Segment>
    )
})