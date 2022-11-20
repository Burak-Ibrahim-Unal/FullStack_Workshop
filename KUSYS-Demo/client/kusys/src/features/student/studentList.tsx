import { Button, List, ListItem, ListItemText, Typography } from "@mui/material";
import { Student } from "../../app/models/student";

interface Props{
    students: Student[];
    addStudent: () => void;
  }

export default function StudentList({students,addStudent} : Props) {
  return (
    <>
      <Typography variant="h2">Kusys</Typography>
      <List>
        {students.map((student: any, index: number) => (
          <ListItem key={index}>
            <ListItemText>
                {student.firstName} --- {student.lastName}
            </ListItemText>
          </ListItem>
        ))}
      </List>
      <Button variant="outlined" onClick={addStudent}>Kaydet</Button>

    </>
  );
}
