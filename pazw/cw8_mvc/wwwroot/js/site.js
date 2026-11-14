setTimeout(() => {
  document.querySelector("#time").style.display = "inline-block";
}, 3000);

setInterval(()=>{
    document.querySelector("#time").innerHTML = new Date().toLocaleTimeString();
},1000)