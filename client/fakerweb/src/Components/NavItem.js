import React from "react";

function NavItem(props) {
  return (
    <li className="nav-item">
      <a href={props.href} className="icon-button">
        {props.icon}
      </a>
      <div className="iconblock"></div>
    </li>
  );
}

export default NavItem;
