(function (me, undefined) {
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

    function extendObject(parentObject, childObject) {
        childObject.prototype = createObject(parentObject.prototype);
    };

    function mixinPrototypes(parentObject, childObject) {
        var parentPrototype = parentObject.prototype;
        var childPrototype = childObject.prototype;

        for (var prop in parentPrototype) {
            if (parentPrototype.hasOwnProperty(prop)) {
                childPrototype[prop] = parentPrototype[prop];
            }
        }
    }

    function Vehicle(propulsionUnit) {
        this.speed = 0;
        this.propulsionUnit = propulsionUnit;
    }

    Vehicle.prototype.accelerate = function accelerate() {
        for (var i = 0; i < this.propulsionUnit.length; i++) {
            if (this.propulsionUnit[i] instanceof PropulsionUnit) {
                this.speed += this.propulsionUnit[i].getAcceleration();
            }
        }
    }

    Vehicle.prototype.getSpeed = function getSpeed() {
        return this.speed;
    }

    function LandVehicle() {
        Vehicle.call(this, arguments);
    }

    extendObject(Vehicle, LandVehicle);

    function WaterVehicle() {
        Vehicle.call(this, arguments);
    }

    extendObject(Vehicle, WaterVehicle);

    WaterVehicle.prototype.togglePropellerSpinDirection = function togglePropellerSpinDirection() {
        for (var i = 0; i < this.propulsionUnit.length; i++) {
            if (this.propulsionUnit[i] instanceof PropulsionUnit) {
                switch (this.propulsionUnit[i].spinDirection) {
                    case propellerSpinDirections.CLOCKWISE:
                        this.propulsionUnit[i].spinDirection = propellerSpinDirections.COUNTERCLOCKWISE;
                        break;
                    case propellerSpinDirections.COUNTERCLOCKWISE:
                        this.propulsionUnit[i].spinDirection = propellerSpinDirections.CLOCKWISE;
                        break;
                }
            }
        }
    }

    function AirVehicle() {
        Vehicle.call(this, arguments);
    }

    extendObject(Vehicle, AirVehicle);

    AirVehicle.prototype.activateAfterburner = function activateAfterburner() {        
        for (var i = 0; i < this.propulsionUnit.length; i++) {
            if (this.propulsionUnit[i] instanceof PropulsionUnit) {
                this.propulsionUnit[i].afterburner = true;
            }
        }
    }

    AirVehicle.prototype.deactivateAfterburner = function deactivateAfterburner() {
        for (var i = 0; i < this.propulsionUnit.length; i++) {
            if (this.propulsionUnit[i] instanceof PropulsionUnit) {
                this.propulsionUnit[i].afterburner = false;
            }
        }
    }

    function AmphibiousVehicle() {
        Vehicle.call(this, arguments);
        this.mode = amphibiousModes.LAND;
        this.mixedPropulsionUnits = this.propulsionUnit;
    }

    extendObject(Vehicle, AmphibiousVehicle);

    AmphibiousVehicle.prototype.accelerate = function accelerate() {
        var self = this;

        this.propulsionUnit = Array.prototype.filter.call(this.mixedPropulsionUnits, function (value) {
            var pass = false;
            switch (self.mode) {
                case amphibiousModes.LAND:
                    if (value instanceof Wheel) {
                        pass = true;
                    }
                    break;
                case amphibiousModes.WATER:
                    if (value instanceof Propeller) {
                        pass = true;
                    }
                    break;
            }

            return pass;
        });

        Vehicle.prototype.accelerate.call(this);
    }

    AmphibiousVehicle.prototype.transitionToWater = function transitionToWater() {
        this.mode = amphibiousModes.WATER;
        this.speed = 0;
    }

    AmphibiousVehicle.prototype.transitionToLand = function transitionToLand() {
        this.mode = amphibiousModes.LAND;
        this.speed = 0;
    }    

    function PropulsionUnit(acceleration) {
        this.acceleration = acceleration || 0;
    }

    PropulsionUnit.prototype.getAcceleration = function getAcceleration() {
        return this.acceleration;
    }

    function Wheel(radius) {        
        PropulsionUnit.call(this, (Math.PI * 2 * radius));
    }

    extendObject(PropulsionUnit, Wheel);

    function PropellingNozzle(power) {
        this.afterburner = false;
        this.power = power;
        this.AFTERBURNER_MULTIPLIER = 2;
        PropulsionUnit.call(this, power);
    }

    extendObject(PropulsionUnit, PropellingNozzle);

    PropellingNozzle.prototype.getAcceleration = function getAcceleration() {
        switch (this.afterburner) {
            case true:
                this.acceleration = this.power * this.AFTERBURNER_MULTIPLIER;            
        }

        return this.acceleration;
    }

    function Propeller(finsNumber) {
        this.finsNumber = finsNumber;
        this.spinDirection = propellerSpinDirections.CLOCKWISE;
        PropulsionUnit.call(this, finsNumber);
    }

    extendObject(PropulsionUnit, Propeller);

    Propeller.prototype.getAcceleration = function getAcceleration() {
        switch (this.spinDirection) {
            case propellerSpinDirections.COUNTERCLOCKWISE:
                this.acceleration = -this.acceleration;
        }

        return this.acceleration;
    }

    var propellerSpinDirections = Object.freeze({
        CLOCKWISE: 1,
        COUNTERCLOCKWISE: 2
    });

    var amphibiousModes = Object.freeze({
        LAND: 1,
        WATER: 2
    });

    me.LandVehicle = LandVehicle;
    me.AirVehicle = AirVehicle;
    me.WaterVehicle = WaterVehicle;
    me.AmphibiousVehicle = AmphibiousVehicle;
    me.Wheel = Wheel;
    me.PropellingNozzle = PropellingNozzle;
    me.Propeller = Propeller;
}(window.vehicles = window.vehicles || {}));    