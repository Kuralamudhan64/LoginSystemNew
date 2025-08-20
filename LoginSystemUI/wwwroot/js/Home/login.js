console.log("Hello");


let button = document.getElementById("button");



button.addEventListener('click', (e) => {
    e.preventDefault();
    let name = document.getElementById("name").value;
    let password = document.getElementById("password").value;
    console.log({ name ,password});
    
    const url = "https://localhost:7087/api/Home/SignUp";
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username: name,
            password: password
        })
    })
        .then(response => response.json())
        .then(data => {
            if (data.isSuccessfull)
                alert(data.message);
            else
                alert("Error", data.message);
        })
        .catch(error => {
            console.log(error);
        })

})





