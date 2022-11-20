import { useEffect, useState } from "react";
import StudentList from "../../features/student/studentList";
import { Student } from "../models/student";


function App() {
  const [students, setStudents] = useState<Student[]>([]);

  function addStudent() {
    setStudents((prevState) => [
      ...prevState,
      { id:prevState.length + 10,
      firstName: "student" + (prevState.length + 1),
      lastName: "student" + (prevState.length + 1),
      birthDate: "2001-01-01" },
      
    ]);
  }

  useEffect(() => {
    fetch("http://localhost:5096/api/Students")
      .then((response) => response.json())
      .then((data) => setStudents(data))

    return () => {};
  }, []);

  return (
    <div >
      <StudentList students={students} addStudent={addStudent}/>
    </div>
  );
}

export default App;

