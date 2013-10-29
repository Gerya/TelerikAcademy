(function (controls, undefined) {
    // @constructor
    controls.TreeView = function TreeView(selector) {
        var target = document.querySelector(selector);

        var ul = createUl();
        appendElement(target, ul);

        this.parent = ul;
    }

    controls.TreeView.prototype.addNode = addNode;
    controls.TreeView.prototype.addEventHandler = addEventHandler;

    function createUl() {
        return createElement("ul");
    }

    function createLi() {
        return createElement("li");
    }

    function createElement(name) {
        var ul = document.createElement(name);

        return ul;
    }

    function appendElement(parent, child) {
        parent.appendChild(child);
    }

    function addNode() {
        var subNode;
        var li = createLi();
        subNode = li;

        if (this.parent.nodeName.toLowerCase() == "li") {
            var ul = createUl();
            appendElement(ul, subNode);
            subNode = ul;
        }

        appendElement(this.parent, subNode);

        var newObj = createObject(controls.TreeView.prototype);

        newObj.parent = li;
        newObj.content = content;

        return newObj;
    }

    function content(text) {
        var anchor = createElement("a");
        anchor.href = "#";
        anchor.innerHTML = text;
        appendElement(this.parent, anchor);
    }

    /*
    Add event handler to elements that match speficied group of selectors
    
    @public
    @method addEventHandler    
    @param String eventType: the type of the event to listen for
    @param Function handler: the receiver of the notification when an event occurs
    @return void:
    */
    function addEventHandler(eventType, handler) {
        if (this.parent.addEventListener) {
            this.parent.addEventListener(eventType, handler, false);
        } else {
            this.parent.attachEvent('on' + eventType, handler);
        }
    }

    /*
    Internal shim for Object.create method.
    Creates a new object with specified prototype object.
        
    @private
    @method createObject
    @param Object protoObject: the type of the element to be created
    @return Object: the newly created object
    */
    var createObject = Object.create || function createObject(protoObject) {
        if (arguments.length > 1) {
            throw new ArgumentOutOfRangeException("The current implementation only accepts the first parameter.");
        }
        // we only want the prototype part of the "new"
        // behavior, so make an empty constructor
        function F() { }

        // set the function's "prototype" property to the
        // object that we want the new object's prototype
        // to be.
        F.prototype = protoObject;

        // use the `new` operator. We will get a new
        // object whose prototype is o, and we will
        // invoke the empty function, which does nothing.
        var newObj = new F();

        return newObj;
    };
}(window.controls = window.constrols || {}));