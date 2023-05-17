const increase = document.querySelector('.increase');
const decrease = document.querySelector('.decrease');
const count = document.querySelector('.count');

increase.addEventListener('click', Increase);
decrease.addEventListener('click', Decrease);

function Increase () {
    count.value++;
}

function Decrease () {
    if (count.value > 1) {
        count.value--;
    }
}