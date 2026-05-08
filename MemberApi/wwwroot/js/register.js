const loginForm = document.getElementById("loginForm");

const login = async (event) => {
    event.preventDefault();
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
   
    const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    });

    if (!response.ok) {
        alert("帳號或密碼錯誤");
        return;
    }

    const token = (await response.text()).trim();

    localStorage.setItem("token", token)
    window.location.href = "/index.html";
   /* console.log(account);*/
};

loginForm.addEventListener("submit", login);