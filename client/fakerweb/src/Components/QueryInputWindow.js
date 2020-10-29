import React from "react";

function QueryInputWindow(props) {
  return (
    <div className="windowInput">
      <textarea onChange={(e) => props.onChange(e.target.value)} />
    </div>
  );
}

export default QueryInputWindow;
