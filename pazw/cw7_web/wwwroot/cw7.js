//alert("ala ma kota");
console.log("sad ad asdas da");

const paragrafy = document.querySelectorAll("p")
console.log(paragrafy);
for(let i=0;i<paragrafy.length;i++){
    if(i%2==0){
        paragrafy[i].style.color = "red";
    }
}