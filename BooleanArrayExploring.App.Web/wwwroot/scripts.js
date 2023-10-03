console.log("Loaded 'script.js'!");

let count = 0;

function test() {
    count++;
    console.log("New Click: count =", count);
}

function logRangeValue_X() {
    test();
    console.log(document.getElementById('customRange_X').value);
}

function logRangeValue_Y() {
    test();
    console.log(document.getElementById('customRange_Y').value);
}
