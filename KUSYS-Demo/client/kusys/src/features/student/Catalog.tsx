import { useEffect, useState } from "react";
import { Student } from "../../app/models/student";
import StudentList from "./StudentList";

export default function Catalog() {
  const [students, setStudents] = useState<Student[]>([]);

  useEffect(() => {
    fetch("http://localhost:5096/api/Students")
      .then((response) => response.json())
      .then((data) => setStudents(data));

    return () => {};
  }, []);

  return (
    <>
      <StudentList students={students}/>
    </>
  );
}
