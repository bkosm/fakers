import React from "react";

function NavBar(props) {
  return (
    <nav className="navbar" style={props.style}>
      <ul className="navbar-nav">{props.children}</ul>
    </nav>
  );
}

export default NavBar;
