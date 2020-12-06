import React from 'react';
import { Link } from 'react-router-dom';

function NavItem(props) {
  const LinkComponent = props.external
    ? (props) => (
        <a
          href={props.to}
          className={props.className}
          target='_blank'
          rel='noreferrer'
        >
          {props.children}
        </a>
      )
    : Link;

  return (
    <li className='nav-item'>
      <LinkComponent to={props.to}>{props.icon}</LinkComponent>
      <div className='iconblock'></div>
    </li>
  );
}

export default NavItem;
