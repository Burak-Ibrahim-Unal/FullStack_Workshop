import { Student } from "../../app/models/student";

interface Props{
    students:Student[];
    addStudent: () => void;
  }

export default function StudentList({students,addStudent} : Props) {
  return (
    <>
      <h1 style={{ border: "1px red solid" }}>Kusys</h1>
      <ul>
        {students.map((student: any, index: number) => (
          <li key={index}>
            {student.firstName} --- {student.lastName} --- {student.birthDate}{" "}
          </li>
        ))}
      </ul>
      <button onClick={addStudent}>Kaydet</button>
    </>
  );
}
