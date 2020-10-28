import React from "react";

export function ResultDisplayWindow(props) {
  return (
    <div className="window">
      <p>Text: {props.result}</p>
    </div>
  );
}
