import "./economist-dashboard.css";

export default function EconomistLandingPage() {
  return (
    <div className="page-container">
      <div className="sidebar">
        <ul>
          <li>My KPI</li>
          <li>Dashboard</li>
          <li>Reports</li>
        </ul>
      </div>
      <div className="kpi-form">
        <h1>Fill KPI Form</h1>
        <form>
          <label htmlFor="name">Name</label>{" "}
          <input type="text" id="name" name="name" placeholder="Name"></input>
          <label htmlFor="category">Category</label>
          <input
            type="text"
            id="category"
            name="category"
            placeholder="Category"
          ></input>
          <label htmlFor="targetValue">Target Value</label>
          <input
            type="text"
            id="targetValue"
            name="targetValue"
            placeholder="Target Value"
          ></input>
          <label htmlFor="date">Date</label>
          <input type="date" id="date" name="date" />
        </form>
      </div>
    </div>
  );
}
