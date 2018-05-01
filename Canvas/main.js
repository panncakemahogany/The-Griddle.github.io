var theObject;
var theOtherObjects = [];
var control = false;

function runCanvas(){
    theObject = new component(50,50,25,0.01,"blue");
    /*theOtherObject = new component(200,200,10,0.3,"red");*/
    theCanvas.run();
}

var theCanvas = {
    sheet : document.createElement("canvas"),
    run : function() {
        this.sheet.height = 600;
        this.sheet.width = 1200;
        this.context = this.sheet.getContext("2d");
        document.body.insertBefore(this.sheet, document.body.childNodes[0]);
        this.frameNo = 0;
        this.interval = setInterval(updateSheet, 20);
        window.addEventListener('mousemove', function (e) {
            theCanvas.x = e.pageX;
            theCanvas.y = e.pageY;
        });
        window.addEventListener('click', function(){
            control = !control;
        });
    },
    clear : function() {
        this.context.clearRect(0,0,this.sheet.width,this.sheet.height);
    }
}

function everyInterval(n) {
    if ((theCanvas.frameNo / n) % 1 == 0) {return true;}
    return false;
}

function component(x,y,r,speed,color) {
    this.x = x;
    this.y = y;
    this.r = r;
    this.color = color;
    this.xSpeed = speed;
    this.ySpeed = 0;
    this.gravity = 0.25;
    this.bounce = 0.8;
    this.counter = 1;
    this.update = function () {
        ctx = theCanvas.context;
        ctx.beginPath();
        ctx.arc(this.x, this.y, this.r, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.fillStyle = this.color;
        ctx.fill();
    };
    this.newPos = function() {
        /*this.xSpeed += 0.01;*/
        this.x += this.xSpeed;
        this.ySpeed += this.gravity;
        this.y += (this.ySpeed);
        /*this.change();*/
        this.hitBottom();
        
    };
    this.hitBottom = function() {
        var rockBottom = theCanvas.sheet.height - this.r;
        if (this.y > rockBottom) {
            this.y = rockBottom;
            this.ySpeed = -(this.ySpeed * this.bounce);
        };
        if (this.y < 50) {
            this.y = 50;
            this.ySpeed = -(this.ySpeed * this.bounce);
        };
        if (this.x > theCanvas.sheet.width - 50){
            this.x = theCanvas.sheet.width - 50;
            this.xSpeed = -(this.xSpeed * this.bounce);
        };
        if (this.x < 50){
            this.x = 50;
            this.xSpeed = -(this.xSpeed * this.bounce);
        };
    };
    this.startOver = function() {
        var theEdge = theCanvas.sheet.width + this.r;
        if (this.x > theEdge || this.x < -100) {
            this.x = -50;
            this.y = -50;
            this.ySpeed = 0;
            this.xSpeed = 0.5;
        };
    };
    this.bump = function(otherobj) {
        var myleft = this.x + -25;
        var myright = this.x + 25;
        var mytop = this.y + -25;
        var mybottom = this.y + 25;
        var otherleft = otherobj.x + -5;
        var otherright = otherobj.x + 5;
        var othertop = otherobj.y + -5;
        var otherbottom = otherobj.y + 5;
        var bumped = true;
        if ((mybottom < othertop) ||
                (mytop > otherbottom) ||
                (myright < otherleft) ||
                (myleft > otherright)) {
            bumped = false;
        }
        /*this.x += -50;
        this.y += -50;
        otherobj.x += 50;
        otherobj.y += 50;*/
        return bumped;
    };
    this.follow = function() {
        this.x = theCanvas.x;
        this.y = theCanvas.y;
    };
    /*this.change = function() {
        switch (this.counter) {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                this.color = "blue";
                this.r += 5;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                this.color = "red";
                this.r += 5;
                break;
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
                this.color = "black";
                break;
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
                this.color = "yellow";
                this.r -= 5;
                break;
            case 21:
            case 22:
            case 23:
            case 24:
            case 25:
                this.color = "green";
                this.r -= 5;
                break;
        };
        if (this.counter == 25) {
            this.counter = 0;
        };
        this.counter += 1;
    }*/
}

function updateSheet() {
    var x, y;
    theCanvas.clear();
    theCanvas.frameNo += 1;
    if (theCanvas.frameNo == 1 || everyInterval(150)) {
        x = theCanvas.sheet.width;
        y = theCanvas.sheet.height - 400;
        theOtherObjects.push(new component(x,y,10,-0.01,"red"));
    }
    for (i = 0; i < theOtherObjects.length; i += 1) {
        theOtherObjects[i].xSpeed += -0.01;
        theOtherObjects[i].newPos();
        if (theObject.bump(theOtherObjects[i])) {
            var xBumpSpeed = theObject.xSpeed;
            var yBumpSpeed = theObject.ySpeed;
            theObject.xSpeed = theOtherObjects[i].xSpeed - 5;
            theObject.ySpeed = theOtherObjects[i].ySpeed - 5;
            theOtherObjects[i].xSpeed = xBumpSpeed;
            theOtherObjects[i].ySpeed = yBumpSpeed;
        }
        /*foreach (obj in theOtherObjects) {
            var i;
            for (i = 0; i < theOtherObjects.length; i += 1) {
                if (obj.bump(theOtherObjects[i])) {
                    var xBumpSpeed = obj.xSpeed;
                    var yBumpSpeed = obj.ySpeed;
                    obj.xSpeed = theOtherObjects[i].xSpeed - 1;
                    obj.ySpeed = theOtherObjects[i].ySpeed - 1;
                    theOtherObjects[i].xSpeed = xBumpSpeed;
                    theOtherObjects[i].ySpeed = yBumpSpeed;
                }
            }
        }*/
        theOtherObjects[i].update();
    }
    theObject.xSpeed += 0.05;
    theObject.newPos();
    if (control) {
        theObject.follow();
    }
    theObject.update();
    /*theObject.startOver();*/
}