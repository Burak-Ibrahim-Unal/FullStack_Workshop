import { Button } from "@mui/material";
import { CourseMatch } from "../../app/models/courseMatch";
import CourseMatchList from "./CourseMatchList";

interface Props {
  courseMatches: CourseMatch[];
  addCourseMatch: () => void;
}

export default function CourseMatchCatalog({ courseMatches,addCourseMatch }: Props) {
  return (
    <div>
      <CourseMatchList courseMatches={courseMatches} />
      <Button variant="text" onClick={addCourseMatch}>
        Kaydet
      </Button>
    </div>
  );
}
