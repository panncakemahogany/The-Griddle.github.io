var intervalCount;
var clickMultiplier;

var autoClickers = {
    amount: 0,
    buy: function () {
        this.amount += 1;
    },
    click: function () {
        this.interval = setInterval(autoClick(this.amount), 1000);
    }
}

function start() {
    intervalCount = 0;
    clickMultiplier = 1;
    changeControls();
    counter.tick();
}

var counter = {
    tick: function () {
        this.interval = setInterval(updateTicks, 1000);
    }
}

function updateTicks() {
    autoClickers.click();

    intervalCount++;
    $('#counterDisplay').val(intervalCount);

    if (intervalCount >= 1000)
        addBuyAutoClicker();

    if (intervalCount >= 100)
        addBuyClickMultiplier();
}

function changeControls() {
    $('#startBtn').hide();
    $('#counterDisplay').show();
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="addButton" onclick="addClick()">Click</button></div>'
    );
}

function addBuyClickMultiplier() {
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="multiplierPurchaseButton" onclick="buyClickMultiplier()">Upgrade Click Power</button></div>'
    );
}

function addBuyAutoClicker() {
    $('#buttonArea').append(
        '<div class="col-md-3"><button class="btn btn-lg btn-primary" id="autoClickerPurchaseButton" onclick="buyAutoClicker()">Buy Auto Clicker</button></div>'
    );
}

function buyClickMultiplier() {
    intervalCount -= 100;
    $('#counterDisplay').val(intervalCount);
    clickMultiplier++;
}

function addClick() {
    intervalCount += clickMultiplier;
    $('#counterDisplay').val(intervalCount);
}

function buyAutoClicker() {
    intervalCount -= 1000;
    $('#counterDisplay').val(intervalCount);
    autoClickers.buy();
}

function autoClick(amount) {
    intervalCount += amount;
}