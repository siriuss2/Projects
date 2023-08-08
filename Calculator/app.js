const buttons = document.querySelectorAll('input[type="button"]');

for (const button of buttons) {
    button.addEventListener('click', function() {
        const display = document.querySelector('input[name="display"]');
        const value = this.value;
        if (value === 'C') {
            display.value = '';
        } else if (value === 'DE') {
            display.value = display.value.toString().slice(0, -1);
        } else if (value === '=') {
            display.value = eval(display.value);
        } else if (!isNaN(value)) {
            display.value += value;
        } else {
            display.value += value;
        }
    });
}