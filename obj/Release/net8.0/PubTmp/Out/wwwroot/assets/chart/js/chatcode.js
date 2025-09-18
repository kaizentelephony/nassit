

var xValues = ["E-Success", "E-Failed", "V-Success", "V-Failed"];
var yValues = [entrollsuccess, entrollfailed, verifysuccess, verifyfailed];
var barColors = ["blue", "#ff00ff", "green","#00aba9"];

new Chart("myChart", {
    type: "bar",
    data: {
        labels: xValues,
        datasets: [{
            backgroundColor: barColors,
            data: yValues
        }]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: "#Bar Chart"
        },

        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                    
                }
            }],
        }
    }
});

