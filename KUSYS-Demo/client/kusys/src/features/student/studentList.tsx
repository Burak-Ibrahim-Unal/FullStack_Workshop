import { List } from "@mui/material";
import { Student } from "../../app/models/student";
import StudentCard from "./StudentCard";

interface Props {
  students: Student[];
}

export default function StudentList({students} : Props) {
  return (
    <List>
      {students.map((student: any, index: number) => (
        <StudentCard key={student.id} student={student} />
      ))}
    </List>
  );
}
