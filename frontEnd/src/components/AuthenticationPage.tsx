// eslint-disable-next-line no-unused-vars

import React, { useState } from "react";
import { supabase } from "./client.js";
import "./styles-authentication.css";
import IMAGES from "../assets/IMAGES";

const AuthenticationPage = () => {
  const [formData, setFormData] = useState({
    email: "",
  });

  console.log(formData);

  function handleChange(event: React.ChangeEvent<HTMLInputElement>) {
    setFormData((prevFormData) => {
      return {
        ...prevFormData,
        [event.target.name]: event.target.value,
      };
    });
  }

  async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const { email } = formData; // Extract the email from formData

    if (email && email.toLowerCase().endsWith("gmail.com")) {
      try {
        const { error } = await supabase.auth.signInWithOtp({
          email,
          options: {
            emailRedirectTo: "https://dealmeida.dev/", // Specify the landing page
          },
        });

        if (error) {
          alert("Error: " + (error as Error).message);
        } else {
          alert("Check your email for the Login Link");
        }
      } catch (error) {
        alert("An unexpected error occurred: " + (error as Error).message);
      }
    } else {
      alert("Invalid email domain. Try again.");
    }
  }

  return (
    <div className="page-container">
      <div className="left-container">
        <div className="form-container">
          <h1>Log in</h1>
          <form onSubmit={handleSubmit}>
            <span>Email</span>
            <input
              placeholder="Enter your email"
              name="email"
              onChange={handleChange}
            />
            <button type="submit" className="login-button">
              Log In
            </button>
          </form>
        </div>
      </div>
      <div className="right-container">
        <img
          src={IMAGES.authenticationImage}
          alt="Graphs"
          className="authenticationImage"
        />
      </div>
    </div>
  );
};
export default AuthenticationPage;
