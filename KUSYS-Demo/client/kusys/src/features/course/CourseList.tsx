import { List } from "@mui/material";
import { Course } from "../../app/models/course";
import CourseCard from "./CourseCard";

interface Props {
  courses: Course[];
}

export default function CourseList({ courses }: Props) {
  <List>
    {courses.map((course, index) => (
      <CourseCard key={course.id} course={course} />
    ))}
  </List>;
}
