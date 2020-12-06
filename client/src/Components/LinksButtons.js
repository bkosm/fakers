import React from "react";
import { Link } from "react-router-dom";

function LinksButtons(props) {
  return (
    <div className="linksButtons">
      <a
        className="githubButton"
        href="https://github.com/bart-kosmala/fakers"
        target="_blank"
        rel="noreferrer"
      >
        GitHub
      </a>
      <Link to="/Info" className="infoButton"></Link>
      <Link to="/Graph" className="graphButton"></Link>
    </div>
  );
}

export default LinksButtons;
