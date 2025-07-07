const apiKey = '965387fdb856c7b4c44b9aae750bfbce'; // OpenWeatherMap API key

function getWeather() {
  const city = document.getElementById('cityInput').value;
  if (!city) {
    alert("Lütfen bir şehir adı girin!");
    return;
  }

  const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric&lang=tr`;

  fetch(url)
    .then(res => res.json())
    .then(data => {
      if (data.cod !== 200) {
        alert("Şehir bulunamadı!");
        return;
      }

      const temp = data.main.temp;
      const desc = data.weather[0].description;
      const icon = data.weather[0].icon;

      const weatherHTML = `
        <h2>${city}</h2>
        <img class="icon" src="https://openweathermap.org/img/wn/${icon}@2x.png" alt="icon">
        <p>${desc}</p>
        <p>Sıcaklık: ${temp}°C</p>
      `;

      document.getElementById("weatherBox").innerHTML = weatherHTML;

      // Arka planı güncelle
      updateBackground(desc.toLowerCase());
    })
    .catch(err => {
      console.error(err);
      alert("Bir hata oluştu!");
    });
}

function updateBackground(description) {
  const body = document.body;
  body.className = ''; // tüm arka planları temizle

  if (description.includes("güneşli") || description.includes("açık")) {
    body.classList.add("sunny");
  } else if (description.includes("bulut")) {
    body.classList.add("cloudy");
  } else if (description.includes("yağmur")) {
    body.classList.add("rainy");
  } else if (description.includes("fırtına")) {
    body.classList.add("stormy");
  } else if (description.includes("kar")) {
    body.classList.add("snowy");
  } else {
    body.classList.add("cloudy");
  }
}