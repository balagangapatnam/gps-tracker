import React from "react";

import { Container, Jumbotron, Media } from "react-bootstrap";

import UserLocationTable from "./components/UserLocationTable";

function App() {
  return (
    <div>
      <Container>
        <Jumbotron>
          <h1>GPS Tracking app!</h1>
          <p>A very basic app to track users' location.</p>
        </Jumbotron>

        <Media>
          <Media.Body>
            <h5>Last Known Location of All Users</h5>
          </Media.Body>
        </Media>

        <UserLocationTable />
      </Container>
    </div>
  );
}

export default App;
