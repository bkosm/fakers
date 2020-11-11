import React, { useState } from 'react';
import NavBar from './NavBar';
import NavItem from './NavItem';
import Logo from '../Assets/logo512frs.png';
import GitHub from '../Assets/github512.png';
import DataBase from '../Assets/data512.png';
import InfoLogo from '../Assets/info512.png';
import HomeIcon from '../Assets/home512.png';

const NavBarContainer = () => {
  const [isNavBarOpen, setIsNavBarOpen] = useState(false);
  const [rotationClassName, setRotationClassName] = useState('');
  return (
    <>
      <button
        className={`Logo ${rotationClassName}`}
        onAnimationEnd={() => setRotationClassName('')}
        style={{ top: isNavBarOpen ? '85%' : 0 }}
        onClick={() => {
          setIsNavBarOpen(!isNavBarOpen);
          if (isNavBarOpen) {
            setRotationClassName('rotate');
          } else {
            setRotationClassName('rotate-delay');
          }
        }}
      >
        <img className='LogoImage' src={Logo} alt='logo' />
      </button>
      <NavBar
        style={{
          transitionDelay: isNavBarOpen ? '1s' : undefined,
          height: isNavBarOpen ? 300 : 0,
        }}
      >
        <NavItem
          icon={<img className='navitemicon' src={HomeIcon} alt='home-icon' />}
          to={'/'}
        />
        <NavItem
          icon={<img className='navitemicon' src={GitHub} alt='logo' />}
          external={true}
          to='https://github.com/bart-kosmala/fakers'
        />
        <NavItem
          icon={<img className='navitemicon' src={DataBase} alt='logo' />}
          to={'/Graph'}
        />
        <NavItem
          icon={<img className='navitemicon' src={InfoLogo} alt='logo' />}
          to={'/Info'}
        />
      </NavBar>
    </>
  );
};

export default NavBarContainer;
