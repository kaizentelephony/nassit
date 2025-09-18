
var xValues = ["E-Success", "E-Failed", "V-Success", "V-Failed"];
var yValues = [entrollsuccess, entrollfailed, verifysuccess, verifyfailed];
var barColors = ["blue", "#ff00ff", "green", "#00aba9"];

new Chart("lineChart", {
    type: "line",
    data: {
        labels: xValues,
        datasets: [{
            borderColor: "red",
            backgroundColor: "skyblue",
            data: yValues
        }]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: "#Line Chart"
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

