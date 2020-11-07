import React, { useState } from 'react';

import QueryInputWindow from '../Components/QueryInputWindow';
import NavBar from '../Components/NavBar';
import NavItem from '../Components/NavItem';
import { ResultDisplayWindow } from '../Components/ResultDisplayWindow';
import Logo from '../Assets/logo512frs.png';

function Home() {
  const [text, setText] = useState('');
  const [isNavBarOpen, setIsNavBarOpen] = useState(false);
  const [isRequestInProgress, setIsRequestInProgress] = useState(false);
  return (
    <>
      <NavBar
        style={{
          opacity: isNavBarOpen ? 1 : 0,
          transition: isNavBarOpen ? 0 : '1s',
        }}
      >
        <NavItem
          icon={<img className='navitemicon' src={Logo} alt='logo' />}
          href='https://github.com/bart-kosmala/fakers'
        />
        <NavItem icon={<img className='navitemicon' src={Logo} alt='logo' />} />
        <NavItem icon={<img className='navitemicon' src={Logo} alt='logo' />} />
      </NavBar>
      <div className='row'>
        <div className='inputColumn'>
          <button
            className='Logo'
            style={{ top: isNavBarOpen ? '85%' : 0, transition: '1s' }}
            onClick={() => setIsNavBarOpen(!isNavBarOpen)}
          >
            <img className='LogoImage' src={Logo} alt='logo' />
          </button>

          <QueryInputWindow header={'jakis tytul'} onChange={setText} />
          <button
            className='inputButton'
            onClick={() => {
              setIsRequestInProgress(true);
              setTimeout(() => setIsRequestInProgress(false), 2000);
            }}
          >
            {isRequestInProgress ? 'Loading...' : 'Execute'}
          </button>
        </div>
        <ResultDisplayWindow result={text} />
      </div>
    </>
  );
}

export default Home;
