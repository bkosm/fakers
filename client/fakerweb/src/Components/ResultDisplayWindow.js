import React from "react";

export function ResultDisplayWindow(props) {
  return (
    <div className="windowOutput">
      <p>Text: {props.result}</p>
    </div>
  );
}
