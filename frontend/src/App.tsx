import React from 'react';
import Button from './components/Button';
import TextBox from './components/TextBox';

const YourComponent: React.FC = () => {
  const handleSave = (value: string): void => {
    console.log('Input value saved:', value);
    // Here you can send the value to your backend or do whatever you need with it
  };

  const handleClick = () => {
    console.log('Button clicked');
  };

  return (
    <div>
      <h1>Your Component</h1>
      <Button text="Sign In" onClick={handleClick} />
      <TextBox onSave={handleSave} />
    </div>
  );
};

export default YourComponent;
