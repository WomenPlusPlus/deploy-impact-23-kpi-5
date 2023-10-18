import React, { useState } from "react";
import { supabase } from "./client.js";

const AuthenticationPage = () => {
  const [formData, setFormData] = useState({
    email: "",
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

  async function handleSubmit(e) {
    e.preventDefault();
    const { email } = formData; // Extract the email from formData

    if (email && email.toLowerCase().endsWith("gmail.com")) {
      try {
        const { data, error } = await supabase.auth.signInWithOtp({
          email,
          options: {
            emailRedirectTo: "https://dealmeida.dev/", // Specify the landing page
          },
        });

        if (error) {
          alert("Error: " + error.message);
        } else {
          alert("Check your email for the Login Link");
        }
      } catch (error) {
        alert("An unexpected error occurred: " + error.message);
      }
    } else {
      alert("Invalid email domain. Try again.");
    }
  }

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input placeholder="Email" name="email" onChange={handleChange} />
        <button type="submit">Login</button>
      </form>
    </div>
  );
};

export default AuthenticationPage;
