import Chart from 'chart.js/auto'

(async function() {
  const data = require("./multibardata.json");;

  new Chart(
    document.getElementById("chart"),
    {
      type: 'bar',
      data: {
        labels: data.xs,
        datasets: [
          // need to put this in a for loop (currently number of years is hard-coded)
            {
              label: data.years[0],
              data: data.vals[0],
            },
          {
            label: data.years[1],
            data: data.vals[1]
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
              display: true
          },
        }
    }
    }
  );
})();


 
