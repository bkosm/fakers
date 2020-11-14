import React from "react";

function QueryInputWindow(props) {
  return (
    <div className="windowInput">
      <textarea value={props.name} />
    </div>
  );
}

export default QueryInputWindow;
