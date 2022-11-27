import {
  Avatar,
  Card,
  CardContent,
  CardHeader,
  CardMedia,
  Typography,
} from "@mui/material";
import { Student } from "../../app/models/student";
import type {} from "@mui/lab/themeAugmentation";
import { useAppDispatch } from "../../app/store/configureStore";

interface Props {
  student: Student;
}

export default function StudentCard({ student }: Props) {
  const dispatch = useAppDispatch();

  return (
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "secondary.main" }}>
            {student.firstname.charAt(0).toUpperCase()}
          </Avatar>
        }
        title={student.firstname}
        titleTypographyProps={{
          sx: { fontWeight: "bold", color: "primary.main" },
        }}
      />
      <CardMedia
        sx={{
          height: 150,
          backgroundSize: "contain",
          bgcolor: "primary.light",
        }}
        image="../../../public/image/student.jpg"
        title={student.firstname}
      />
      <CardContent>
        <Typography variant="body2" color="text.secondary">
          {student.firstname} -- {student.lastname}
        </Typography>
      </CardContent>
    </Card>
  );
}
