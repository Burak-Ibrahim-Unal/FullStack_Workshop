import { List } from "@mui/material";
import { CourseMatch } from "../../app/models/courseMatch";
import CourseMatchCard from "./CourseMatchCard";

interface Props {
  courseMatches: CourseMatch[];
}

export default function CourseMatchList({ courseMatches }: Props) {
  return (
    <List>
      {courseMatches.map((courseMatch, index) => (
        <CourseMatchCard courseMatch={courseMatch} />
      ))}
    </List>
  );
}
