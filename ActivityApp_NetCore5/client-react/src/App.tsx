import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5001/api/activities").then(response => {
      console.log(response.data);
      setActivities(response.data);
    });
  }, [])


  return (
    <div className="App">
      <Header as="h2" icon="users" content="Activities" />
      <List>
        {activities.map((activity: any) => (
          <List.Item key={activity.id}>
            {activity.title}
          </List.Item>
        ))}

      </List>

    </div>
  );
}

export default App;
