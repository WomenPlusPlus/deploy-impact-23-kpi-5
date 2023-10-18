import Chart from 'chart.js/auto'

(async function() {
  const data = require("./bardata.json");;

  new Chart(
    document.getElementById("chart"),
    {
      type: 'bar',
      data: {
        labels: data.xs,
        datasets: [
          {
            data: data.vals
          }
        ]
      },
      options: {
        plugins: {
            title: {
                display: true,
                text: "Current growth rate of KPIs (%)",
            },
            legend: {
              display: false
          },
        }
    }
    }
  );
})();


 
