import React, { useState, useEffect } from "react";

import axios from "axios";

import Table from "react-bootstrap/Table";

import UserLocation from "./UserLocation";

const UserLocationTable = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    axios.get("users/location").then((result) => setUsers(result.data));
  }, []);

  return (
    <Table striped bordered hover variant="dark" responsive>
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Latitude</th>
          <th>Longitude</th>
        </tr>
      </thead>
      <tbody>
        {users.map((user) => (
          <UserLocation key={user.id} user={user} />
        ))}
      </tbody>
    </Table>
  );
};

export default UserLocationTable;
