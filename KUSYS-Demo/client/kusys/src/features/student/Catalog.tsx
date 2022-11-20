import { Button, Typography } from "@mui/material";
import { Student } from "../../app/models/student";
import StudentList from "./StudentList";

interface Props{
    students: Student[];
    addStudent: () => void;
  }

export default function Catalog({students,addStudent} : Props) {
  return (
    <>
      <Typography variant="h2">Kusys</Typography>
      <StudentList students={students}/>
      <Button variant="outlined" onClick={addStudent}>Kaydet</Button>

    </>
  );
}
