import Chart from 'chart.js/auto'

(async function() {
  const data = require("./linedata.json");;

  new Chart(
    document.getElementById('chart'),
    {
      type: 'line',
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
                text: data.name
            },
            legend: {
              display: false
          },
        }
    }
    }
  );
})();



 
