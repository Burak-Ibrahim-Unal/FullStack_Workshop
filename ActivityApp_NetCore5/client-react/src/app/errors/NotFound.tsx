import { Link } from "react-router-dom"
import { Button, Header, Icon, Segment } from "semantic-ui-react"

export default function NotFound(){
    return (
        <Segment>
            <Header>
                <Icon name="search" />
                Not Found Test...
            </Header>
            <Segment.Inline>
                <Button as={Link} to="/activities" primary>
                    Return to Activities
                </Button>
            </Segment.Inline>
        </Segment>
    )
}