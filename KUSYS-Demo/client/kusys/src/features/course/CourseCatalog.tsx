import { Button } from "@mui/material";
import { Course } from "../../app/models/course";
import CourseList from "./CourseList";

interface Props {
  courses: Course[];
  addCourse: () => void;
}

export default function CourseCatalog({ courses,addCourse }: Props) {
  return (
    <div>
      <CourseList courses={courses} />;
      <Button variant="contained" onClick={addCourse}></Button>
    </div>
  );
}
