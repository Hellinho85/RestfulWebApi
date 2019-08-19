let addUserBtn = document.getElementById("btn1");

let port = "61004";

let addUsers = async () => {
    let url = "http://localhost:" + port + "api/users/id";
    await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application.json"
        },
        body: addUsers.value

    });

}

addUserBtn.addEventListener("click", addUsers);










