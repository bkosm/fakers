import React from "react";

function QueryInputWindow(props) {
  return (
    <div className="window">
      <textarea onChange={(e) => props.onChange(e.target.value)} />
    </div>
  );
}

export default QueryInputWindow;
