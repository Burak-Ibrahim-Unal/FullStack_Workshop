import React from "react";
import { Button, Divider, Grid, Header, Item, Reveal, Segment, Statistic } from "semantic-ui-react";


export default function ProfileHeader() {
    return (
        <Segment>
            <Grid>
                <Grid.Column width={12}>
                    <Item.Group>
                        <Item>
                            <Item.Image avatar size="small" src={"/assets/user.png"} />
                            <Item.Content verticalAlign="middle">
                                <Header as="h1" content="DisplayName" />
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Grid.Column>
                <Grid.Column width={4}>
                    <Statistic.Group widths={2}>
                        <Statistic label="Follow us" value="5" />
                        <Statistic label="Following" value="40" />
                        <Divider />
                        <Reveal animated="move">
                            <Reveal.Content visible style={{ width: "300px" }}>
                                <Button className="headerButtons" fluid color="teal" content="Following" />
                            </Reveal.Content>
                            <Reveal.Content hidden style={{ width: "300px" }}>
                                <Button
                                    className="headerButtons"
                                    fluid
                                    basic
                                    color={true ? "red" : "blue"}
                                    content={true ? "Unfollow" : "Follow"} />
                            </Reveal.Content>
                        </Reveal>
                    </Statistic.Group>
                </Grid.Column>
            </Grid>
        </Segment>
    );
}