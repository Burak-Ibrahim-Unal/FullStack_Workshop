import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { Student } from "../../app/models/student";

interface Props {
  student: Student;
}

export default function StudentCard({ student }: Props) {
  return (
    <Card>
    <CardMedia
      component="img"
      height="140"
      image="http://picsum.photos/201"
      alt="green iguana"
    />
    <CardContent>
      <Typography gutterBottom variant="h5" component="div">
        Lizard
      </Typography>
      <Typography variant="body2" color="text.secondary">
        Lizards are a widespread group of squamate reptiles, with over 6,000
        species, ranging across all continents except Antarctica
      </Typography>
    </CardContent>
    <CardActions>
      <Button size="small">Share</Button>
      <Button size="small">Learn More</Button>
    </CardActions>
  </Card>
  );
}
