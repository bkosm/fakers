import React, { useState } from 'react';

function QueryInputWindow({ value, onSubmit }) {
  const [input, setInput] = useState(value);
  const handleSubmit = () => onSubmit(input);

  return (
    <div className='windowInput'>
      <input
        className='connectButton'
        type='submit'
        value='Connect'
        onClick={handleSubmit}
      />
      <textarea
        placeholder='GraphQL API server address'
        value={input}
        onChange={(e) => setInput(e.target.value)}
      />
    </div>
  );
}

export default QueryInputWindow;
