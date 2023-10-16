import React, { useState } from "react";

const Authentication = () => {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
  });

  console.log(formData);

  function handleChange(event) {
    setFormData((prevFormData) => {
      return {
        ...prevFormData,
        [event.target.name]: event.target.value,
      };
    });
  }
  return (
    <div>
      <form>
        <input placeholder="Email" name="email" onChange={handleChange} />
        <input placeholder="Password" name="password" onChange={handleChange} />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default Authentication;
