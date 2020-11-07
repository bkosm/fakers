import React, { useState } from 'react';

import NavBar from '../Components/NavBar';
import NavItem from '../Components/NavItem';
import Logo from '../Assets/logo512frs.png';
import GraphiQL from 'graphiql';
import 'graphiql/graphiql.min.css';

function Home() {
  const [isNavBarOpen, setIsNavBarOpen] = useState(false);
  return (
    <>
      <button
        className='Logo'
        style={{ top: isNavBarOpen ? '85%' : 0, transition: '1s' }}
        onClick={() => setIsNavBarOpen(!isNavBarOpen)}
      >
        <img className='LogoImage' src={Logo} alt='logo' />
      </button>
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
      <GraphiQL
        fetcher={async (graphQLParams) => {
          const data = await fetch(
            'https://swapi-graphql.netlify.app/.netlify/functions/index',
            {
              method: 'POST',
              headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
              },
              body: JSON.stringify(graphQLParams),
              credentials: 'same-origin',
            }
          );
          return data.json().catch(() => data.text());
        }}
      />
    </>
  );
}

export default Home;
