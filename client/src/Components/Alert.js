import React from 'react';

const Alert = ({ title, message, isVisible, onClose }) => {
  return isVisible ? (
    <div className='overlay'>
      <div className='alert'>
        <h2 className='alert__title'>{title}</h2>
        <p className='alert__message'>{message}</p>
        <button className='alert__button' type='button' onClick={onClose}>
          OK
        </button>
      </div>
    </div>
  ) : null;
};

export default Alert;
