import { ListItem, ListItemText } from "@mui/material";
import { CourseMatch } from "../../app/models/courseMatch";

interface Props {
  courseMatch: CourseMatch;
}

export default function CourseMatchCard({ courseMatch }: Props) {
  return (
    <ListItem>
      <ListItemText>
        {courseMatch.studentId} -- {courseMatch.courseId}
      </ListItemText>
    </ListItem>
  );
}
