import { useEffect, useState } from "react";

const studentList = [
  {name: "student1",birthday: "2000-11-15"},
  {name: "student2",birthday: "2000-1-5"},
]

function App() {
  const [students, setStudents] = useState(studentList);

  function addStudent() {
    setStudents((prevState) => [
      ...prevState,
      { name: "student" + (prevState.length + 1), birthday: "2001-01-01" },
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
          <li key={index}>{s.name} --- {s.birthday} </li> 
        ))}
      </ul>
      <button onClick={addStudent}>Kaydet</button>
    </div>
  );
}

export default App;

