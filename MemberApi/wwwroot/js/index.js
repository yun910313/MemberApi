//const token = localStorage.getItem("token");
//console.log(token);
//const payload = token.split('.')[1];
//console.log(payload);
//const decodedPayload = JSON.parse(atob(payload));

//console.log(decodedPayload);
//document.getElementById("user-name").innerText = decodedPayload.name + "， 歡迎回來!";

const storesContainer = document.getElementById("storesContainer");

fetch("https://localhost:7044/api/store")
    .then(response => response.json())
    .then(stores => {

        stores.forEach(store => {

            storesContainer.innerHTML += `
                <div class="store-card">

                    <div class="store-img"></div>

                    <div class="store-content">
                        <h4>${store.storeName}</h4>
                        <p>${store.address}</p>

                        <button class="designer">
                            查看設計師
                        </button>
                    </div>

                </div>
            `;
        });

    })
    .catch(error => {
        console.error(error);
    });