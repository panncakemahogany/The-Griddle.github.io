$('document').ready(function () {
    start();
});

var intervalCount;
var clickCount;
var multiplier;
var multiplierBtnExists;
var autoClickers;
var autoClickerBtnExists;

function start() {
    intervalCount = 0;
    clickCount = 0;
    multiplier = 1;
    autoClickers = 0;
    multiplierBtnExists = false;
    autoClickerBtnExists = false;
    addClickButton();
    counter.tick();
}

var counter = {
    tick: function () {
        this.interval = setInterval(updateTicks, 20);
    }
}

function updateTicks() {

    intervalCount++;

    if (intervalCount >= 50) {
        clickCount += 1;
        clickCount += autoClickers;
        intervalCount = 0;
    }

    if (clickCount >= 100 && !multiplierBtnExists) {
        addPurchaseClickMultiplier();
        multiplierBtnExists = true;
    }
    if (clickCount >= 1000 && !autoClickerBtnExists) {
        addPurchaseAutoClicker();
        autoClickerBtnExists = true;
    }

    $('#Clicks').val(clickCount);
    $('#ClickMultiplier').val(multiplier);
    $('#AutoClickers').val(autoClickers);
}

function addClickButton() {
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="addButton" onclick="addClick()">Click</button></div>'
    );
}

function addClick() {
    clickCount += multiplier;
}

function addPurchaseClickMultiplier() {
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="multiplierPurchaseButton" onclick="buyClickMultiplier()">Upgrade Click Power</button></div>'
    );
}

function buyClickMultiplier() {
    clickCount -= 100;
    multiplier++;
}

function addPurchaseAutoClicker() {
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="autoClickerPurchaseButton" onclick="buyAutoClicker()">Buy Auto Clicker</button></div>'
    );
}

function buyAutoClicker() {
    clickCount -= 1000;
    autoClickers++;
}