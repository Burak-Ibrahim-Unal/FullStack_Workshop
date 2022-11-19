const students = [
  {name: "student1",birthday: "2000-11-15"},
  {name: "student2",birthday: "2000-1-5"},
]

function App() {
  return (
    <div >
      <h1 style={{border:'1px red solid'}}>Kusys</h1>
      <ul>
        {students.map(s => (
          <li key={s.name}>{s.name} --- {s.birthday} </li> 
        ))}
      </ul>
    </div>
  );
}

export default App;

