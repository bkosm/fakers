import React from "react";

function QueryInputWindow(props) {
  return (
    <div className="windowInput">
      <input className="connectButton" type="submit" value="Connect" />
      <textarea placeholder="GraphQL API server address" value={props.name} />
    </div>
  );
}

export default QueryInputWindow;
