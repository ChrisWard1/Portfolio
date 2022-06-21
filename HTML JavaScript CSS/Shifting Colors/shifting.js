function intervals(){
    setInterval(getTime, 1000);
}

function getTime(){

    let timeInfo = document.getElementById("timeinfo");
    timeInfo.innerHTML = `${new Date(Date.now()).toString()}`;

    let divs = document.querySelectorAll(".grid-container > div");

    divs.forEach(area => {
        let r = Math.random() * 255;
        let g = Math.random() * 255;
        let b = Math.random() * 255;
        let a = Math.random();
        area.style.backgroundColor = `rgba(${r}, ${g}, ${b}, ${a})`;

    });
} 
