import { useEffect, useState } from "react";
import { Student } from "./app/models/student";

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
      <h1 style={{border:'1px red solid'}}>Kusys</h1>
      <ul>
        {students.map((s,index) => (
          <li key={index}>{s.firstName} --- {s.lastName} --- {s.birthDate} </li> 
        ))}
      </ul>
      <button onClick={addStudent}>Kaydet</button>
    </div>
  );
}

export default App;

