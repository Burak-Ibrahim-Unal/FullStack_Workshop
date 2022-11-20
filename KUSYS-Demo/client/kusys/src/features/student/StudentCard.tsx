import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Student } from "../../app/models/student";

interface Props {
  student: Student;
}

export default function StudentCard({ student }: Props) {
  return (
    <Card>
      <CardHeader 
        avatar={
          <Avatar sx={{ bgcolor: "secondary.main" }}>
            {student.firstName.charAt(0).toUpperCase()}
          </Avatar>
        }
        title={student.lastName}
        titleTypographyProps={{
          sx: { fontWeight: "bold", color: "primary.main" },
        }}
      />
    <CardMedia
      sx={{height: 150,backgroundSize:"contain"}}
      image="http://picsum.photos/201"
      title={student.firstName}
    />
    <CardContent>
      <Typography gutterBottom color='secondary' variant="h5">
        {student.birthDate}
      </Typography>
      <Typography variant="body2" color="text.secondary">
        {student.firstName} -- {student.lastName}
      </Typography>
    </CardContent>
    <CardActions>
      <Button size="small">Add to Card</Button>
      <Button size="small">View</Button>
    </CardActions>
  </Card>
  );
}
