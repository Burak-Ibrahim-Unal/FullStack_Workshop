import { Grid } from "@mui/material";
import { Student } from "../../app/models/student";
import { useAppSelector } from "../../app/store/configureStore";
import StudentCard from "./StudentCard";
import StudentCardSkeleton from "./StudentCardSkeleton";

interface Props {
  students: Student[];
}
export default function StudentList({ students }: Props) {
  const { studentsLoaded } = useAppSelector((state) => state.catalog);
  return (
    <Grid container spacing={4}>
      {students.map((student, index) => (
        <Grid item xs={4} key={student.id} sx={{ mt: -3, mb: 2 }}>
          {!studentsLoaded ? (
            <StudentCardSkeleton />
          ) : (
            <StudentCard student={student} />
          )}
        </Grid>
      ))}
    </Grid>
  );
}
