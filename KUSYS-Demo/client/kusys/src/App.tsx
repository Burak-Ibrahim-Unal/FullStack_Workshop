import { useEffect, useState } from "react";

const studentList = [
  {firstName: "student1f",lastName: "student1l",birthDate: "2000-11-15"},
  {firstName: "student2f",lastName: "student2l",birthDate: "2000-1-5"},
]

function App() {
  const [students, setStudents] = useState(studentList);

  function addStudent() {
    setStudents((prevState) => [
      ...prevState,
      { firstName: "student" + (prevState.length + 1),
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

