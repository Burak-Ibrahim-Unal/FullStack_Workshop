import { ListItem, ListItemText } from "@mui/material";
import { Student } from "../../app/models/student";

interface Props {
  student: Student;
}

export default function StudentCard({ student }: Props) {
  return (
    <ListItem key={student.id}>
      <ListItemText>
        {student.firstName} --- {student.lastName}
      </ListItemText>
    </ListItem>
  );
}
