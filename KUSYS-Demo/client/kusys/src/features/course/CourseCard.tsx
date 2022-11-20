import { ListItem, ListItemText } from "@mui/material";
import { Course } from "../../app/models/course";

interface Props {
  course: Course;
}

export default function CourseCard({ course }: Props) {
  return (
    <ListItem key={course.id}>
      <ListItemText>
        {course.courseId} -- {course.courseName}
      </ListItemText>
    </ListItem>
  );
}
