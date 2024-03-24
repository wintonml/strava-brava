import React, { useState } from 'react';

interface InputProps {
  onSave: (value: string) => void;
}

const TextBox: React.FC<InputProps> = ({ onSave }) => {
  const [inputValue, setInputValue] = useState<string>('');

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>): void => {
    setInputValue(event.target.value);
  };

  const handleInputKeyPress = (event: React.KeyboardEvent<HTMLInputElement>): void => {
    if (event.key === 'Enter') {
      saveInputValue();
    }
  };

  const saveInputValue = (): void => {
    onSave(inputValue);
    setInputValue('');
  };

  return (
    <div>
      <input
        type="text"
        value={inputValue}
        onChange={handleInputChange}
        onKeyDown={handleInputKeyPress}
        placeholder="Enter your text here..."
      />
      <button onClick={saveInputValue}>Save</button>
    </div>
  );
};

export default TextBox;
