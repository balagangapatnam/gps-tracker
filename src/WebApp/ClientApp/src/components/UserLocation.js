import React from "react";

const UserLocation = ({ user }) => {
  return (
    <tr>
      <td>{user.id}</td>
      <td>{user.name}</td>
      <td>{user.lastKnownLocation.latitude}</td>
      <td>{user.lastKnownLocation.longitude}</td>
    </tr>
  );
};

export default UserLocation;
