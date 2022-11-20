import { Grid, List } from "@mui/material";
import { Student } from "../../app/models/student";
import StudentCard from "./StudentCard";

interface Props {
  students: Student[];
}

export default function StudentList({ students }: Props) {
  return (
    <Grid container spacing={3}>
      {students.map((student: any, index: number) => (
        <Grid item xs={3}>
          <StudentCard key={student.id} student={student} />
        </Grid>
      ))}
    </Grid>
  );
}
